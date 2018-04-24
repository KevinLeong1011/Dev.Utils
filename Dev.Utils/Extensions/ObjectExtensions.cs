/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/11/18 18:24:00
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Throw <see cref="ArgumentNullException"/> if it is null.
        /// 如果为空则抛出异常
        /// </summary>
        /// <param name="this"></param>
        /// <param name="name">引发异常的参数名</param>
        public static void ThrowIfNull(this object @this, string name)
        {
            if (ReferenceEquals(@this, null))
            {
                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        /// Try cast this object to the specified type.
        /// 尝试转换为指定类型，失败时返回null
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="this"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static TValue TryCast<TValue>(this object @this, string name)
            where TValue : class
        {
            try
            {
                return (TValue)@this;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 校验是否满足条件。如果校验失败，则抛出<see cref="DataValidationException"/>异常
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="this"></param>
        /// <param name="message">message of DataValidationException if validate fail.</param>
        /// <param name="predicate"></param>
        public static void Validate<TValue>(this TValue @this, string message, Func<TValue, bool> predicate)
        {
            if (!predicate(@this))
            {
                throw new DataValidationException(message);
            }
        }

        /// <summary>
        /// Returns a string represents the current object.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="defaultValue">Default value to be returned if the object is null.</param>
        /// <returns></returns>
        public static string ToString(this object @this, string defaultValue)
        {
            return @this == null ? defaultValue : @this.ToString();
        }

        /// <summary>
        /// 判断是否为指定的多个值之一
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool IsOneOf<T>(this T @this, params T[] values)
        {
            foreach(T value in values)
            {
                if (@this.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
