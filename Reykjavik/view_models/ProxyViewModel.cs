using MvvmHelpers.Commands;
using Reykjavik.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reykjavik.view_models
{
    partial class MainViewModel
    {
        private string _ipAddress = "127.0.0.1";

        public string IpAddress
        {
            get => _ipAddress;
            set => SetProperty(ref _ipAddress, value);
        }

        private int _socksPort;

        public int SocksPort
        {
            get => _socksPort;
            set => SetProperty(ref _socksPort, value);
        }

        public int _httpPort;

        public int HttpPort
        {
            get => _httpPort;
            set => SetProperty(ref _httpPort, value);
        }

        private int _pacPort;

        public int PacPort
        {
            get => _pacPort;
            set => SetProperty(ref _pacPort, value);
        }

        private string _proxyMode = "none"; // none | pac | global

        public string ProxyMode
        {
            get => _proxyMode;
            set => SetProperty(ref _proxyMode, value);
        }

        private bool _adBlock = false;

        public bool AdBlock
        {
            get => _adBlock;
            set => SetProperty(ref _adBlock, value);
        }

        private void InitProxySetting()
        {
            IpAddress = _localConfig.IpAddress;
            SocksPort = _localConfig.SocksPort;
            HttpPort = _localConfig.HttpPort;
            PacPort = _localConfig.PacPort;
            ProxyMode = _localConfig.ProxyMode;
            AdBlock = _localConfig.AdBlock;
        }

        private Command? _proxyModeCommand;
        public Command ProxyModeCommand => _proxyModeCommand ??= new Command((param) =>
        {
            if (param is not string proxymode)
                return;

            ProxyMode = proxymode;
        });

        private Command? _applyCommand;
        public Command ApplyCommand => _applyCommand ??= new Command((param) =>
        {
            _localConfig.AdBlock = AdBlock;
            _localConfig.ProxyMode = ProxyMode;
            _localConfig.PacPort = PacPort;
            _localConfig.HttpPort = HttpPort;
            _localConfig.SocksPort = SocksPort;
            _localConfig.IpAddress = IpAddress;
            UpdateHttpListenAndPort(IpAddress, HttpPort);
            UpdateSocksListenAndPort(IpAddress, SocksPort);
            UpdateApiIpAddress(IpAddress);

            SaveLocalConfig();

            if (_isConncect)
            {
                ReConnect();
            }
        });

        private void UpdateHttpListenAndPort(string ipAddress, int port)
        {
            foreach (var item in _localConfig.LocalInBounds)
            {
                if (item.tag == DefaultXRayConfig.MainHttpTag)
                {
                    item.port = port;
                    item.listen = ipAddress;
                    break;
                }
            }
        }

        private void UpdateApiIpAddress(string ipAddress)
        {
            foreach (var item in _localConfig.LocalInBounds)
            {
                if (item.tag == DefaultXRayConfig.ApiTag)
                {
                    item.listen = ipAddress;
                    item.settings.address = ipAddress;
                    break;
                }
            }
        }

        private void UpdateSocksListenAndPort(string ipAddress, int port)
        {
            foreach (var item in _localConfig.LocalInBounds)
            {
                if (item.tag == DefaultXRayConfig.MainSocksTag)
                {
                    item.port = port;
                    item.listen = ipAddress;
                    break;
                }
            }
        }


        private Command? _resetCommand;
        public Command ResetCommand => _resetCommand ??= new Command((param) =>
        {
            SocksPort = DefaultXRayConfig.SocksPort;
            HttpPort = DefaultXRayConfig.HttpPort;
            PacPort = DefaultXRayConfig.PacPort;
            ProxyMode = DefaultXRayConfig.ProxyMode;
            AdBlock = DefaultXRayConfig.AdBlock;
        });

        public bool ProxySetted { get; private set; } = false;
        public void ChangeProxy(bool start)
        {
            if (!start)
            {
                utils.SystemProxy.SetSystemProxy(0, "");
                ProxySetted = false;
                return;
            }

            if (string.Compare(ProxyMode, "pac", StringComparison.OrdinalIgnoreCase) == 0)
            {
                utils.SystemProxy.SetSystemProxy(2, $"http://{IpAddress}:{PacPort}/{DefaultXRayConfig.PacProxyFileName}");
                ProxySetted = true;
            }
            else if (string.Compare(ProxyMode, "global", StringComparison.OrdinalIgnoreCase) == 0)
            {
                utils.SystemProxy.SetSystemProxy(1, $"{IpAddress}:{HttpPort}");
                ProxySetted = true;
            }
            else
            {
                utils.SystemProxy.SetSystemProxy(0, "");
                ProxySetted = false;
            }
        }
    }
}
