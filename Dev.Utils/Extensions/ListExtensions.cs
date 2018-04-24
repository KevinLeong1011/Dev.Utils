/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2018/1/3 1:17:28
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace System.Collections.Generic
{
    /// <summary>
    /// 
    /// </summary>
    public static class ListExtensions
    {
        public static List<T> Clone<T>(this List<T> @this)
            where T : class, ICloneable<T>
        {
            List<T> list = new List<T>();
            foreach (T item in @this)
            {
                list.Add(item.Clone());
            }
            return list;
        }
    }
}
