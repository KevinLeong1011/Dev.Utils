/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/11/18 18:29:19
 * ***********************************************/
using System;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// 如果值为非正数，则抛出ArgumentException异常
        /// </summary>
        /// <param name="this"></param>
        /// <param name="name"></param>
        public static void ThrowIfNotPositive(this double @this, string name)
        {
            if (@this <= 0.0)
            {
                throw new ArgumentException(string.Format("{0} should be positive.", name));
            }
        }

        /// <summary>
        /// 如果值为负数，则抛出ArgumentException异常
        /// </summary>
        /// <param name="this"></param>
        /// <param name="name"></param>
        public static void ThrowIfNegative(this double @this, string name)
        {
            if (@this < 0.0)
            {
                throw new ArgumentException(string.Format("{0} can not be negative.", name));
            }
        }

        /// <summary>
        /// 将值限定在指定的两个值之间
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static double Coerce(this double value, double min, double max)
        {
            return Math.Max(Math.Min(value, max), min);
        }

        /// <summary>
        /// 判断是否介于指定的两个数值之间
        /// </summary>
        /// <param name="n"></param>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static bool Between(this double n, double n1, double n2)
        {
            return n <= Math.Max(n1, n2) && n >= Math.Min(n1, n2);
        }
    }
}
