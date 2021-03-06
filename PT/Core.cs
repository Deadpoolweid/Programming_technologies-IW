﻿using System;

namespace PT
{
    class Core
    {
        /// <summary>
        /// Расчитывает коэффициент А
        /// </summary>
        /// <returns></returns>
        static double A()
        {
            return (((Data.f(Data.b) - Data.f(Data.c)) / (Data.b - Data.c)) - (Data.f(Data.c) - Data.f(Data.a)) / (Data.c - Data.a)) / (Data.b - Data.a);
        }
        /// <summary>
        /// Расчитывает коэффициент B
        /// </summary>
        /// <returns></returns>
        static double B()
        {
            return (Data.f(Data.c) - Data.f(Data.a)) / (Data.c - Data.a) + ((((Data.f(Data.b) - Data.f(Data.c)) / (Data.b - Data.c)) - ((Data.f(Data.c) - Data.f(Data.a)) / (Data.c - Data.a))) / (Data.b - Data.a)) * (Data.a - Data.c);
        }
        /// <summary>
        /// Расчитывает коэффициент C
        /// </summary>
        /// <returns></returns>
        static double C()
        {
            return Data.f(Data.a);
        }

        /// <summary>
        /// Находит x
        /// </summary>
        /// <returns></returns>
        static public void Find_x()
        {
            double max = Math.Sqrt(B() * B() - 4 * A() * C());
            Data.progress += 10;
            if (B() + max > B() - max)
            {
                Data.x =  Data.a - (2 * C() / (B() + max));
            }
            else
            {
                Data.x = Data.a - (2 * C() / (B() - max));

            }
            Data.progress += 10;
        }

    }
}
