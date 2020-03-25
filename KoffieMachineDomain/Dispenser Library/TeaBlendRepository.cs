using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Dispenser_Library
{
    public class TeaBlendRepository
    {
        private Dictionary<string, TeaBlend> _blends;

        public IEnumerable<string> BlendNames { get { return _blends.Keys; } }

        public TeaBlendRepository()
        {
            _blends = new Dictionary<string, TeaBlend>
            {
                ["Red Tea"] = new TeaBlend(Color.Red, "Red Tea"),
                ["Blue Tea"] = new TeaBlend(Color.Blue, "Blue Tea"),
                ["Green Tea"] = new TeaBlend(Color.Green, "Green Tea"),
            };
        }

        public TeaBlend GetTeaBlend(string teaBlend)
        {
            return _blends[teaBlend];
        }
    }
}
