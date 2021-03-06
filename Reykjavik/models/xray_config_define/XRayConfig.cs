using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Reykjavik.models.XRayConfigDefine
{
    public class Log
    {
        public string? access { get; set; }
        public string? error { get; set; }
        public string? loglevel { get; set; }
        public bool? dnsLog { get; set; }
    }

    public class Api
    {
        public string tag { get; set; } = "api";
        public List<string> services { get; set; } = new() {"HandlerService", "LoggerService", "StatsService"};
    }

    public class Dns
    {
    }

    public class Balancer
    {
        public string tag { get; set; }
        public List<string> selector { get; set; }
    }

    public class Routing
    {
        public string domainStrategy { get; set; }
        public List<Rule> rules { get; set; }
        public List<Balancer> balancers { get; set; }
    }

    public class Rule
    {
        public string type { get; set; }
        public List<string> domain { get; set; }
        public List<string> ip { get; set; }
        public string port { get; set; }
        public string sourcePort { get; set; }
        public string network { get; set; }
        public List<string> source { get; set; }
        public List<string> user { get; set; }
        public List<string> inboundTag { get; set; }
        public List<string> protocol { get; set; }
        public string attrs { get; set; }
        public string outboundTag { get; set; }
        public string balancerTag { get; set; }
    }

    public class Level
    {
        public int? handshake { get; set; }
        public int? connIdle { get; set; }
        public int? uplinkOnly { get; set; }
        public int? downlinkOnly { get; set; }
        public bool statsUserUplink { get; set; } = true;
        public bool statsUserDownlink { get; set; } = true;
        public int? bufferSize { get; set; }
    }

    public class PolicySystem
    {
        public bool statsInboundUplink { get; set; } = true;
        public bool statsInboundDownlink { get; set; } = true;
        public bool statsOutboundUplink { get; set; } = true;
        public bool statsOutboundDownlink { get; set; } = true;
    }

    public class Policy
    {
        public Dictionary<string, Level> levels { get; set; }
        [JsonPropertyName("system")]
        public PolicySystem PolicySystem { get; set; }
    }

    public class Transport
    {
    }

    public class Stats
    {
    }

    // TODO
    public class Reverse
    {
    }

    // TODO
    public class Fakedns
    {
    }

    #region 传输协议
    public class TlsSettings
    {
        public string serverName { get; set; } = "";
        public bool? rejectUnknownSni { get; set; }
        public bool allowInsecure { get; set; } = false; //是否允许不安全连接（仅用于客户端）。默认值为 false。
        public List<string>? alpn { get; set; }
        public string? minVersion { get; set; }
        public string? maxVersion { get; set; }
        public string? cipherSuites { get; set; }

        // todo
        public List<object>? certificates { get; set; }
        public bool? disableSystemRoot { get; set; }
        public bool? enableSessionResumption { get; set; }
        public string? fingerprint { get; set; }
    }

    public class TcpSettings
    {
        public bool acceptProxyProtocol { get; set; } = false;
        public Dictionary<string, string>? headers { get; set; }
    }

    public class KcpSettings
    {
        public int? mtu { get; set; }
        public int? tti { get; set; }
        public int? uplinkCapacity { get; set; }
        public int? downlinkCapacity { get; set; }
        public bool? congestion { get; set; }
        public int? readBufferSize { get; set; }
        public int? writeBufferSize { get; set; }
        public Dictionary<string, string>? headers { get; set; }
        public string? seed { get; set; }
    }

    public class WsSettings
    {
        //public bool acceptProxyProtocol { get; set; } = true; // 仅仅用于inbound中
        public string path { get; set; } = "";
        public Dictionary<string, string>? headers { get; set; }
    }

    public class HttpSettings
    {
        public List<string> host { get; set; }
        public string path { get; set; }
        public int read_idle_timeout { get; set; }
        public int health_check_timeout { get; set; }
    }

    // TODO 暂时不用
    public class QuicSettings
    {
    }

    // TODO 暂时不用
    public class DsSettings
    {
    }

    // TODO 暂时不用
    public class GrpcSettings
    {
    }
    #endregion


    public class Sockopt
    {
        public int? mark { get; set; }
        public bool tcpFastOpen { get; set; } = false;
        public string? tproxy { get; set; }
        public string? domainStrategy { get; set; }
        public string? dialerProxy { get; set; }
        public bool? acceptProxyProtocol { get; set; }
    }

    public class StreamSettings
    {
        // network: "tcp" | "kcp" | "ws" | "http" | "domainsocket" | "quic" | "grpc"
        public string network { get; set; } = "tcp";

        // security: "none" | "tls" | "xtls"
        public string security { get; set; } = "none";
        public TlsSettings? tlsSettings { get; set; }
        public TlsSettings? xtlsSettings { get; set; }
        public TcpSettings? tcpSettings { get; set; }
        public KcpSettings? kcpSettings { get; set; }
        public WsSettings? wsSettings { get; set; }
        public HttpSettings? httpSettings { get; set; }
        public QuicSettings? quicSettings { get; set; }
        public DsSettings? dsSettings { get; set; }
        public GrpcSettings? grpcSettings { get; set; }
        public Sockopt sockopt { get; set; } = new Sockopt();
    }

    public class Sniffing
    {
        public bool enabled { get; set; }
        public List<string> destOverride { get; set; }
    }

    public class Allocate
    {
        public string strategy { get; set; }
        public int refresh { get; set; }
        public int concurrency { get; set; }
    }

    #region 入站协议列表
    // 只列举了常用的几个。
    // 完整协议列表：https://xtls.github.io/config/inbounds/#%E5%8D%8F%E8%AE%AE%E5%88%97%E8%A1%A8

    public class InboundSettings
    {
        // Dokodemo-Door
        public string? address { get; set; }
        public int? port { get; set; }
        public string? network { get; set; }
        public int? timeout { get; set; }
        public bool? followRedirect { get; set; }
        public int? userLevel { get; set; }

        // Http
        //public int? timeout { get; set; }
        public List<Account>? accounts { get; set; }
        public bool? allowTransparent { get; set; }
        //public int userLevel { get; set; }

        // socks
        public string? auth { get; set; }
        //public List<Account>? accounts { get; set; }
        public bool? udp { get; set; }
        public string? ip { get; set; }
        //public int userLevel { get; set; } = 0;
    }

    public class Account
    {
        public string user { get; set; }
        public string pass { get; set; }
    }

    #endregion

    public class Inbound
    {
        public string listen { get; set; }
        public int port { get; set; }
        public string protocol { get; set; } // "Dokodemo-door" | "HTTP" | "Socks" | "VLESS" | "VMess" | "Trojan"
        public InboundSettings settings { get; set; }
        public StreamSettings streamSettings { get; set; }
        public string tag { get; set; }
        public Sniffing sniffing { get; set; }
        public Allocate allocate { get; set; }
    }

    public class ProxySettings
    {
        public string tag { get; set; }
    }

    public class Mux
    {
        public bool enabled { get; set; } = false;
        public int concurrency { get; set; } = 8;
    }

    #region 出站协议

    public class User : Account
    {
        public int level { get; set; }
    }

    public class Response
    {
        public string type { get; set; }
    }

    public class Blackhole
    {
        public Response response { get; set; }
    }

    public class Freedom
    {
        public string domainStrategy { get; set; }
        public string redirect { get; set; }
        public int userLevel { get; set; }
    }


    public class TrojanServer
    {
        public string address { get; set; }
        public int port { get; set; }
        public string password { get; set; }
        public string? email { get; set; }
        public string? flow { get; set; }
        public int level { get; set; }
    }


    public class VLessUser
    {
        public string id { get; set; }
        public string encryption { get; set; } = "none";
        public string? flow { get; set; }
        public int level { get; set; } = 0;
    }

    public class VnextVless
    {
        public string address { get; set; }
        public int port { get; set; }
        public List<VLessUser> users { get; set; } = new List<VLessUser>();
    }

    public class OutboundSettings
    {
        // blackhold
        public Response? response { get; set; }

        // freedom
        public string? domainStrategy { get; set; }
        public string? redirect { get; set; }
        public int? userLevel { get; set; }

        // vless
        public List<VnextVless>? vnext { get; set; }

        // trojan
        public List<TrojanServer>? servers { get; set; }

    }

    #endregion

    public class Outbound
    {
        public string? sendThrough { get; set; }
        public string protocol { get; set; } = "";
        public OutboundSettings? settings { get; set; }
        public string tag { get; set; } = "";
        public StreamSettings? streamSettings { get; set; }
        public ProxySettings? proxySettings { get; set; }
        public Mux? mux { get; set; }
    }

    public class XRayConfig
    {
        public Log log { get; set; }
        public Api api { get; set; }
        public Dns dns { get; set; }
        public Routing routing { get; set; }
        public Policy policy { get; set; }
        public List<Inbound> inbounds { get; set; }
        public List<Outbound> outbounds { get; set; }
        public Transport transport { get; set; }
        public Stats stats { get; set; } = new(); // rpc api接口需要用到
        public Reverse reverse { get; set; }
        public Fakedns fakedns { get; set; }
    }
}
