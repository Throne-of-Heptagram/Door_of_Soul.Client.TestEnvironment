using Door_of_Soul.Client.TestEnvironment;
using ExitGames.Logging;
using Photon.SocketServer;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Door_of_Soul.Client.Test.PhotonServer
{
    public class TestClientApplication : ApplicationBase
    {
        public static readonly ILogger Log = LogManager.GetCurrentClassLogger();
        private static int connectedPeerCounter = 0;
        private static object connectedPeerCounterLock = new object();
        public static int ConnectedPeerCounter
        {
            get { return connectedPeerCounter; }
            set
            {
                lock(connectedPeerCounterLock)
                {
                    connectedPeerCounter++;
                }
            }
        }

        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            throw new NotImplementedException();
        }

        protected override void Setup()
        {
            ClientTestEnvironment.Initialize(new PhotonServerClientTestEnvironment());
            string errorMessage;
            if (ClientTestEnvironment.Instance.Setup(out errorMessage))
            {
                Log.Info("TestClientApplication Setup.");
            }
            else
            {
                Log.Fatal(errorMessage);
                TearDown();
                return;
            }

            Task.Run(() => 
            {
                while (ConnectedPeerCounter != TestEnvironmentConfiguration.Instance.TotalLoginServerConnectionCount)
                {
                    Thread.Sleep(50);
                }
                foreach (string operationResult in ClientTestEnvironment.Instance.StartExecuteScenarios())
                {

                }
            });
        }

        protected override void TearDown()
        {
            ClientTestEnvironment.Instance.TearDown();
            Log.Info("Server TearDown.");
        }
    }
}
