using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reykjavik.models.XRayConfigDefine;

namespace Reykjavik.models
{
    public static class DefaultXRayConfig
    {
        public static Log LogConfig = new()
        {
#if DEBUG
            loglevel = "debug"
#else 
            loglevel = "info"
#endif
        };


        public static Api ApiConfig = new()
        {
            tag = "api",
            services = new() { "StatsService" }
        };

        // 流量统计
        public static Rule ApiRule = new()
            { inboundTag = new List<string> { "api" }, outboundTag = "api", type = "field" };

        // 拦截广告域名
        public static Rule ADBlockRule = new()
        {
            outboundTag = "block",
            type = "field",
            domain = new List<string> { "geosite:category-ads-all" }
        };

        // 大陆域名直出
        public static Rule CNDirectRule = new()
        {
            outboundTag = "direct_out",
            type = "field",
            domain = new List<string> { "geosite:cn" }
        };

        public static Routing RoutingConfig = new()
        {
            rules = new List<Rule> { ApiRule, CNDirectRule, ADBlockRule },
            domainStrategy = "AsIs"
        };

        public static Policy PolicyConfig = new()
        {
            levels = new Dictionary<string, Level>
            {
                {"0", new Level()}
            },
            PolicySystem = new PolicySystem()
        };

        // 本地入站规则， "HTTP" | "Socks"| "Dokodemo-door"
        // socks 必备，作为整个代理程序的入口
        // http用于全局代理
        // Dokodemo-door 任意门，用于查询xray中的流量统计
        public static List<XRayConfigDefine.Inbound> InBoundConfigs { get; set; } = new()
        {
            new Inbound()
            {
                tag = "main_socks",
                listen = "127.0.0.1",
                port = SocksPort,
                protocol = "socks",
                settings = new SocksIN()
                {
                    udp = true
                }
            },
            new Inbound
            {
                tag = "main_http",
                listen = "127.0.0.1",
                port = HttpPort,
                protocol = "http",
                settings = new HttpIN()
            },
            new Inbound
            {
                tag = "api",
                listen = "127.0.0.1",
                port = 2337,
                protocol = "dokodemo-door",
                settings = new DokodemoDoor
                {
                    address = "127.0.0.1"
                }
            }
        };


        // 默认必须有的出站
        public static List<Outbound> OutboundConfigs = new()
        {
            // 自由出口
            new Outbound
            {
                tag = "direct_out",
                protocol = "freedom"
            },
            // 出到黑洞，用于广告拦截 一定要放到最后一个
            new Outbound
            {
                tag = "block",
                protocol = "blackhole"
            }
        };


        public const bool AdBlock = true;

        public const string ProxyMode = "pac";

        public const int SocksPort = 2334;
        public const int HttpPort = 2335;
        public const int PacPort = 2336;
    }
}
