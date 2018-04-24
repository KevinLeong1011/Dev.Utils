/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/11/18 19:20:07
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    /// <summary>
    /// Extensions for delegate
    /// </summary>
    public static class DelegateExtensions
    {
        /// <summary>
        /// Combine actions into one.
        /// 将指定的Action合并为一个
        /// </summary>
        /// <param name="actions"></param>
        /// <returns></returns>
        public static Action CombineActions(params Action[] actions)
        {
            return delegate
            {
                actions.ForEach(delegate (Action x)
                {
                    x();
                });
            };
        }

        /// <summary>
        /// Combine actions into one.
        /// 将指定的Action合并为一个
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actions"></param>
        /// <returns></returns>
        public static Action<T> CombineActions<T>(params Action<T>[] actions)
        {
            return delegate (T p)
            {
                actions.ForEach(delegate (Action<T> x)
                {
                    x(p);
                });
            };
        }

        /// <summary>
        /// Combine actions into one.
        /// 将指定的Action合并为一个
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="actions"></param>
        /// <returns></returns>
        public static Action<T1, T2> CombineActions<T1, T2>(params Action<T1, T2>[] actions)
        {
            return delegate (T1 p1, T2 p2)
            {
                actions.ForEach(delegate (Action<T1, T2> x)
                {
                    x(p1, p2);
                });
            };
        }

        /// <summary>
        /// Return an empty delegate if this is null. Otherwise, return itself.
        /// 如果Action为null，则返回一个空委托，否则返回原Action
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Action ThisOrEmpty(this Action action)
        {
            return action ?? delegate { };
        }

        /// <summary>
        /// Return the specified action if this is null. Otherwise, return itself.
        /// 自身为null时返回defaultAction；否则返回自身
        /// </summary>
        /// <param name="action"></param>
        /// <param name="defaultAction"></param>
        /// <returns></returns>
        public static Action ThisOrDefault(this Action action, Action defaultAction)
        {
            return action ?? delegate
            {
                defaultAction();
            };
        }

        /// <summary>
        ///  Return the specified action if this is null. Otherwise, return itself.
        /// 自身为null时返回defaultAction；否则返回自身
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="defaultAction"></param>
        /// <returns></returns>
        public static Action<T> ThisOrDefault<T>(this Action<T> action, Action defaultAction)
        {
            return action ?? delegate (T x)
            {
                defaultAction();
            };
        }

        /// <summary>
        /// Return the specified action if this is null. Otherwise, return itself.
        /// 自身为null时返回defaultAction；否则返回自身
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="action"></param>
        /// <param name="defaultAction"></param>
        /// <returns></returns>
        public static Action<T1, T2> ThisOrDefault<T1, T2>(this Action<T1, T2> action, Action defaultAction)
        {
            return action ?? delegate (T1 x1, T2 x2)
            {
                defaultAction();
            };
        }

        /// <summary>
        /// We will get a <see cref="Func{TR}"/> which always return the default value if this is null. Otherwise, return itself.
        /// 如果自身为null，将得到一个总是返回默认值的简单<see cref="Func{TResult}"/>；否则返回自身
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="func"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Func<TR> ThisOrDefault<TR>(this Func<TR> func, TR defaultValue)
        {
            return func ?? (() => defaultValue);
        }

        /// <summary>
        /// We will get a <see cref="Func{T, TR}"/> which always return the default value if this is null. Otherwise, return itself.
        /// 如果自身为null，将得到一个总是返回默认值的简单<see cref="Func{T, TResult}"/>；否则返回自身
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="func"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Func<T, TR> ThisOrDefault<T, TR>(this Func<T, TR> func, TR defaultValue)
        {
            return func ?? ((T x) => defaultValue);
        }

        /// <summary>
        /// We will get a <see cref="Func{T1, T2, TR}"/> which always return the default value if this is null. Otherwise, return itself.
        /// 如果自身为null，将得到一个总是返回默认值的简单<see cref="Func{T1, T2, TResult}"/>；否则返回自身
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="func"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Func<T1, T2, TR> ThisOrDefault<T1, T2, TR>(this Func<T1, T2, TR> func, TR defaultValue)
        {
            return func ?? ((T1 x1, T2 x2) => defaultValue);
        }

        /// <summary>
        /// We will get a <see cref="Func{T1, T2, T3, TR}"/> which always return the default value if this is null. Otherwise, return itself.
        /// 如果自身为null，将得到一个总是返回默认值的简单<see cref="Func{T1, T2, T3, TResult}"/>；否则返回自身
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="func"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Func<T1, T2, T3, TR> ThisOrDefault<T1, T2, T3, TR>(this Func<T1, T2, T3, TR> func, TR defaultValue)
        {
            return func ?? ((T1 x1, T2 x2, T3 t3) => defaultValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TNew"></typeparam>
        /// <param name="action"></param>
        /// <param name="ignore"></param>
        /// <returns></returns>
        public static Action<TNew> ChangeArgType<T, TNew>(this Action<T> action, TNew ignore)
            where T : TNew
        {
            if (action == null)
            {
                return null;
            }
            return delegate (TNew x)
            {
                action((T)((object)x));
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TNew"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="action"></param>
        /// <param name="ignore"></param>
        /// <returns></returns>
        public static Action<TNew, T2> ChangeArgType0<T, TNew, T2>(this Action<T, T2> action, TNew ignore) where T : TNew
        {
            if (action == null)
            {
                return null;
            }
            return delegate (TNew x, T2 x2)
            {
                action((T)((object)x), x2);
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TNew"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="action"></param>
        /// <param name="ignore"></param>
        /// <returns></returns>
        public static Action<TNew, T2, T3> ChangeArgType0<T, TNew, T2, T3>(this Action<T, T2, T3> action, TNew ignore) where T : TNew
        {
            if (action == null)
            {
                return null;
            }
            return delegate (TNew x, T2 x2, T3 x3)
            {
                action((T)((object)x), x2, x3);
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="f"></param>
        /// <param name="setResult"></param>
        /// <returns></returns>
        public static Action ToAction<TResult>(this Func<TResult> f, Action<TResult> setResult)
        {
            if (f == null)
            {
                return null;
            }
            return delegate
            {
                setResult(f());
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="f"></param>
        /// <param name="setResult"></param>
        /// <returns></returns>
        public static Action<T> ToAction<T, TResult>(this Func<T, TResult> f, Action<TResult> setResult)
        {
            if (f == null)
            {
                return null;
            }
            return delegate (T x)
            {
                setResult(f(x));
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="f"></param>
        /// <param name="setResult"></param>
        /// <returns></returns>
        public static Action<T1, T2> ToAction<T1, T2, TResult>(this Func<T1, T2, TResult> f, Action<TResult> setResult)
        {
            if (f == null)
            {
                return null;
            }
            return delegate (T1 x1, T2 x2)
            {
                setResult(f(x1, x2));
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="f"></param>
        /// <param name="setResult"></param>
        /// <returns></returns>
        public static Action<T1, T2, T3> ToAction<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> f, Action<TResult> setResult)
        {
            if (f == null)
            {
                return null;
            }
            return delegate (T1 x1, T2 x2, T3 x3)
            {
                setResult(f(x1, x2, x3));
            };
        }

        /// <summary>
        /// Run this action for n times.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="n"></param>
        public static void For(this Action action, int n)
        {
            if (action == null) return;
            for (int i = 0; i < n; i++)
            {
                action();
            }
        }

        /// <summary>
        /// Run this function for n times.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IEnumerable<T> For<T>(this Func<T> func, int n)
        {
            if (func == null)
            {
                yield return default(T);
                yield break;
            }
            for (int i = 0; i < n; i++)
            {
                yield return func();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="func"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static IEnumerable<TR> For<T, TR>(this Func<T, TR> func, params T[] parameters)
        {
            if (func == null)
            {
                yield return default(TR);
                yield break;
            }
            for (int i = 0; i < parameters.Length; i++)
            {
                yield return func(parameters[i]);
            }
        }
    }
}
