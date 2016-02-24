using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT
{
    class Output
    {
        public static double main()
        {
            if (Data.x < Data.a || Data.x > Data.b)
            {
                return double.NaN;
            }
            return Math.Round(Data.x,Data.e);
        }
    }
}
