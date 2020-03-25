using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorators
{
    public class TeaBlendDecorator : BaseDecorator
    {
        public TeaBlendDecorator(IDrink drink) : base(drink)
        {

        }

        public override double Price => 0;

        public override Amount Amount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string Name => "TeaBlend";


    }
}
