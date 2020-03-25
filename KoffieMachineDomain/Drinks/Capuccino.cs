using System.Collections.Generic;

namespace KoffieMachineDomain
{
    public class Capuccino : BaseDrink
    {
        public override string Name => "Capuccino";

        public Strength Strength { get; set; }

        public override double Price => 0.8;

        public Capuccino()
        {
            Strength = Strength.Normal;
        }

        public override double GetPrice()
        {
            return base.GetPrice();
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Setting coffee strength to {Strength}.");
            log.Add("Filling with coffee...");

            log.Add("Creaming milk...");
            log.Add("Adding milk to coffee...");
        }
    }
}
