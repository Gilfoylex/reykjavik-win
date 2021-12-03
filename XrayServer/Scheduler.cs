using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrayServer
{
    public class Scheduler : TaskScheduler
    {
        private readonly BlockingCollection<Task> taskQueue = new BlockingCollection<Task>();

        public Scheduler(int threadCount, ThreadPriority threadPriority)
        {
            for (int i = 0; i < threadCount; i++)
            {
                var th = new Thread(Run);
                th.IsBackground = true;
                th.Start();
            }
        }

        private void Run()
        {
            try
            {
                while (taskQueue.TryTake(out var task, Timeout.Infinite))
                {
                    TryExecuteTask(task);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        protected override IEnumerable<Task>? GetScheduledTasks()
        {
            return taskQueue;
        }

        protected override void QueueTask(Task task)
        {
            taskQueue.Add(task);
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return false;
        }
    }
}
