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
            SaveLocalConfig();
        });

        private Command? _resetCommand;
        public Command ResetCommand => _resetCommand ??= new Command((param) =>
        {
            SocksPort = DefaultXRayConfig.SocksPort;
            HttpPort = DefaultXRayConfig.HttpPort;
            PacPort = DefaultXRayConfig.PacPort;
            ProxyMode = DefaultXRayConfig.ProxyMode;
            AdBlock = DefaultXRayConfig.AdBlock;
        });
    }
}
