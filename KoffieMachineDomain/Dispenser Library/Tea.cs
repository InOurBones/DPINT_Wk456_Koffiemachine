using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Dispenser_Library
{
    public class Tea
    {
        private int _amountOfSugar;
        private TeaBlend _blend;

        public float Price => 1;

        public TeaBlend Blend
        {
            get { return _blend; }
            set { _blend = value; }
        }

        public int AmountOfSugar
        {
            get { return _amountOfSugar; }
            set { _amountOfSugar = value; }
        }

        public void AddSugar()
        {
            AmountOfSugar = 1;
        }

        public void RemoveSugar()
        {
            AmountOfSugar = 0;
        }
    }
}
