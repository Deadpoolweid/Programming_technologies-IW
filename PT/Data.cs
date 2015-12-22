using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PT
{
    class Data
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
        public static double e;

        /// <summary>
        /// Искомый корень
        /// </summary>
        public static double x;
    }
}
