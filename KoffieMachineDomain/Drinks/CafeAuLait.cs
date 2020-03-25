using System.Collections.Generic;

namespace KoffieMachineDomain
{
    public class CafeAuLait : BaseDrink
    {
        public override string Name => "Café au Lait";

        public override double Price => 0.5;

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add("Filling half with coffee...");
            log.Add("Filling other half with milk...");
        }
    }
}
