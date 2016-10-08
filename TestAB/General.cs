using System;

namespace TestAB
{
    public static class General
    {
        public const int DEF_DELAY = 1000;

        public static long GetTicks(DateTime dTime)
        {
            return dTime.Ticks;
        }

        public static int GetRandom()
        {
            Random rand = new Random();
            return rand.Next(1000);
        }

    }
}
