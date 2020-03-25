using KoffieMachineDomain.Dispenser_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Drinks
{
    public class Chocolate : BaseDrink
    {
        private HotChocolate _choco;

        public override double Price => _choco.Cost();

        public override string Name => _choco.GetNameOfDrink();

        public Chocolate(bool makeDeluxe = false)
        {
            _choco = new HotChocolate();
            if (makeDeluxe) _choco.MakeDeluxe();
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            foreach(string text in _choco.GetBuildSteps())
            {
                log.Add(text);
            }
        }
    }
}
