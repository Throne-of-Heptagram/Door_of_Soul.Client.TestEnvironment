using Door_of_Soul.Communication.Client;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Core.Client;
using Photon.SocketServer;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Client.Test.PhotonServer
{
    class PhotonServerClientCommunicationService : CommunicationService
    {
        public override bool ConnectServer(string serverAddress, int port, string applicationName)
        {
            throw new NotImplementedException("Should be done in SetupCommunication");
        }

        public override void DisconnectServer(string applicationName)
        {
            foreach (var peer in PhotonServerClientTestEnvironment.AllPeers)
            {
                peer.Disconnect();
            }
        }

        public override bool FindAnswer(int answerId, out VirtualAnswer answer)
        {
            throw new NotImplementedException();
        }

        public override bool FindAvatar(int avatarId, out VirtualAvatar avatar)
        {
            throw new NotImplementedException();
        }

        public override bool FindScene(int sceneId, out VirtualScene scene)
        {
            throw new NotImplementedException();
        }

        public override bool FindSoul(int soulId, out VirtualSoul soul)
        {
            throw new NotImplementedException();
        }

        public override bool FindWorld(int worldId, out VirtualWorld world)
        {
            throw new NotImplementedException();
        }

        public override void Process()
        {
            throw new NotImplementedException();
        }

        public override void SendOperation(string applicationName, DeviceOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            OperationRequest request = new OperationRequest
            {
                OperationCode = (byte)operationCode,
                Parameters = parameters
            };
            PhotonServerClientTestEnvironment.RandomPeer.SendOperationRequest(request, new SendParameters());
        }
    }
}
