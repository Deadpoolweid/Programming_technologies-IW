using System;

namespace PT
{
    static class Input
    {
        public static void Main(string function,double a, double b, int e)
        {
            Data.sFunction = function;
            Data.progress += 10;
            Data.f = FunctionCreator.FunctionCreator.BuildFunc(function);
            Data.progress += 10;
            Data.a = a;
            Data.progress += 10;
            Data.b = b;
            Data.progress += 10;
            Data.e = e;
            Data.progress += 10;
            Data.c = a + (Math.Abs(b - a)/2d);
            Data.progress += 10;
        }
    }
}
