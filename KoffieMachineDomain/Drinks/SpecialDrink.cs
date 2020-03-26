using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks
{
    public class SpecialDrink : BaseDrink
    {
        public override double Price { get; } 

        public override string Name { get; }

        public List<string> Ingredients { get; set; }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            foreach (string text in Ingredients)
            {
                log.Add($"Fill with {text}...");
            }
        }

        public SpecialDrink(string name, List<string> ingredients, double price)
        {
            Name = name;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
