/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/11/18 18:41:29
 * ***********************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Get the value of the specified index. Return default value if beyond the bounds of the array.
        /// 获取数组指定索引值，如果超出索引，返回默认值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="index"></param>
        /// <param name="defaultValue"></param>
        /// <returns>Return default value if the index is beyond the bounds of the array.</returns>
        public static T Index<T>(this T[] @this, int index, T defaultValue = default(T))
        {
            return @this.Length <= index ? defaultValue : @this[index];
        }

        /// <summary>
        /// Get the string value of the specified index.
        /// 获取数组指定索引值，如果超出索引，返回null
        /// </summary>
        /// <param name="this"></param>
        /// <param name="index"></param>
        /// <returns>Return <code>null</code> if beyond the bounds of the array.</returns>
        public static string Index(this string[] @this, int index)
        {
            return @this.Length <= index ? null : @this[index];
        }

        /// <summary>
        /// Safe version of <see cref="Array.Clear(Array, int, int)"/>.
        /// <see cref="Array.Clear(Array, int, int)"/>的索引安全版
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="index">支持负数</param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static bool Clear<T>(this T[] @this, int index, int length)
        {
            if (index < 0)
            {
                if (Math.Abs(index) < @this.Length)
                    return @this.Clear(@this.Length + index, length);
                else
                    return false;
            }
            if (index > @this.Length - 1)
                return false;
            if (length > @this.Length - index)
            {
                length = @this.Length - index;
            }
            Array.Clear(@this, index, length);
            return true;
        }

        /// <summary>
        /// Reverse and return this array.
        /// 反转并返回数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <returns></returns>
        public static T[] Reverse<T>(this T[] @this)
        {
            Array.Reverse(@this);
            return @this;
        }

        /// <summary>
        /// Reverse and return this array.
        /// 反转并返回数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static T[] Reverse<T>(this T[] @this, int index, int length)
        {
            Array.Reverse(@this, index, length);
            return @this;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T[] Sort<T>(this T[] array)
        {
            Array.Sort(array);
            return array;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static T[] Sort<T>(this T[] array, Int32 index, Int32 length)
        {
            Array.Sort(array, index, length);
            return array;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static T[] Sort<T>(this T[] array, IComparer comparer)
        {
            Array.Sort(array, comparer);
            return array;
        }
    }
}
