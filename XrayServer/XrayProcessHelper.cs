using Grpc.Net.Client;
using System.Diagnostics;
using static Xray.App.Stats.Command.StatsService;

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

        private GrpcChannel? _channel;

        public XRayProcessHelper()
        {
            var currentPath = Environment.CurrentDirectory;
            _xrayPath = Path.Join(currentPath, "xray_x64.exe");
        }

        public async void Start(string configPath, int apiPort)
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

                    _channel = GrpcChannel.ForAddress($"http://127.0.0.1:{apiPort}");

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
                    Stop();
                    Debug.WriteLine(ex.Message);
                }
            }, CancellationToken.None, TaskCreationOptions.None, _scheduler);
        }

        private bool IsRunning()
        {
            return Interlocked.CompareExchange(ref _isRuning, 0, 0) != 0;
        }

        public void Stop()
        {
            if (IsRunning())
            {
                _process?.Kill();
                _channel?.ShutdownAsync();
            }    
        }

        /// <summary>
        /// 查询出站代理的速度， 间隔一秒查询一次，查询完将数据重置
        /// </summary>
        /// <param name="outBountTag">出站代理的标签</param>
        /// <returns></returns>
        public (long uplink, long downlink) Query(string outBountTag)
        {
            (long uplink, long downlink) ret = (0, 0);
            try
            {
                if (!IsRunning()) return ret;

                var client = new StatsServiceClient(_channel);
                var res = client.QueryStats(new Xray.App.Stats.Command.QueryStatsRequest()
                {
                    Pattern = "",
                    Reset = true
                });
                foreach (var item in res.Stat)
                {
                    if (item.Name == @$"outbound>>>{outBountTag}>>>traffic>>>uplink")
                        ret.uplink = item.Value;
                    else if (item.Name == @$"outbound>>>{outBountTag}>>>traffic>>>downlink")
                        ret.downlink = item.Value;
                }

                return ret;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return ret;
            }
        }
    }
}
