using System.Collections.Generic;

namespace KoffieMachineDomain
{
    public class Espresso : BaseDrink
    {
        public override string Name => "Espresso";

        public Strength Strength => Strength.Strong;

        public Amount Amount => Amount.Few;

        public override double Price => 0.7;

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Setting coffee strength to {Strength}.");
            log.Add($"Setting coffee amount to {Amount}.");
            log.Add("Filling with coffee...");

            log.Add("Creaming milk...");
            log.Add("Adding milk to coffee...");
        }
    }
}
