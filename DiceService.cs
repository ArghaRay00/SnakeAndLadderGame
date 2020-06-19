using System;
namespace snake_ladder
{
    class DiceService
    {
        public static int roll()
        {
            Random random = new Random();
            return random.Next(6) + 1;
        }
    }
}