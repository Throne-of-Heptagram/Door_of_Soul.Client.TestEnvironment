using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Door_of_Soul.Client.Test.PhotonServer
{
    public class TestEnvironmentConfiguration
    {
        public static TestEnvironmentConfiguration Instance { get; private set; }
        public static void Initialize(TestEnvironmentConfiguration instance)
        {
            Instance = instance;
        }
        public int TotalProxyServerConnectionCount { get; set; } = 2;
        public List<string> ProxyServerAddresses { get; set; } = new List<string> { "127.0.0.1" };
        public List<int> ProxyServerPorts { get; set; } = new List<int> { 10027 };
        public List<string> ProxyServerApplicationNames { get; set; } = new List<string> { "DS.DevServer.ProxyServer" };
        public int SetupConnectionDelay { get; set; } = 20000;
    }
}
