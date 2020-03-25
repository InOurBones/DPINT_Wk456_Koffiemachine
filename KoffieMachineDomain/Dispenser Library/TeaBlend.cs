using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Dispenser_Library
{
    public struct TeaBlend
    {
        public TeaBlend(Color bagColor, string name)
        {
            BagColor = bagColor;
            Name = name;
        }

        public Color BagColor;
        public string Name;
    }
}
