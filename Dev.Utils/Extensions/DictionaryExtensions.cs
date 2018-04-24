/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/11/18 19:23:46
 * ***********************************************/
using System;
using System.Collections.Generic;

namespace System.Collections.Generic
{
    /// <summary>
    /// 
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Try to get the value. If failed, than add it. 
        /// 获取或添加键值
        /// </summary>
        /// <typeparam name="TKey">键类型</typeparam>
        /// <typeparam name="TValue">值类型</typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="createValueDelegate"></param>
        /// <returns></returns>
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> createValueDelegate)
        {
            TValue result;
            if (!dictionary.TryGetValue(key, out result))
            {
                result = (dictionary[key] = createValueDelegate());
            }
            return result;
        }

#if !NETCOREAPP2_0

        /// <summary>
        /// 获取与指定键关联的值。指定键不存在时返回默认值
        /// </summary>
        /// <typeparam name="TKey">键类型</typeparam>
        /// <typeparam name="TValue">值类型</typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue result;
            dictionary.TryGetValue(key, out result);
            return result;
        }
#endif

        /// <summary>
        /// 获取与指定键关联的值，如果键不存在，则返回指定的默认值
        /// </summary>
        /// <typeparam name="TKey">键类型</typeparam>
        /// <typeparam name="TValue">值类型</typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key">键</param>
        /// <param name="defaultValue">键不存在时的默认值</param>
        /// <returns></returns>
        public static TValue GetValueOrDefault<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue defaultValue)
        {
            TValue result;
            if (dictionary.TryGetValue(key, out result))
            {
                return result;
            }
            return defaultValue;
        }

        /// <summary>
        /// Add or update an element with the provided key and value to the dictionary.
        /// 向字典添加或更新键值
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IDictionary<TKey, TValue> Put<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
        {
            if (dictionary.ContainsKey(key)) dictionary[key] = value;
            else dictionary.Add(key, value);
            return dictionary;
        }
    }
}
