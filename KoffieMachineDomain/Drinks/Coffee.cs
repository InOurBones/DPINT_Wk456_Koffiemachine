using System.Collections.Generic;

namespace KoffieMachineDomain
{
    public class Coffee : BaseDrink
    {
        public override string Name => "Koffie";

        public Strength Strength { get; set; }

        public override double Price => 0;

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Setting coffee strength to {Strength}.");
            log.Add("Filling with coffee...");
        }
    }
}
