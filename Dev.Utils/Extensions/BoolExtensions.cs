/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/11/18 22:15:56
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public static class BoolExtensions
    {
        /// <summary>
        /// Do something if true.
        /// 如果为true则执行操作
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action"></param>
        public static void IfTrue(this bool @this, Action action)
        {
            if (@this) action();
        }

        /// <summary>
        /// Do something if false.
        /// 如果为false则执行操作
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action"></param>
        public static void IfFalse(this bool @this, Action action)
        {
            if (!@this) action();
        }

        /// <summary>
        /// Do something if true.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T IfTrue<T>(this bool @this, Func<T> func)
        {
            if (@this) return func();
            return default(T);
        }

        /// <summary>
        /// Do something if false.
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T IfFalse<T>(this bool @this, Func<T> func)
        {
            if (!@this) return func();
            return default(T);
        }
    }
}
