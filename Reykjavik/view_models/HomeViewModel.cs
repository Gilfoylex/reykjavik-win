using System;
using MvvmHelpers.Commands;
using Reykjavik.views;
using System.Collections.ObjectModel;
using System.Windows;
using MvvmHelpers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace Reykjavik.view_models
{
    partial class MainViewModel
    {
        private readonly XrayServer.XRayProcessHelper _xRayProcessHelper = new();

        private void StartXRay()
        {
            var path = GenXrayConfig();
            _xRayProcessHelper.Start(path);
        }

        public void StopXRay()
        {
            _xRayProcessHelper.Stop();
        }

        private Command? _connectCommand;

        private bool _isConncect = false;

        public Command ConnectCommand => _connectCommand ??= new Command((param) =>
        {
            _pacHttpServer.Start(PacPort);
            StartXRay();
            ChangeProxy(true);
            ConnectTag = SelectedTag;
            _isConncect = true;
        });

        private Command? _disConnectCommand;

        public Command DisConnectCommand => _disConnectCommand ??= new Command((param) =>
        {
            ChangeProxy(false);
            _pacHttpServer.Stop();
            StopXRay();
            ConnectTag = "";
            _isConncect = false;
        });

        // 配置修改后重启xray，重新设置连接和代理
        private void  ReConnect()
        {
            ChangeProxy(false);
            StopXRay();
            _pacHttpServer.Stop();

            StartXRay();
            _pacHttpServer.Start(PacPort);
            ChangeProxy(true);
        }

        private ObservableRangeCollection<ConnectViewModel> _connectViewModelList = new();
        public ObservableRangeCollection<ConnectViewModel> ConnectViewModelList
        {
            get => _connectViewModelList;
            set => SetProperty(ref _connectViewModelList, value);
        }

        private string _selectedTag = "";
        public string SelectedTag
        {
            get => _selectedTag;
            set => SetProperty(ref _selectedTag, value);
        }

        private string _connectTag = "";
        public string ConnectTag
        {
            get => _connectTag;
            set => SetProperty(ref _connectTag, value);
        }

        private Command? _selectCommand;
        public Command SelectCommand => _selectCommand ??= new Command((param) => {
            if (param is not string tag)
                return;

            SelectedTag = tag;
            UpdateLocalSelectTag();
        });


        private Command? _addCommand;
        public Command AddCommand => _addCommand ??= new Command((param) =>
        {
            var wnd = new ConnectWindow();
            wnd.Owner = Application.Current.MainWindow;
            var vm = new ConnectViewModel();
            wnd.DataContext = vm;
            wnd.ConfirmAction = () =>
            {
                ConnectViewModelList.Add(vm);
                UpdateLocalOutBounds();
            };
            wnd.Show();
        });

        private Command? _delCommand;
        public Command DelCommand => _delCommand ??= new Command((param) =>
        {
            if (param is not ConnectViewModel connect)
                return;

            ConnectViewModelList.Remove(connect);
            UpdateLocalOutBounds();
        });

        private Command? _editCommand;
        public Command EditCommand => _editCommand ??= new Command((param) => {

            if (param is not ConnectViewModel oldConnect)
                return;

            var wnd = new ConnectWindow();
            wnd.Owner = Application.Current.MainWindow;
            var newConnect = new ConnectViewModel();
            newConnect.CopySettings(oldConnect);
            wnd.DataContext = newConnect;
            wnd.ConfirmAction = () =>
            {
                oldConnect.CopySettings(newConnect);
                UpdateLocalOutBounds();
            };
            wnd.Show();

        });


        public bool TagExist(string tag)
        {
            foreach (var item in ConnectViewModelList)
            {
                if (item.TagName == tag)
                    return true;
            }

            return false;
        }

        private void InitHomeSetting()
        {
            _xRayProcessHelper.OutputLineAction = AddLogLine;
            SelectedTag = _localConfig.SelectTag;
            GetLocalConnects();
        }

        private void UpdateLocalSelectTag()
        {
            _localConfig.SelectTag = SelectedTag;
            SaveLocalConfig();
        }

        // 获取配置文件中的连接数据
        private void GetLocalConnects()
        {
            var connects = new List<ConnectViewModel>();
            foreach(var item in _localConfig.LocalOutBounds)
            {
                connects.Add(OutBoundToConnectVm(item));
            }

            ConnectViewModelList.ReplaceRange(connects);
        }

        private ConnectViewModel OutBoundToConnectVm(models.XRayConfigDefine.Outbound ot)
        {
            var ret = new ConnectViewModel();
            ret.TagName = ot.tag;
            ret.Mux = ot.mux.enabled;
            if (string.Compare(ot.protocol, "vless", StringComparison.OrdinalIgnoreCase) == 0)
            {
                ret.Protocol = ot.protocol;
                if (ot.settings != null && ot.settings.vnext != null)
                {
                    foreach (var item in ot.settings.vnext)
                    {
                        ret.Address = item.address;
                        ret.Port = item.port;
                        foreach (var user in item.users)
                        {
                            ret.UUID = user.id;
                            ret.XTlsDirect = string.Compare(user.flow, "xtls-rprx-direct", StringComparison.OrdinalIgnoreCase) == 0;
                            break;
                        }
                        break;
                    }
                }
            }
            else if (string.Compare(ot.protocol, "trojan", StringComparison.OrdinalIgnoreCase) == 0)
            {
                ret.Protocol = ot.protocol;
                if (ot.settings != null && ot.settings.servers != null)
                {
                    foreach (var item in ot.settings.servers)
                    {
                        ret.Address = item.address;
                        ret.Port = item.port;
                        ret.Password = item.password;
                        break;
                    }
                }
            }


            if (ot.streamSettings != null)
            {
                ret.Network = ot.streamSettings.network;
                ret.Security = ot.streamSettings.security;


                if (string.Compare(ot.streamSettings.network, "tcp", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    // do nothing
                }

                if (string.Compare(ot.streamSettings.network, "ws", StringComparison.OrdinalIgnoreCase) == 0 && ot.streamSettings.wsSettings != null)
                {
                    ret.WsPath = ot.streamSettings.wsSettings.path;
                }

                if (string.Compare(ot.streamSettings.security, "tls", StringComparison.OrdinalIgnoreCase) == 0 && ot.streamSettings.tlsSettings != null)
                {
                    ret.TlsServerAddress = ot.streamSettings.tlsSettings.serverName;
                    ret.AllowInsecure = ot.streamSettings.tlsSettings.allowInsecure;
                }

                if (string.Compare(ot.streamSettings.security, "xtls", StringComparison.OrdinalIgnoreCase) == 0 && ot.streamSettings.xtlsSettings != null)
                {
                    ret.TlsServerAddress = ot.streamSettings.xtlsSettings.serverName;
                    ret.AllowInsecure = ot.streamSettings.xtlsSettings.allowInsecure;
                }

                ret.FastOpen = ot.streamSettings.sockopt.tcpFastOpen;

            }

            return ret;
        }


        private void UpdateLocalOutBounds()
        {
            var outBounds = new List<models.XRayConfigDefine.Outbound>();
            foreach (var item in ConnectViewModelList)
            {
                outBounds.Add(ConnectVmToOutBound(item));
            }
            _localConfig.LocalOutBounds = outBounds;

            SaveLocalConfig();
        }

        private models.XRayConfigDefine.Outbound ConnectVmToOutBound(ConnectViewModel vm)
        {
            var ret = new models.XRayConfigDefine.Outbound();
            if (vm != null)
            {
                ret.tag = vm.TagName;
                ret.mux.enabled = vm.Mux; 
                if (string.Compare(vm.Protocol, "vless", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    ret.protocol = "vless";
                    ret.settings = new models.XRayConfigDefine.OutboundSettings
                    {
                        vnext = new List<models.XRayConfigDefine.VnextVless>
                        {
                            new models.XRayConfigDefine.VnextVless
                            {
                                address = vm.Address, port = vm.Port, users = new List<models.XRayConfigDefine.VLessUser>
                                {
                                    new models.XRayConfigDefine.VLessUser
                                    {
                                        id = vm.UUID, flow = vm.XTlsDirect ? "xtls-rprx-direct" : null
                                    }
                                }
                            }
                        }
                    };
                }
                else if (string.Compare(vm.Protocol, "trojan", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    ret.protocol = "trojan";
                    ret.settings = new models.XRayConfigDefine.OutboundSettings
                    {
                        servers = new List<models.XRayConfigDefine.TrojanServer>
                        {
                            new models.XRayConfigDefine.TrojanServer
                            {
                                address = vm.Address, port = vm.Port, password = vm.Password
                            }
                        }
                    };
                }

                ret.streamSettings = new models.XRayConfigDefine.StreamSettings
                {
                    network = vm.Network,
                    security = vm.Security,
                };

                if (string.Compare(vm.Network, "tcp", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    // do nothing
                }
                else if (string.Compare(vm.Network, "ws", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    ret.streamSettings.wsSettings = new models.XRayConfigDefine.WsSettings
                    {
                        path = vm.WsPath
                    };
                }

                if (string.Compare(vm.Security, "tls", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    ret.streamSettings.tlsSettings = new models.XRayConfigDefine.TlsSettings
                    {
                        serverName = vm.TlsServerAddress,
                        allowInsecure = vm.AllowInsecure,
                    };
                }
                else if (string.Compare(vm.Security, "xtls", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    ret.streamSettings.xtlsSettings = new models.XRayConfigDefine.TlsSettings
                    {
                        serverName = vm.TlsServerAddress,
                        allowInsecure = vm.AllowInsecure,
                    };
                }

                ret.streamSettings.sockopt.tcpFastOpen = vm.FastOpen; 
            }

            return ret;
        }


        private string GenXrayConfig()
        {
            try
            {
                var xrayConfig = new models.XRayConfigDefine.XRayConfig();
                xrayConfig.log = models.DefaultXRayConfig.LogConfig;
                xrayConfig.api = models.DefaultXRayConfig.ApiConfig;
                xrayConfig.policy = models.DefaultXRayConfig.PolicyConfig;
                xrayConfig.routing = new models.XRayConfigDefine.Routing
                {
                    rules = new List<models.XRayConfigDefine.Rule>
                {
                    models.DefaultXRayConfig.ApiRule,
                },
                    domainStrategy = "AsIs"
                };

                if (_localConfig.AdBlock)
                {
                    xrayConfig.routing.rules.Add(models.DefaultXRayConfig.ADBlockRule);
                }

                xrayConfig.inbounds = _localConfig.LocalInBounds;
                xrayConfig.outbounds = new List<models.XRayConfigDefine.Outbound>();
                var curConnect = GetSelectConnectVm();
                if (curConnect != null)
                    xrayConfig.outbounds.Add(ConnectVmToOutBound(curConnect));

                foreach (var item in models.DefaultXRayConfig.OutboundConfigs)
                {
                    xrayConfig.outbounds.Add(item);
                }

                var jsonStr = JsonSerializer.Serialize(xrayConfig, new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
                if (!Directory.Exists(AppDataPath))
                    Directory.CreateDirectory(AppDataPath);

                var configFullPath = Path.Join(AppDataPath, "gen_xray_config.json");
                using var sw = new StreamWriter(configFullPath);
                sw.Write(jsonStr);

                return configFullPath;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return "";
            }
        }

        private ConnectViewModel? GetSelectConnectVm()
        {
            foreach(var vm in ConnectViewModelList)
            {
                if (!string.IsNullOrEmpty(SelectedTag) && vm.TagName == SelectedTag)
                {
                    return vm;
                }
            }

            return null;
        }
    }
}
