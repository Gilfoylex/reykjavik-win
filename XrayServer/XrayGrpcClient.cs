using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Net.Client;
using static Xray.App.Stats.Command.StatsService;

namespace XrayServer
{
    public class XrayGrpcClient
    {
        private GrpcChannel _channel;
        public XrayGrpcClient(uint port = 8080)
        {
            _channel = GrpcChannel.ForAddress($"https://localhost:{port}");
        }

        public String GetStatQuery()
        {
            var client = new StatsServiceClient(_channel);
            return "";
        }
    }
}
