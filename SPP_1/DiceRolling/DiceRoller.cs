using System;

namespace SPP_1.DiceRolling
{
    public class DiceRoller : IDiceRoller
    {
        public int Roll(int minValue, int maxValue)
        {
            var random = new Random();
            return random.Next(minValue, maxValue + 1);
        }
    }
}
