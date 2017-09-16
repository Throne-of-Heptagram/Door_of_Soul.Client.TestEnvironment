using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Client.TestEnvironment
{
    public abstract class ClientTestEnvironment
    {
        public delegate OperationReturnCode DoScenarioDelegate(out string errorMessage);

        public static ClientTestEnvironment Instance { get; private set; }
        public static void Initialize(ClientTestEnvironment instance)
        {
            Instance = instance;
        }

        public bool Setup(out string errorMessage)
        {
            if (!SetupLog(out errorMessage))
            {
                return false;
            }
            if (!SetupConfiguration(out errorMessage))
            {
                return false;
            }
            if (!SetupCommunication(out errorMessage))
            {
                return false;
            }
            if (!SetupEnvironment(out errorMessage))
            {
                return false;
            }
            return true;
        }
        public abstract void TearDown();

        public abstract bool SetupLog(out string errorMessage);
        public abstract bool SetupConfiguration(out string errorMessage);
        public abstract bool SetupCommunication(out string errorMessage);
        public abstract bool SetupEnvironment(out string errorMessage);
        public IEnumerable<string> StartExecuteScenarios()
        {
            foreach(var scenarioAction in ScenariosPool.Instance.Scenarios)
            {
                string errorMessage;
                OperationReturnCode returnCode = DoScenario(scenarioAction, out errorMessage);
                yield return $"{returnCode} : {errorMessage}";
            }
        }
        public OperationReturnCode DoScenario(DoScenarioDelegate scenarioAction, out string errorMessage)
        {
            OperationReturnCode returnCode = OperationReturnCode.Successiful;
            try
            {
                returnCode = scenarioAction(out errorMessage);
            }
            catch (Exception exception)
            {
                returnCode = OperationReturnCode.UndefinedError;
                errorMessage = $"Unknown Scenario Failed Message:{exception.Message}, StackTrace:{exception.StackTrace}";
            }
            return returnCode;
        }
    }
}
