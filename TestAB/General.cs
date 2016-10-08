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

    }
}
