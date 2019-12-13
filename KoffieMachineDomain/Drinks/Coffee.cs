using System.Collections.Generic;

namespace KoffieMachineDomain
{
    public class Coffee : BaseDrink
    {
        public virtual Strength DrinkStrength { get; set; }
        public override string Name => "Koffie";

        public override double GetPrice()
        {
            return BaseDrinkPrice;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Setting coffee strength to {DrinkStrength}.");
            log.Add("Filling with coffee...");
        }
    }
}
