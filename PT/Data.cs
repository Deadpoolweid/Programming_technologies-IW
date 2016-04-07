using System;
using System.Windows.Forms;

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
        /// Текст используемой функции
        /// </summary>
        public static string sFunction;

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

        /// <summary>
        /// Прогресс вычисления
        /// </summary>
        public static int progress
        {
            get { return p; }
            set
            {
                p = value;
                mainform.progress = value;
            }
        }

        private static int p;

        public static MainForm mainform;
    }
}
