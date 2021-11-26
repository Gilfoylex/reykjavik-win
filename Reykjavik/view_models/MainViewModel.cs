using MvvmHelpers;
using MvvmHelpers.Commands;
using Reykjavik.models.XRayConfigDefine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using firework;
using Reykjavik.models;

namespace Reykjavik.view_models
{
    public partial class MainViewModel : BaseViewModel
    {
        private static readonly Lazy<MainViewModel> Lazy = new(() => new MainViewModel());
        public static MainViewModel Instance => Lazy.Value;

        private MainViewModel()
        {
            Init();
        }

        public string AppDataPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "reykjavik");
        public string TempPath = Path.Combine(Path.GetTempPath(), "reykjavik");

        public const string ConfigFileName = "reykjavikconfig.json";

        private LocalConfig _localConfig = new LocalConfig();

        private string _currentTab = "home";
        public string CurrentTab
        {
            get => _currentTab;
            set => SetProperty(ref _currentTab, value);
        }

        private Command? _tabCommand;
        public Command TabCommand => _tabCommand ??= new Command((param) =>
        {
            if (param is not string tabName) return;

            CurrentTab = tabName;
        });


        #region XRay进程和配置相关


        public string GetXRayConfig()
        {
            var config = new XRayConfig
            {
                api = DefaultXRayConfig.ApiConfig,
                log = DefaultXRayConfig.LogConfig,
                routing = DefaultXRayConfig.RoutingConfig,
                policy = DefaultXRayConfig.PolicyConfig,
                inbounds = DefaultXRayConfig.InBoundConfigs,
                outbounds = DefaultXRayConfig.OutboundConfigs
            };

            var x = new VnextVless()
            {
                address = "gilfoylex.tk",
                port = 443,
                users = new List<VLessUser>()
                {
                    new()
                    {
                        id = "45dad708-71ab-4d55-966c-42503100897a",
                        encryption = "none",
                        level = 0,
                        email = "gaoruiqi@vmessws.com"
                    }
                }
            };

            config.outbounds.Insert(0,new Outbound()
            {
                tag = "vless_ws",
                protocol = "vless",
                settings = new VLessOut()
                {
                    vnext = new List<VnextVless>()
                    {
                        new VnextVless()
                        {
                            address = "gilfoylex.tk",
                            port = 443,
                            users = new List<VLessUser>()
                            {
                                new ()
                                {
                                    id = "45dad708-71ab-4d55-966c-42503100897a",
                                    encryption = "none",
                                    level = 0,
                                    email = "gaoruiqi@vmessws.com"
                                }
                            }
                        }
                    }
                },
                streamSettings = new StreamSettings()
                {
                    network = "ws",
                    security = "tls",
                    tlsSettings = new TlsSettings()
                    {
                        serverName = "gilfoylex.tk"
                    },
                    wsSettings = new WsSettings
                    {
                        acceptProxyProtocol = true,
                        path = @"/ray"
                    }
                }
            });

            var ret = "{}";
            try
            {
                ret = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return ret;
        }

        private readonly XrayServer.XRayProcessHelper _xRayProcessHelper = new();

        private void StartXRay()
        {
            _xRayProcessHelper.OutputLineAction += AddLogLine;
            _xRayProcessHelper.Start();
        }

        private void StopXRay()
        {
            _xRayProcessHelper.OutputLineAction -= AddLogLine;
            _xRayProcessHelper.Stop();
        }

        private Command? _testStart;

        public Command TestStartCommand => _testStart ??= new Command((param) =>
        {
            StartXRay();
        });

        private Command? _testStop;

        public Command TestStopCommand => _testStop ??= new Command((param) =>
        {
            StopXRay();
        });

        #endregion

        private async void Init()
        {
            await InitLocalConfigAsync();
            InitProxySetting();
        }

        private object localConfigLock = new object();
        private Task InitLocalConfigAsync()
        {
            return Task.Run(() =>
            {
                var configFullPath = Path.Join(AppDataPath, ConfigFileName);
                if (File.Exists(configFullPath))
                {
                    try
                    {
                        var jsonStr = "";

                        lock (localConfigLock)
                        {
                            using var rs = new StreamReader(configFullPath);
                            jsonStr = rs.ReadToEnd();
                        }

                        if (string.IsNullOrEmpty(jsonStr))
                            return;

                        var localJson = JsonSerializer.Deserialize<LocalConfig>(jsonStr);
                        if (localJson != null)
                            _localConfig = localJson;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            });
        }

        private void SaveLocalConfig()
        {
            Task.Run(() =>
            {
                var jsonStr = JsonSerializer.Serialize(_localConfig, new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
                var configFullPath = Path.Join(AppDataPath, ConfigFileName);
                lock (localConfigLock)
                {
                    using var sw = new StreamWriter(configFullPath);
                    sw.Write(jsonStr);
                }
            });
        }

    }
}
