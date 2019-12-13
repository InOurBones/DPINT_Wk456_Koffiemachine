using System.Collections.Generic;

namespace KoffieMachineDomain
{
    public abstract class BaseDrink : IDrink
    {
        protected const double BaseDrinkPrice = 1.0;

        public virtual double Price { get; set; }
        public virtual Strength Strength { get; set; }
        public virtual string Name { get; set; }

        public string GetName() => Name;

        public abstract double GetPrice();

        public virtual void LogDrinkMaking(ICollection<string> log)
        {
            log.Add($"Making {Name}...");
            log.Add($"Heating up...");
        }
    }
}
