using System;

namespace PT
{
    static class Output
    {
        public static double Main()
        {
            if (Data.x < Data.a || Data.x > Data.b)
            {
                return double.NaN;
            }
            return Math.Round(Data.x,Data.e);
        }
    }
}
