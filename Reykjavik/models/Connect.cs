using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reykjavik.models
{
    public class ConnetctBase
    {
        public string Protocol { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
    }
    public class TrojanConnect : ConnetctBase
    {
        TrojanConnect()
        {
            Protocol = "trojan";
        }


    }

    public class VlessConnect : ConnetctBase
    {

    }

    public class SockOption
    {

    }
}
