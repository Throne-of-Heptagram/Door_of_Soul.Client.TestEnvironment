using Door_of_Soul.Client.TestEnvironment;
using ExitGames.Logging;
using Photon.SocketServer;
using System;

namespace Door_of_Soul.Client.Test.PhotonServer
{
    public class TestClientApplication : ApplicationBase
    {
        public static readonly ILogger Log = LogManager.GetCurrentClassLogger();

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
            }
            foreach(string operationResult in ClientTestEnvironment.Instance.StartExecuteScenarios())
            {
                Log.Info($"DoScenarios {operationResult}");
            }
        }

        protected override void TearDown()
        {
            ClientTestEnvironment.Instance.TearDown();
            Log.Info("Server TearDown.");
        }
    }
}
