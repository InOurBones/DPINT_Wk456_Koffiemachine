using System.Collections.Generic;

namespace KoffieMachineDomain
{
    public class Espresso : BaseDrink
    {
        public override string Name => "Espresso";

        public override double GetPrice()
        {
            return BaseDrinkPrice + 0.7;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Setting coffee strength to {Strength.Strong}.");
            log.Add($"Setting coffee amount to {Amount.Few}.");
            log.Add("Filling with coffee...");

            log.Add("Creaming milk...");
            log.Add("Adding milk to coffee...");
        }
    }
}
