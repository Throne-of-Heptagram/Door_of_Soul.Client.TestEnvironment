using System.Collections.Generic;

namespace Door_of_Soul.Client.TestEnvironment
{
    public abstract class ScenariosPool
    {
        public static ScenariosPool Instance { get; private set; }
        public static void Initialize(ScenariosPool instance)
        {
            Instance = instance;
        }

        public abstract IEnumerable<ClientTestEnvironment.DoScenarioDelegate> Scenarios { get; }
    }
}
