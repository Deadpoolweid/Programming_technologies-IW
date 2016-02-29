using System;

namespace PT
{
    static class Input
    {
        public static void Main(string function,double a, double b, int e)
        {
            Data.sFunction = function;
            Data.f = FunctionCreator.FunctionCreator.BuildFunc(function);
            Data.a = a;
            Data.b = b;
            Data.e = e;
            Data.c = a + (Math.Abs(b - a)/2d);
        }
    }
}
