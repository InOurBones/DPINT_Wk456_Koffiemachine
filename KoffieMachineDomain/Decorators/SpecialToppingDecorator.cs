using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorators
{
    public class SpecialToppingDecorator : BaseDecorator
    {
        public SpecialToppingDecorator(IDrink drink, string name, Amount amount = Amount.Normal) : base(drink)
        {
            Name = name;
            Amount = amount;
        }

        public override Amount Amount { get; set; }

        public override double Price => 0;

        public override string Name { get; }
    }
}
