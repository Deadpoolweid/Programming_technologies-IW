using System;
// ReSharper disable InconsistentNaming

namespace PT
{
    internal static class Data
    {
        /// <summary>
        /// Используемая функция
        /// </summary>
        public static Func<double, double> f;

        /// <summary>
        /// Левая граница интервала
        /// </summary>
        public static double a;

        /// <summary>
        /// Правая граница интервала
        /// </summary>
        public static double b;

        /// <summary>
        /// Середина интервала
        /// </summary>
        public static double c;

        /// <summary>
        /// Погрешность
        /// </summary>
        public static int e;

        /// <summary>
        /// Искомый корень
        /// </summary>
        public static double x;
    }
}
