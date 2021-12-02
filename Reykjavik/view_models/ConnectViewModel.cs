using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace Reykjavik.view_models
{
   
    public class ConnectViewModel : BaseViewModel
    {
        #region 基础设置

        private string _tagName = "";
        public string TagName
        {
            get => _tagName;
            set => SetProperty(ref _tagName, value);
        }

        private string _protocol = "vless"; // vless | trojan

        public string Protocol
        {
            get => _protocol;
            set => SetProperty(ref _protocol, value);
        }

        private string _address = "";

        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }

        private int _port = 443;
        public int Port
        {
            get => _port;
            set => SetProperty(ref _port, value);
        }

        // 多路复用
        private bool _mux = false;

        public bool Mux
        {
            get => _mux;
            set => SetProperty(ref _mux, value);
        }

        // 快速打开
        private bool _fastOpen = false;

        public bool FastOpen
        {
            get => _fastOpen;
            set => SetProperty(ref _fastOpen, value);
        }

        #endregion


        #region vless的特殊配置

        private string _uuid = "";

        public string UUID
        {
            get => _uuid;
            set => SetProperty(ref _uuid, value);
        }


        #endregion

        #region trojan的特殊配置

        private string _password = "";

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }


        #endregion

        #region 流设置
        private string _netWork = "tcp"; // tcp | ws

        public string Network
        {
            get => _netWork;
            set => SetProperty(ref _netWork, value);
        }

        private string _security = "tls"; // none | tls | xtls
        public string Security
        {
            get => _security;
            set => SetProperty(ref _security, value);
        }

        private bool _xtlsDirect = false;

        public bool XTlsDirect
        {
            get => _xtlsDirect;
            set => SetProperty(ref _xtlsDirect, value);
        }

        private string _tlsServerAddress = "";

        public string TlsServerAddress
        {
            get => _tlsServerAddress;
            set => SetProperty(ref _tlsServerAddress, value);
        }

        // 允许不安全
        private bool _allowInsecure = false;

        public bool AllowInsecure
        {
            get => _allowInsecure;
            set => SetProperty(ref _allowInsecure, value);
        }

        #endregion

        #region websock设置

        private string _wsPath = "";

        public string WsPath
        {
            get => _wsPath;
            set => SetProperty(ref _wsPath, value);
        }

        #endregion


        private Command? _protocolCommand;

        public Command ProtocolCommand => _protocolCommand ??= new Command((param) =>
        {
            if (param is not string protocol)
                return;

            Protocol = protocol;
        });

        private Command? _networkCommand;

        public Command NetworkCommand => _networkCommand ??= new Command((param) =>
        {
            if (param is not string network) 
                return;

            Network = network;
        });

        private Command? _securityCommand;

        public Command SecurityCommand => _securityCommand ??= new Command((param) =>
        {
            if (param is not string security)
                return;

            Security = security;
        });

        public void CopySettings(ConnectViewModel other)
        {
            TagName = other.TagName;
            Protocol = other.Protocol;
            Address = other.Address;
            Port = other.Port;
            UUID = other.UUID;
            Password = other.Password;
            Mux = other.Mux;
            FastOpen = other.FastOpen;
            Network = other.Network;
            Security = other.Security;
            XTlsDirect = other.XTlsDirect;
            TlsServerAddress = other.TlsServerAddress;
            AllowInsecure = other.AllowInsecure;
            WsPath = other.WsPath;
        }
    }
}
