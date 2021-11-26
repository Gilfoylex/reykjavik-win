using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reykjavik.models.XRayConfigDefine;

namespace Reykjavik.models
{
    public class LocalConfig
    {
        public string PacAddress { get; set; } = "127.0.0.1";
        public int PacPort { get; set; } = 2334;

        // 本地入站规则， "HTTP" | "Socks"| "Dokodemo-door"
        // socks 必备，作为整个代理程序的入口
        // http用于全局代理
        // Dokodemo-door 任意门，用于查询xray中的流量统计
        public List<XRayConfigDefine.Inbound> LocalInBounds { get; set; } = DefaultXRayConfig.InBoundConfigs;

        //本地必要的一些出站规则
        public List<Outbound> LocalOutBounds { get; set; } = DefaultXRayConfig.OutboundConfigs;
    }
}
