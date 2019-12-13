using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class SugarDecorator : BaseDecorator
    {
        public override double Price => 0.1;

        public override Amount Amount { get; set; }

        public override string Name => "Sugar";

        public SugarDecorator(IDrink drink) : base(drink)
        {

        }
    }
}
