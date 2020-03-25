using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Dispenser_Library
{
    public class HotChocolate
    {
        private bool _isDeluxe = false;

        public double Cost()
        {
            return _isDeluxe ? 2.00 : 1.50;
        }

        public IEnumerable<string> GetBuildSteps()
        {
            return new List<string>
            {
                $"Filling with {GetNameOfDrink()}",
            };
        }

        public string GetNameOfDrink()
        {
            return _isDeluxe ? "Hot Chocolate Deluxe" : "Hot Chocolate";
        }

        public void MakeDeluxe()
        {
            _isDeluxe = true;
        }
    }
}
