using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Reykjavik.utils
{
    internal class SystemProxy
    {
        [DllImport("systemproxy")]
        public static extern int SetSystemProxy(int method, string server);
    }
}
