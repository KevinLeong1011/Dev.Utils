/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/11/18 18:38:55
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    /// <summary>
    /// Regex patterns. 正则表达式
    /// </summary>
    public class Patterns
    {
        /// <summary>
        /// Regex that matches double. 匹配double值。
        /// </summary>
        public const string DOUBLE = @"^[-+]?\d+(\.\d+)?$";

        /// <summary>
        /// Regex that matches int. 匹配整型值。
        /// </summary>
        public const string INT = @"^[+-]?\d+$";

        /// <summary>
        /// Regex that matches positive int value. 匹配正整数。
        /// </summary>
        public const string POSITIVE_INT = @"^+?[1-9]\d*$";

        /// <summary>
        /// Regex that matches positive int value or zero. 匹配非正整数
        /// </summary>
        public const string NON_POSITIVE_INT = @"^-?\d+$";

        /// <summary>
        /// Regex that matches negative int value. 匹配负整数。
        /// </summary>
        public const string NEGATIVE_INT = @"^-\d+$";

        /// <summary>
        /// Regex that matches negative int value or Zero. 匹配非负整数。
        /// </summary>
        public const string NON_NEGATIVE_INT = @"^+?\d+$";
    }
}