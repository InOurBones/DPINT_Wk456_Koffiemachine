using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public interface IDrink
    {
        double Price { get; }

        string Name { get; }

        double GetPrice();

        string GetName();

        void LogDrinkMaking(ICollection<string> log);
    }
}
