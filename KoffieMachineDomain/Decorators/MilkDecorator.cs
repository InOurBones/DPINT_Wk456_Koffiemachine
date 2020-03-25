using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class MilkDecorator : BaseDecorator
    {
        public override double Price => 0.15;

        public override Amount Amount { get; set; }

        public override string Name => "Milk";

        public MilkDecorator(IDrink drink, Amount amount) : base(drink)
        {
            Amount = amount;
        }
    }
}
