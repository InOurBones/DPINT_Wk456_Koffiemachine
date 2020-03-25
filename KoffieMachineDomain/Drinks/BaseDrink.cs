using System.Collections.Generic;

namespace KoffieMachineDomain
{
    public abstract class BaseDrink : IDrink
    {
        protected const double BaseDrinkPrice = 1.0;

        public abstract double Price { get; }

        public abstract string Name { get; }

        public string GetName() => Name;

        public virtual double GetPrice()
        {
            return BaseDrinkPrice + Price;
        }

        public virtual void LogDrinkMaking(ICollection<string> log)
        {
            log.Add($"Making {Name}...");
            log.Add($"Heating up...");
        }
    }
}
