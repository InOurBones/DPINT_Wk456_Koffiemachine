using GalaSoft.MvvmLight;
using KoffieMachineDomain.Dispenser_Library;
using KoffieMachineDomain.Drinks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class DrinkFactory : ViewModelBase
    {
        private string _drinkName;

        private Strength _coffeeStrength;
        private Amount _sugarAmount;
        private bool _hasSugar;
        private Amount _milkAmount;
        private bool _hasMilk;

        private IDrink _selectedDrink;
        private TeaBlendRepository _teaBlendRepository;

        public Strength CoffeeStrength
        {
            get { return _coffeeStrength; }
            set { _coffeeStrength = value; BrewDrink(); }
        } 

        public Amount SugarAmount
        {
            get { return _sugarAmount; }
            set { _sugarAmount = value; BrewDrink(); }
        }

        public Amount MilkAmount
        {
            get { return _milkAmount; }
            set { _milkAmount = value; BrewDrink(); }
        }

        public string SelectedTeaBlendOption { get; set; }

        public TeaBlendRepository TeaBlendRepository { get { return _teaBlendRepository; } }

        public IDrink SelectedDrink
        {
            get { return _selectedDrink; }
            set { _selectedDrink = value; RaisePropertyChanged(() => SelectedDrink); }
        }

        public DrinkFactory()
        {
            _coffeeStrength = Strength.Normal;
            _sugarAmount = Amount.Normal;
            _milkAmount = Amount.Normal;

            _teaBlendRepository = new TeaBlendRepository();
            SelectedTeaBlendOption = _teaBlendRepository.BlendNames.First();
        }

        public void CreateDrink(string drinkName, ICollection<string> log, bool hasSugar = false, bool hasMilk = false)
        {
            _hasSugar = hasSugar;
            _hasMilk = hasMilk;
            _drinkName = drinkName;
            BrewDrink();
        }

        private void BrewDrink()
        {
            IDrink drink;
            switch (_drinkName)
            {
                case "Coffee":
                    drink = new Coffee() { Strength = CoffeeStrength };
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
                case "Chocolate":
                    drink = new Chocolate();
                    break;
                case "Chocolate Deluxe":
                    drink = new Chocolate(makeDeluxe: true);
                    break;
                case "Tea":
                    TeaBlend teaBlend = _teaBlendRepository.GetTeaBlend(SelectedTeaBlendOption);
                    if (_hasSugar)
                        drink = new TeaDrink(teaBlend, sugeramount: (int)SugarAmount);
                    else
                        drink = new TeaDrink(teaBlend);
                    break;
                default:
                    //log.Add($"Could not make {drinkName}, recipe not found.");
                    return;
            }

            if (_hasSugar)
                drink = new SugarDecorator(drink, _sugarAmount);

            if (_hasMilk)
                drink = new MilkDecorator(drink, _milkAmount);

            SelectedDrink = drink;
        }
    }
}
