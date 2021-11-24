using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrayServer
{
    public class XrayProcessHelper
    {
        private String _xrayPath = "";
        private String _configPath = "";
        private Process _process;
        public XrayProcessHelper()
        {
            var currentPath = Environment.CurrentDirectory;
            _xrayPath = Path.Join(currentPath, "xray_x64.exe");
            _configPath = Path.Join(currentPath, "xray_config.json");
        }

        public void Start()
        {
            Task.Run(() =>
            {
                try
                {
                    _process = new Process();
                    _process.StartInfo.UseShellExecute = false;
                    _process.StartInfo.FileName = _xrayPath;
                    _process.StartInfo.CreateNoWindow= true;
                    _process.StartInfo.Arguments = $"run -config {_configPath}";
                    _process.StartInfo.RedirectStandardOutput = true;
                    _process.Start();

                    // 利用job作业系统管理子进程的生命周期
                    ChildProcessTracker.AddProcess(_process);

                    var reader = _process.StandardOutput;
                    var ret = reader.ReadLine();
                    while (ret != null)
                    {
                        Debug.WriteLine(ret);
                        ret = reader.ReadLine();
                    }

                    _process.WaitForExit();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            });
        }

        public void Stop()
        {
            if (_process != null)
                _process.Kill();
        }
    }
}
