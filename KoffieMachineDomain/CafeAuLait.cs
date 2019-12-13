using System.Collections.Generic;

namespace KoffieMachineDomain
{
    public class CafeAuLait : Drink
    {
        public override string Name => "Café au Lait";

        public override double GetPrice()
        {
            return BaseDrinkPrice + 0.5;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add("Filling half with coffee...");
            log.Add("Filling other half with milk...");
            log.Add($"Finished making {Name}");
        }
    }
}
