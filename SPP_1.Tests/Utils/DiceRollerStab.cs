using SPP_1.DiceRolling;

namespace SPP_1.Tests.Utils
{
    public class DiceRollerStab : IDiceRoller
    {
        private readonly int _valueToReturn;

        public DiceRollerStab(int valueToReturn)
        {
            _valueToReturn = valueToReturn;
        }

        public int Roll(int minValue, int maxValue)
        {
            return _valueToReturn;
        }
    }
}
