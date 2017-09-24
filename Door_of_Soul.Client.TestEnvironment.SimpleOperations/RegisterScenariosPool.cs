using Door_of_Soul.Core.Client;
using System.Collections.Generic;

namespace Door_of_Soul.Client.TestEnvironment.SimpleOperations
{
    public class RegisterScenariosPool : ScenariosPool
    {
        private List<ClientTestEnvironment.DoScenarioDelegate> scenarios = new List<ClientTestEnvironment.DoScenarioDelegate>();
        public override IEnumerable<ClientTestEnvironment.DoScenarioDelegate> Scenarios { get { return scenarios; } }

        public RegisterScenariosPool()
        {
            for(int i = 0; i < 4000; i++)
            {
                int id = i / 4;
                scenarios.Add((out string errorMessage) => 
                {
                    return VirtualSystem.Instance.Register($"TestAnswer{id}", $"TestAnswer{id}", out errorMessage);
                });
            }
        }
    }
}
