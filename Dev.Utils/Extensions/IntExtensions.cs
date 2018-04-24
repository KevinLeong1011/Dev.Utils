/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/11/18 18:31:29
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// Throw <see cref="ArgumentException"/> if it is negative.
        /// 如果值为负数，则抛出ArgumentException异常
        /// </summary>
        /// <param name="this"></param>
        /// <param name="name"></param>
        public static void ThrowIfNegative(this int @this, string name)
        {
            if (@this < 0)
            {
                throw new ArgumentException(string.Format("{0} can not be negative.", name));
            }
        }

        /// <summary>
        /// Throw <see cref="ArgumentException"/> if it is negative or equals zero.
        /// 如果值为非正数，则抛出ArgumentException异常
        /// </summary>
        /// <param name="this"></param>
        /// <param name="name"></param>
        public static void ThrowIfNotPositive(this int @this, string name)
        {
            if (@this <= 0)
            {
                throw new ArgumentException(string.Format("{0} should be positive.", name));
            }
        }

        /// <summary>
        /// Coerce into the two values.
        /// 将值限定在指定的两个值之间
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int Coerce(this int value, int min, int max)
        {
            return Math.Max(Math.Min(value, max), min);
        }

        /// <summary>
        /// Get percent string.
        /// 获取百分比字符串
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static string Percent(this int @this)
        {
            return @this * 100 + "%";
        }
    }
}
