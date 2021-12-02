using System.Diagnostics;

namespace XrayServer
{
    public class XRayProcessHelper
    {
        private readonly string _xrayPath;
        private readonly Process _process = new();
        private bool _isRunning = false;

        public Action<string>? OutputLineAction;
        public XRayProcessHelper()
        {
            var currentPath = Environment.CurrentDirectory;
            _xrayPath = Path.Join(currentPath, "xray_x64.exe");
        }

        public async void Start(string configPath)
        {
            if (_isRunning) return;

            _isRunning = true;

            await Task.Run(() =>
            {
                try
                {
                    _process.StartInfo.UseShellExecute = false;
                    _process.StartInfo.FileName = _xrayPath;
                    _process.StartInfo.CreateNoWindow= true;
                    _process.StartInfo.Arguments = $"run -config {configPath}";
                    _process.StartInfo.RedirectStandardOutput = true;
                    _process.Start();

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
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            });

            _isRunning = false;
        }

        public void Stop()
        {
            _process.Kill();
        }
    }
}
