/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/11/18 19:14:54
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace System.Collections.Generic
{
    /// <summary>
    /// 
    /// </summary>
    public static class LinqExtensions
    {
        /// <summary>
        /// 判断集合数据是否为空或只有一个元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsEmptyOrSingle<T>(this IEnumerable<T> source)
        {
            return !source.Any<T>() || !source.Skip(1).Any<T>();
        }

        /// <summary>
        /// 是否只有一个元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsSingle<T>(this IEnumerable<T> source)
        {
            return source.Any<T>() && !source.Skip(1).Any<T>();
        }

        /// <summary>
        /// 遍历所有元素并执行指定操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null)
            {
                return;
            }
            foreach (T current in source)
            {
                action(current);
            }
        }

        /// <summary>
        /// 遍历所有元素并执行指定操作，索引版
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            if (source == null)
            {
                return;
            }
            int num = 0;
            foreach (T current in source)
            {
                action(current, num++);
            }
        }

        /// <summary>
        /// 遍历两个<see cref="IEnumerable"/>对象，并对其相同索引处的对象执行操作
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="action"></param>
        public static void ForEach<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Action<TFirst, TSecond> action)
        {
            IEnumerator<TFirst> enumerator = first.GetEnumerator();
            IEnumerator<TSecond> enumerator2 = second.GetEnumerator();
            while (enumerator.MoveNext() && enumerator2.MoveNext())
            {
                action(enumerator.Current, enumerator2.Current);
            }
        }

        /// <summary>
        /// 倒序遍历并执行操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="action"></param>
        public static void ReverseEach<T>(this IEnumerable<T> @this, Action<T> action)
        {
            for (int i = @this.Count() - 1; i >= 0; i--)
            {
                action(@this.ElementAt(i));
            }
        }

        /// <summary>
        /// 返回符合条件的元素的索引值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static int IndexOf<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            int num = 0;
            foreach (T current in source)
            {
                if (predicate(current))
                {
                    return num;
                }
                num++;
            }
            return -1;
        }

        /// <summary>
        /// 循环展开并返回相应的IEnumerable集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="seed"></param>
        /// <param name="next">循环递归时计算下一个元素的委托方法</param>
        /// <param name="stop">跳出条件</param>
        /// <returns></returns>
        public static IEnumerable<T> Unfold<T>(T seed, Func<T, T> next, Func<T, bool> stop)
        {
            T t = seed;
            while (!stop(t))
            {
                yield return t;
                t = next(t);
            }
            yield break;
        }

        public static IEnumerable<T> Yield<T>(this T singleElement)
        {
            yield return singleElement;
            yield break;
        }

        public static T[] YieldToArray<T>(this T singleElement)
        {
            return new T[]
            {
                singleElement
            };
        }

        public static IEnumerable<T> YieldIfNotNull<T>(this T singleElement)
        {
            if (singleElement != null)
            {
                yield return singleElement;
            }
            yield break;
        }

        /// <summary>
        /// 根据制定的判断方法，将元素集合从嵌套状态转变为平铺
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="getItems"></param>
        /// <returns></returns>
        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> getItems)
        {
            return source.SelectMany((T item) => item.Yield().Concat(getItems(item).Flatten(getItems)));
        }

        public static T MinByLast<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector) where TKey : IComparable
        {
            Comparer<TKey> comparer = Comparer<TKey>.Default;
            return source.Aggregate(delegate (T x, T y)
            {
                if (comparer.Compare(keySelector(x), keySelector(y)) >= 0)
                {
                    return y;
                }
                return x;
            });
        }

        public static T MinBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector) where TKey : IComparable
        {
            Comparer<TKey> comparer = Comparer<TKey>.Default;
            return source.Aggregate(delegate (T x, T y)
            {
                if (comparer.Compare(keySelector(x), keySelector(y)) > 0)
                {
                    return y;
                }
                return x;
            });
        }

        public static T MaxBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector) where TKey : IComparable
        {
            Comparer<TKey> comparer = Comparer<TKey>.Default;
            return source.Aggregate(delegate (T x, T y)
            {
                if (comparer.Compare(keySelector(x), keySelector(y)) < 0)
                {
                    return y;
                }
                return x;
            });
        }

        public static IEnumerable<T> InsertDelimiter<T>(this IEnumerable<T> source, T delimiter)
        {
            IEnumerator<T> enumerator = source.GetEnumerator();
            if (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
            while (enumerator.MoveNext())
            {
                yield return delimiter;
                yield return enumerator.Current;
            }
            yield break;
        }

        public static string ConcatStringsWithDelimiter(this IEnumerable<string> source, string delimiter)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string current in source.InsertDelimiter(delimiter))
            {
                stringBuilder.Append(current);
            }
            return stringBuilder.ToString();
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, ListSortDirection sortDirection)
        {
            if (sortDirection != ListSortDirection.Ascending)
            {
                return source.OrderByDescending(keySelector);
            }
            return source.OrderBy(keySelector);
        }

        public static Func<T> Memoize<T>(this Func<T> getValue)
        {
            Lazy<T> lazy = new Lazy<T>(getValue);
            return () => lazy.Value;
        }

        public static bool AllEqual<T>(this IEnumerable<T> @this, Func<T, T, bool> comparer = null)
        {
            if (!@this.Any<T>())
            {
                return true;
            }
            comparer = (comparer ?? ((T x, T y) => object.Equals(x, y)));
            T first = @this.First<T>();
            return @this.Skip(1).All((T x) => comparer(x, first));
        }

        public static ReadOnlyObservableCollection<T> ToReadOnlyObservableCollection<T>(this IEnumerable<T> @this)
        {
            return new ReadOnlyObservableCollection<T>(new ObservableCollection<T>(@this));
        }


        /// <summary>
        /// 判断是否包含参数指定的所有项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static bool ContainsAll<T>(this IEnumerable<T> @this, params T[] items)
        {
            foreach (T item in items)
            {
                if (!@this.Contains(item)) return false;
            }
            return true;
        }

        /// <summary>
        /// 判断是否包含参数指定的任意一项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static bool ContainsAny<T>(this IEnumerable<T> @this, params T[] items)
        {
            foreach (T item in items)
            {
                if (@this.Contains(item)) return true;
            }
            return false;
        }

        /// <summary>
        /// Add an item and ensure it is sole.
        /// 向<see cref="ICollection&lt;T&gt;"/>集合中添加唯一元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">源集合</param>
        /// <param name="item">要添加的元素</param>
        /// <returns>如果集合中已经包含该元素，返回false；否则返回true</returns>
        public static bool AddSole<T>(this ICollection<T> collection, T item)
        {
            if (collection.Contains(item))
            {
                return false;
            }
            collection.Add(item);
            return true;
        }

        /// <summary>
        /// 移除符合条件的元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="where"></param>
        public static void Remove<T>(this ICollection<T> collection, Func<T, bool> where)
            where T : class
        {
            collection.ReverseEach(x =>
            {
                if (where(x))
                {
                    collection.Remove(x);
                }
            });
        }

        /// <summary>
        /// Concatenates all the elements of a IEnumerable, using the specified separator between each element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string ToString<T>(this IEnumerable<T> collection, char c)
        {
            return string.Join(c.ToString(), collection);
        }

        /// <summary>
        /// Concatenates all the elements of a IEnumerable, using the specified separator between each element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string ToString<T>(this IEnumerable<T> collection, string separator)
        {
            return string.Join(separator, collection);
        }
    }
}
