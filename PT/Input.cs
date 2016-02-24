using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Functions;

namespace PT
{
    class Input
    {
        static public void main(string function,double a, double b, int e)
        {
            Data.f = FunctionCreator.buildFunc(function);
            Data.a = a;
            Data.b = b;
            Data.e = e;
            Data.c = a + (Math.Abs(b - a)/2d);
        }
    }
}
