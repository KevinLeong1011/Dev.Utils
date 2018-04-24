/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/11/18 18:30:28
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public static class FloatExtensions
    {
        /// <summary>
        /// 如果值为非正数，则抛出ArgumentException异常
        /// </summary>
        /// <param name="this"></param>
        /// <param name="name"></param>
        public static void ThrowIfNotPositive(this float @this, string name)
        {
            if (@this <= 0f)
            {
                throw new ArgumentException(string.Format("{0} should be positive.", name));
            }
        }

        /// <summary>
        /// 如果值为负数，则抛出ArgumentException异常
        /// </summary>
        /// <param name="this"></param>
        /// <param name="name"></param>
        public static void ThrowIfNegative(this float @this, string name)
        {
            if (@this < 0f)
            {
                throw new ArgumentException(string.Format("{0} can not be negative.", name));
            }
        }
    }
}
