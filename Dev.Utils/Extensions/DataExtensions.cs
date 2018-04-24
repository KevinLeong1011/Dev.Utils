/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/6/29 22:13:28
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    [DebuggerStepThrough]
    public static class DataExtensions
    {
        /// <summary>
        /// 计算值。如果调用者为null，则得到返回值类型的默认值；反之，将使用指定的方法委托进行求值
        /// </summary>
        /// <typeparam name="TI"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="input"></param>
        /// <param name="evaluator"></param>
        /// <returns></returns>
        public static TR With<TI, TR>(this TI input, Func<TI, TR> evaluator)
            where TI : class 
            where TR : class
        {
            if (input == null)
            {
                return default(TR);
            }
            return evaluator(input);
        }

        /// <summary>
        /// 对字符串进行求值。如果字符串为null或Empty，则得到返回值类型的默认值；反之，将使用指定的方法委托进行求值
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="input"></param>
        /// <param name="evaluator"></param>
        /// <returns></returns>
        public static TR WithString<TR>(this string input, Func<string, TR> evaluator) where TR : class
        {
            if (string.IsNullOrEmpty(input))
            {
                return default(TR);
            }
            return evaluator(input);
        }

        /// <summary>
        /// 对结构体进行求值运算。如果结构体有值，则使用指定evaluator委托求值；如果fallback回调为空，则得到返回值类型的默认值；否则，使用回调委托求值
        /// </summary>
        /// <typeparam name="TI"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="input"></param>
        /// <param name="evaluator"></param>
        /// <param name="fallback"></param>
        /// <returns></returns>
        public static TR Return<TI, TR>(this TI? input, Func<TI?, TR> evaluator, Func<TR> fallback) 
            where TI : struct
        {
            if (input.HasValue)
            {
                return evaluator(new TI?(input.Value));
            }
            if (fallback == null)
            {
                return default(TR);
            }
            return fallback();
        }

        /// <summary>
        /// 求值运算。如果调用者不为null，则使用指定evaluator委托求值；如果fallback回调为空，则得到返回值类型的默认值；否则，使用回调委托求值
        /// </summary>
        /// <typeparam name="TI"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="input"></param>
        /// <param name="evaluator"></param>
        /// <param name="fallback"></param>
        /// <returns></returns>
        public static TR Return<TI, TR>(this TI input, Func<TI, TR> evaluator, Func<TR> fallback) where TI : class
        {
            if (input != null)
            {
                return evaluator(input);
            }
            if (fallback == null)
            {
                return default(TR);
            }
            return fallback();
        }

        /// <summary>
        /// 不为null时返回true
        /// </summary>
        /// <typeparam name="TI"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ReturnSuccess<TI>(this TI input) where TI : class
        {
            return input != null;
        }

        /// <summary>
        /// 用作对象校验的安全方法。如果对象为null，则返回默认值；如果input不为null，且执行evaluator验证得到false，则返回默认值；否则返回input原值
        /// </summary>
        /// <typeparam name="TI"></typeparam>
        /// <param name="input"></param>
        /// <param name="evaluator"></param>
        /// <returns></returns>
        public static TI If<TI>(this TI input, Func<TI, bool> evaluator) where TI : class
        {
            if (input == null)
            {
                return default(TI);
            }
            if (!evaluator(input))
            {
                return default(TI);
            }
            return input;
        }

        /// <summary>
        /// 用作对象校验的安全方法。如果input不为null，且执行evaluator验证得到false，则返回input；否则返回默认值
        /// </summary>
        /// <typeparam name="TI"></typeparam>
        /// <param name="input"></param>
        /// <param name="evaluator"></param>
        /// <returns></returns>
        public static TI IfNot<TI>(this TI input, Func<TI, bool> evaluator) where TI : class
        {
            if (input == null)
            {
                return default(TI);
            }
            if (!evaluator(input))
            {
                return input;
            }
            return default(TI);
        }

        /// <summary>
        /// 如果调用者为null，则直接返回该类型的默认值；否则，执行指定动作并返回原对象
        /// </summary>
        /// <typeparam name="TI"></typeparam>
        /// <param name="input"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static TI Do<TI>(this TI input, Action<TI> action) where TI : class
        {
            if (input == null)
            {
                return default(TI);
            }
            action(input);
            return input;
        }
    }
}