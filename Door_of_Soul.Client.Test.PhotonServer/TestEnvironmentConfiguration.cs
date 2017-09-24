using System.Collections.Generic;

namespace Door_of_Soul.Client.Test.PhotonServer
{
    public class TestEnvironmentConfiguration
    {
        public static TestEnvironmentConfiguration Instance { get; private set; }
        public static void Initialize(TestEnvironmentConfiguration instance)
        {
            Instance = instance;
        }
        public int TotalLoginServerConnectionCount { get; set; } = 2;
        public List<string> LoginServerAddresses { get; set; } = new List<string> { "127.0.0.1" };
        public List<int> LoginServerPorts { get; set; } = new List<int> { 10028 };
        public List<string> LoginServerApplicationNames { get; set; } = new List<string> { "DS.DevServer.LoginServer" };
        public bool IsTurnOn { get; set; } = false;
    }
}
