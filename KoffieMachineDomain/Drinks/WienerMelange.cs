namespace KoffieMachineDomain
{
    public class WienerMelange : Capuccino
    {
        public override string Name => "Wiener Melange";

        public WienerMelange()
        {
            Strength = Strength.Weak;
        }

        public override double GetPrice()
        {
            return BaseDrinkPrice * 2;
        }
    }
}
