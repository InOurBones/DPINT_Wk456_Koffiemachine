using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class DrinkFactory
    {
        private Strength _coffeeStrength;
        private Amount _sugarAmount;
        private Amount _milkAmount;

        public Strength CoffeeStrength
        {
            get { return _coffeeStrength; }
            set { _coffeeStrength = value; }
        } 

        public Amount SugarAmount
        {
            get { return _sugarAmount; }
            set { _sugarAmount = value; }
        }

        public Amount MilkAmount
        {
            get { return _milkAmount; }
            set { _milkAmount = value; }
        }

        public DrinkFactory()
        {
            _coffeeStrength = Strength.Normal;
            _sugarAmount = Amount.Normal;
            _milkAmount = Amount.Normal;
        }

        public IDrink CreateDrink(string drinkName, bool hasSugar, bool hasMilk, ICollection<string> log)
        {
            IDrink drink;
            switch (drinkName)
            {
                case "Coffee":
                    drink = new Coffee() { Strength = _coffeeStrength };
                    break;
                case "Espresso":
                    drink = new Espresso();
                    break;
                case "Capuccino":
                    drink = new Capuccino();
                    break;
                case "Wiener Melange":
                    drink = new WienerMelange();
                    break;
                case "Café au Lait":
                    drink = new CafeAuLait();
                    break;
                default:
                    log.Add($"Could not make {drinkName}, recipe not found.");
                    return null;
            }

            if (hasSugar)
                drink = new SugarDecorator(drink);

            if (hasMilk)
                drink = new MilkDecorator(drink);

            return drink;
        }
    }
}
