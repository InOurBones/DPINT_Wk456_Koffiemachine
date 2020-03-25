using KoffieMachineDomain.Dispenser_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks
{
    public class TeaDrink : BaseDrink
    {
        private Tea _tea;

        public override double Price => _tea.Price;

        public override string Name => _tea.Blend.Name;

        public TeaDrink(TeaBlend teaBlend, int sugeramount = 0)
        {
            _tea = new Tea() { Blend = teaBlend };
            for (int i = 0; i < sugeramount; i++)
            {
                _tea.AddSugar();
            }
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add("Filling with Tea...");
        }
    }
}
