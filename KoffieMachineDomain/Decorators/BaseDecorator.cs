using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public abstract class BaseDecorator : IDrink
    {
        protected IDrink Drink;

        public abstract double Price { get; }
        public abstract Amount Amount { get; set; }
        public abstract string Name { get; }

        public BaseDecorator(IDrink drink)
        {
            Drink = drink;
        }

        public string GetName() => $"{Drink.GetName()} + {Name}";

        public double GetPrice() => Drink.GetPrice() + Price;

        public virtual void LogDrinkMaking(ICollection<string> log)
        {
            Drink.LogDrinkMaking(log);

            log.Add($"Setting {Name} amount to {Amount}.");
            log.Add($"Adding {Name}...");
        }
    }
}
