using System.Diagnostics;

namespace XrayServer
{
    public class XRayProcessHelper
    {
        private readonly string _xrayPath;
        private Process? _process = null;

        public Action<string>? OutputLineAction;

        // 用一个常驻的单线程调度xray进程
        private Scheduler _scheduler = new(1, ThreadPriority.Normal);

        private int _isRuning = 0; 

        public XRayProcessHelper()
        {
            var currentPath = Environment.CurrentDirectory;
            _xrayPath = Path.Join(currentPath, "xray_x64.exe");
        }

        public async void Start(string configPath)
        {
            await Task.Factory.StartNew(() =>
            {
                try
                {
                    _process = new Process();
                    _process.StartInfo.UseShellExecute = false;
                    _process.StartInfo.FileName = _xrayPath;
                    _process.StartInfo.CreateNoWindow = true;
                    _process.StartInfo.Arguments = $"run -config {configPath}";
                    _process.StartInfo.RedirectStandardOutput = true;
                    _process.Start();

                    Interlocked.Increment(ref _isRuning);

                    // 利用job作业系统管理子进程的生命周期
                    ChildProcessTracker.AddProcess(_process);

                    var reader = _process.StandardOutput;
                    var ret = reader.ReadLine();
                    while (ret != null)
                    {
                        Debug.WriteLine(ret);
                        OutputLineAction?.Invoke(ret);
                        ret = reader.ReadLine();
                    }

                    _process.WaitForExit();

                    Interlocked.Decrement(ref _isRuning);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }, CancellationToken.None, TaskCreationOptions.None, _scheduler);
        }

        public void Stop()
        {
            if (Interlocked.CompareExchange(ref _isRuning, 0, 0) != 0 && _process != null)
                _process.Kill();
        }
    }
}
