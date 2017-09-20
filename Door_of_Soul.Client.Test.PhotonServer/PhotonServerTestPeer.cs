using Door_of_Soul.Communication.Client;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Core.Protocol;
using Photon.SocketServer;
using Photon.SocketServer.ServerToServer;
using PhotonHostRuntimeInterfaces;
using System.Collections.Generic;

namespace Door_of_Soul.Client.Test.PhotonServer
{
    public class PhotonServerTestPeer : OutboundS2SPeer
    {
        public PhotonServerTestPeer(ApplicationBase application) : base(application)
        {
        }

        protected override void OnConnectionEstablished(object responseObject)
        {
            TestClientApplication.ConnectedPeerCounter++;
            TestClientApplication.Log.Info($"Server ConnectionEstablished");
        }

        protected override void OnConnectionFailed(int errorCode, string errorMessage)
        {
            TestClientApplication.Log.Info($"Server ConnectionFailed");
        }

        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            TestClientApplication.Log.Info($"Server Disconnect");
        }

        protected override void OnEvent(IEventData eventData, SendParameters sendParameters)
        {
            DeviceEventCode eventCode = (DeviceEventCode)eventData.Code;
            Dictionary<byte, object> parameters = eventData.Parameters;

            string errorMessage;
            if (!CommunicationService.Instance.HandleEvent(eventCode, parameters, out errorMessage))
            {
                TestClientApplication.Log.Info($"Event Fail, ErrorMessage: {errorMessage}");
            }
        }

        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            TestClientApplication.Log.Error($"Server OperationRequest");
        }

        protected override void OnOperationResponse(OperationResponse operationResponse, SendParameters sendParameters)
        {
            DeviceOperationCode operationCode = (DeviceOperationCode)operationResponse.OperationCode;
            OperationReturnCode returnCode = (OperationReturnCode)operationResponse.ReturnCode;
            string operationMessage = operationResponse.DebugMessage;
            Dictionary<byte, object> parameters = operationResponse.Parameters;

            string errorMessage;
            if (!CommunicationService.Instance.HandleOperationResponse(operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                TestClientApplication.Log.Info($"OperationResponse Fail, ErrorMessage: {errorMessage}");
            }
        }
    }
}
