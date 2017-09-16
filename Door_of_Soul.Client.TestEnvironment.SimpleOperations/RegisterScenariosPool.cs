using System;
using System.Collections.Generic;
using Door_of_Soul.Core.Protocol;

namespace Door_of_Soul.Client.TestEnvironment.SimpleOperations
{
    public class RegisterScenariosPool : ScenariosPool
    {
        private List<ClientTestEnvironment.DoScenarioDelegate> scenarios = new List<ClientTestEnvironment.DoScenarioDelegate>();
        public override IEnumerable<ClientTestEnvironment.DoScenarioDelegate> Scenarios { get { return scenarios; } }

        public RegisterScenariosPool()
        {
            scenarios.Add(Register);
        }

        private OperationReturnCode Register(out string errorMessage)
        {
            errorMessage = "";
            return OperationReturnCode.Successiful;
        }
    }
}
