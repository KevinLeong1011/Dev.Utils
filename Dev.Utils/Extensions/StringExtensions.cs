/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/11/18 18:27:41
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Throw <see cref="ArgumentException"/> if the value is null or empty.
        /// 当值为null或Empty时抛出<see cref="ArgumentException"/>异常
        /// </summary>
        /// <param name="this"></param>
        /// <param name="name"></param>
        public static void ThrowIfNullOrEmpty(this string @this, string name)
        {
            if (@this.NullOrEmpty())
            {
                throw new ArgumentException(string.Format("{0} can not be null or empty.", name));
            }
        }

        /// <summary>
        /// Throw <see cref="ArgumentException"/> if the value is null, empty, or consists only of white-space characters.
        /// 如果字符串为null、空或仅由空白字符构成，则抛出<see cref="ArgumentException"/>异常
        /// </summary>
        /// <param name="this"></param>
        /// <param name="name"></param>
        public static void ThrowIfNullOrWhiteSpace(this string @this, string name)
        {
            if (@this.NullOrWhiteSpace())
            {
                throw new ArgumentException(string.Format("{0} can not be null, empty or consist only of white-space characters.", name));
            }
        }

        /// <summary>
        /// Indicates whether a specified string is null, empty, or consists only of white-space characters.
        /// 指示字符串是null、空还是仅由空白字符组成
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool NullOrWhiteSpace(this string @this)
        {
            return string.IsNullOrWhiteSpace(@this);
        }

        /// <summary>
        /// Indicates whether the specified string is null or an System.String.Empty string.
        /// 指示字符串是否为null或空
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool NullOrEmpty(this string @this)
        {
            return string.IsNullOrEmpty(@this);
        }

        ///// <summary>
        ///// Cut off 
        ///// 从原字符串指定索引处切取指定长度的字符串
        ///// </summary>
        ///// <param name="this"></param>
        ///// <param name="index"></param>
        ///// <param name="length"></param>
        ///// <returns></returns>
        //public static string Cut(this string @this, int index, int length)
        //{
        //    string sub = @this.Substring(index, length);
        //    return @this.Remove(index, length);
        //}

        /// <summary>
        /// Delete all of the specified characters from this string.
        /// 删除字符串中所有指定的字符
        /// </summary>
        /// <param name="this"></param>
        /// <param name="c"></param>
        public static void DeleteChar(this string @this, char c)
        {
            @this.Replace(c.ToString(), "");
        }

        /// <summary>
        /// Indicates whether this string value is a number.
        /// 判断字符串是否是一个数值
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsNumber(this string @this)
        {
            return Regex.IsMatch(@this, Patterns.DOUBLE);
        }

        /// <summary>
        /// Convert this string value to <see cref="int"/>. Return the default value if failed.
        /// 将字符串转换为整型值，转换失败则返回指定的默认值
        /// </summary>
        /// <param name="this">指定的字符串</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>整型值</returns>
        public static int ToInt(this string @this, int defaultValue = default(int))
        {
            try
            {
                return int.Parse(@this);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert to <see cref="uint"/> value. Return the default value when failed.
        /// 将字符串转换为<see cref="uint"/>数值，失败则返回默认值
        /// </summary>
        /// <param name="this"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static uint ToUint(this string @this, uint defaultValue = default(uint))
        {
            try
            {
                return uint.Parse(@this);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert to <see cref="float"/> value. Return the default value when failed.
        /// 将字符串转换为<see cref="float"/>数值，失败则返回默认值
        /// </summary>
        /// <param name="this"></param>
        /// <param name="defaultValue">Default value to be returned if fail to convert.</param>
        /// <returns></returns>
        public static float ToFloat(this string @this, float defaultValue = default(float))
        {
            try
            {
                return float.Parse(@this);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert to <see cref="bool"/> value.
        /// 转换为布尔值
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool ToBoolean(this string @this)
        {
            return bool.Parse(@this);
        }

        /// <summary>
        /// Convert to <see cref="double"/> value. Return the default value when failed.
        /// 将字符串转换为<see cref="double"/>数值，失败则返回默认值
        /// </summary>
        /// <param name="this"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double ToDouble(this string @this, double defaultValue = default(double))
        {
            try
            {
                return double.Parse(@this);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert to <see cref="Int64"/> value. Return the default value when failed.
        /// 将字符串转换为<see cref="Int64"/>数值，失败则返回默认值
        /// </summary>
        /// <param name="this"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Int64 ToInt64(this string @this, Int64 defaultValue)
        {
            try
            {
                return Int64.Parse(@this);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert to <see cref="Int16"/> value. Return the default value when failed.
        /// 将字符串转换为<see cref="Int16"/>数值，失败则返回默认值
        /// </summary>
        /// <param name="this"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Int16 ToInt16(this string @this, Int16 defaultValue = default(Int16))
        {
            try
            {
                return Int16.Parse(@this);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert to <see cref="ulong"/> value. Return the default value when failed.
        /// 将字符串转换为<see cref="Int16"/>数值，失败则返回默认值
        /// 将字符串转换为<see cref="ulong"/>数值，失败则返回默认值
        /// </summary>
        /// <param name="this"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static ulong ToUlong(this string @this, ulong defaultValue = default(ulong))
        {
            try
            {
                return ulong.Parse(@this);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Get all of the <see cref="int"/> values within this string.
        /// 获取字符串中包含的所有整型值
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static int[] GetAllInt(this string @this)
        {
            List<int> list = new List<int>();
            MatchCollection matches = Regex.Matches(@this, @"\d+");
            foreach (Match match in matches)
            {
                list.Add(match.Value.ToInt());
            }
            return list.ToArray();
        }

        public static double[] GetNumbers(this string @this)
        {
            List<double> list = new List<double>();
            MatchCollection matches = Regex.Matches(@this, Patterns.DOUBLE);
            foreach (Match match in matches)
            {
                list.Add(match.Value.ToDouble());
            }
            return list.ToArray();
        }

        /// <summary>
        /// Convert to an equivalent enumerated object.
        /// 将字符串转换为枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string @this, bool ignoreCase = true)
        {
            return (T)Enum.Parse(typeof(T), @this, ignoreCase);
        }

        /// <summary>
        /// Convert to an equivalent enumerated object. Return the default value if fail to convert.
        /// 将字符串转换为枚举，若转换失败，则返回给定的默认值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <param name="defaultValue"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string str, T defaultValue, bool ignoreCase = true)
        {
            try
            {
                return str.ToEnum<T>(ignoreCase);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 用于对字符串的行进行快捷操作
        /// </summary>
        /// <param name="this"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static string OperateWithLine(this string @this, Func<string, int, string> func)
        {
            string result = null;
            string pattern = @".*\n";
            var matches = Regex.Matches(@this, pattern);
            int count = 0;
            foreach (Match match in matches)
            {
                string line = match.Value;
                line = func(line, count);
                result += line;
                count++;
            }
            return result;
        }

        /// <summary>
        /// 删除字符串中的指定行
        /// </summary>
        /// <param name="this"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string DeleteLine(this string @this, int index)
        {
            return @this.OperateWithLine((x, i) =>
            {
                return i == index ? "" : x;
            });
        }

        /// <summary>
        /// 返回字符串中指定行
        /// </summary>
        /// <param name="this"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string LineOf(this string @this, int index = 0)
        {
            string pattern = @".*\n";
            var matches = Regex.Matches(@this, pattern);
            int count = 0;
            foreach (Match match in matches)
            {
                if (count == index)
                {
                    return match.Value;
                }
                count++;
            }
            return null;
        }

        /// <summary>
        /// Return the specified value instead if this is null, empty, or consist only of white-space characters. Otherwise, return itself.
        /// 若字符串为空或null，则以指定字符串代替作为默认值，否则返回原值
        /// </summary>
        /// <param name="this"></param>
        /// <param name="value"></param>
        /// <returns>字符串</returns>
        public static string Default(this string @this, string value)
        {
            if (string.IsNullOrWhiteSpace(@this))
            {
                return value;
            }
            return @this;
        }

        /// <summary>
        /// Get random character within this string.
        /// 随机获取字符串中的字符
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static char Random(this string @this)
        {
            return @this[new Random(Guid.NewGuid().GetHashCode()).Next(@this.Length)];
        }

        /// <summary>
        /// Replace the old value with new one from the specified index.
        /// 从指定索引处开始替换字符串
        /// </summary>
        /// <param name="this"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string Replace(this string @this, string oldValue, string newValue, int index)
        {
            string part = @this.Substring(index, @this.Length - index);
            return @this.Substring(0, index) + part.Replace(oldValue, newValue);
        }

        /// <summary>
        /// Increase the tail number of this string with the specified steps.
        /// 将字符串中最后一个数值部分增加指定步进值后输出。如果原字符串中无数值部分，则在末尾追加step，如输入string，step=2，输出string2
        /// </summary>
        /// <param name="this"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        public static string Increase(this string @this, int step = 1)
        {
            if (@this.NullOrEmpty()) throw new ArgumentNullException("this");
            if (!char.IsDigit(@this.Last())) return @this + step;
            string pattern = @"\d+$";
            var match = Regex.Match(@this, pattern);
            if (match == null || match.Value.NullOrEmpty()) return @this + step;
            int value = int.Parse(match.ToString()) + step;
            return @this.Substring(0, match.Index) + value;
        }

        /// <summary>
        /// Get substring that matches the specified regular expression. Return default value if fail to match.
        /// 获取字符串中与指定的正则表达式匹配的部分，如果未匹配到，则返回指定的默认值
        /// </summary>
        /// <param name="this"></param>
        /// <param name="pattern"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string Substring(this string @this, string pattern, string defaultValue = null)
        {
            try
            {
                Match match = Regex.Match(@this, pattern);
                if (match == null) return string.IsNullOrEmpty(defaultValue) ? string.Empty : defaultValue;
                return match.Value;
            }
            catch
            {
                return defaultValue ?? string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string SubBetween(this string @this, char c)
        {
            int index1 = @this.IndexOf(c);
            if (index1 < 0) return null;
            int index2 = @this.IndexOf(c, index1 + 1);
            if (index2 < 0)
            {
                return @this.Substring(index1 + 1);
            }

            return @this.Substring(index1 + 1, index2 - index1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static string SubBetween(this string @this, string k)
        {
            return SubBetween(@this, k, k);
        }

        /// <summary>
        /// Get substring between the specified two strings.
        /// 获取位于指定的两个字符串之间的部分
        /// </summary>
        /// <param name="this"></param>
        /// <param name="k1"></param>
        /// <param name="k2"></param>
        /// <returns></returns>
        public static string SubBetween(this string @this, string k1, string k2)
        {
            int index1 = Math.Max(0, @this.IndexOf(k1));
            int len = index1 + k1.Length;
            if (k2.NullOrEmpty())
            {
                return @this.Substring(len);
            }
            else
            {
                int index2 = @this.IndexOf(k2, len);
                if (index2 < 0)
                {
                    return @this.Substring(len);
                }
                return @this.Substring(len, index2 - len);
            }
        }

        /// <summary>
        /// Wrap this string into the specified character.
        /// 使用指定的字符对源字符串进行包裹处理
        /// </summary>
        /// <param name="this"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string Wrap(this string @this, char c)
        {

            return c + @this + c;
        }

        /// <summary>
        /// Wrap this string into the specified tag.
        /// 将源字符串使用指定的xml标签进行包裹处理
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static string XmlWrap(this string str, string tag)
        {
            if (str.StartsWith("<" + tag + ">")) return str;
            return string.Format("<{0}>{1}</{0}>", tag, str);
        }

        /// <summary>
        /// 是否纯粹的整型值
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsPureInt(this string @this)
        {
            return Regex.IsMatch(@this, @"^\d+$");
        }

        /// <summary>
        /// 遍历字符并执行操作
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action"></param>
        /// <param name="breakCondition">退出条件</param>
        /// <param name="continueCondition">跳过条件</param>
        public static void ForEach(this string @this, Action<int, char> action, Func<int, char, bool> breakCondition = null, Func<int, char, bool> continueCondition = null)
        {
            for (int i = 0, l = @this.Length; i < l; i++)
            {
                char c = @this[i];
                if (breakCondition != null && breakCondition(i, c)) break;
                if (continueCondition != null && continueCondition(i, c)) continue;
                action(i, @this[i]);
            }
        }

        /// <summary>
        /// Indicates whether this is one of the specified strings.
        /// 判断字符串是否在指定的数组中
        /// </summary>
        /// <param name="this"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool WithIn(this string @this, params string[] source)
        {
            return source.IndexOf(x => x == @this) >= 0;
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in this string.
        /// 是否与指定的正则表达式匹配
        /// </summary>
        /// <param name="this"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool IsMatch(this string @this, string pattern)
        {
            if (pattern.NullOrEmpty()) return false;
            return Regex.IsMatch(@this, pattern);
        }

        /// <summary>
        /// Indicates whether all of the specified regular expressions can find a match in this string.
        /// 是否与指定的正则表达式匹配
        /// </summary>
        /// <param name="this"></param>
        /// <param name="patterns"></param>
        /// <returns></returns>
        public static bool MatchAll(this string @this, params string[] patterns)
        {
            if (patterns.Length == 0) return false;
            foreach (string pattern in patterns)
            {
                if (!Regex.IsMatch(@this, pattern)) return false;
            }
            return true;
        }

        /// <summary>
        /// Indicates whether any of the specified regular expressions can find a match in this string.
        /// 是否与指定的任意正则表达式匹配
        /// </summary>
        /// <param name="source"></param>
        /// <param name="patterns"></param>
        /// <returns></returns>
        public static bool MatchAny(this string source, params string[] patterns)
        {
            if (patterns.Length == 0) return false;
            foreach (string pattern in patterns)
            {
                if (!pattern.NullOrEmpty() && Regex.IsMatch(source, pattern))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 获取源字符串中匹配的部分
        /// </summary>
        /// <param name="this"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static string MatchValue(this string @this, string pattern)
        {
            if (!@this.NullOrEmpty() && !pattern.NullOrEmpty())
            {
                return Regex.Match(@this, pattern)?.Value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get all <see cref="double"/> values within this string.
        /// 获取字符串中所有的<see cref="double"/>数值
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static double[] GetAllDouble(this string @this)
        {
            MatchCollection matches = Regex.Matches(@this, @"[-+]?\d+(\.\d+)?");
            List<double> list = new List<double>();
            foreach (Match match in matches)
            {
                list.Add(double.Parse(match.Value));
            }
            return list.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static int CompareAsNumber(this string @this, string other)
        {
            if (!@this.IsNumber()) throw new Exception("source is not a number");
            if (!other.IsNumber()) throw new Exception("other is not a number");

            bool sourceNegative = @this[0] == '-';
            bool otherNegative = other[0] == '-';
            if (sourceNegative && !otherNegative) return -1;
            if (!sourceNegative && otherNegative) return 1;

            // 如果都是正数
            if (!otherNegative && !sourceNegative)
            {
                string[] sourceParts = @this.Split('.');
                string[] otherParts = other.Split('.');
                string sourceIntPart = sourceParts.Index(0);
                string sourceDecimalPart = sourceParts.Index(1) ?? "";
                string otherIntPart = otherParts.Index(0);
                string otherDecimalPart = otherParts.Index(1) ?? "";
                int intPartMaxLen = Math.Max(sourceIntPart.Length, otherIntPart.Length);
                int decimalPartLen = Math.Max(sourceDecimalPart.Length, otherDecimalPart.Length);

                string sourceNew = sourceIntPart.PadLeft(intPartMaxLen, '0') + sourceDecimalPart.PadRight(decimalPartLen, '0');
                string otherNew = otherIntPart.PadLeft(intPartMaxLen, '0') + otherDecimalPart.PadRight(decimalPartLen, '0');
                return sourceNew.CompareTo(otherNew);
            }
            else
            {
                // 如果都是负数
                return other.TrimStart('-').CompareAsNumber(@this.TrimStart('-'));
            }
        }

        /// <summary>
        /// 判断字符串中是否包含所有指定内容
        /// </summary>
        /// <param name="this"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool ContainsAll(this string @this, params string[] values)
        {
            foreach (string value in values)
            {
                if (!@this.Contains(value)) return false;
            }
            return true;
        }

        /// <summary>
        /// Indicats whether this string contains any of the specified strings.
        /// 判断是否包含指定字符串中的任意一个
        /// </summary>
        /// <param name="this"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool ContainsAny(this string @this, params string[] values)
        {
            foreach (string value in values)
            {
                if (@this.Contains(value))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether this contains any character of the specified string.
        /// 判断是否包含所给字符串中的任意字符
        /// </summary>
        /// <param name="this"></param>
        /// <param name="characters"></param>
        /// <returns></returns>
        public static bool ContainsAnyChar(this string @this, string characters)
        {
            foreach (char c in characters)
            {
                if (@this.Contains(c))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether the beginning of this string instance matches any of the specified strings.
        /// 判断字符串开头是否与指定字符串中的任意一个匹配
        /// </summary>
        /// <param name="this"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool StartsWithAny(this string @this, params string[] values)
        {
            foreach (string value in values)
            {
                if (@this.StartsWith(value))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether the beginning of this string instance matches any of the specified strings, ignoring case.
        /// 判断字符串开头是否与指定字符串数组中的任意一个匹配，忽略大小写
        /// </summary>
        /// <param name="this"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool StartsWithAnyIgnoreCase(this string @this, params string[] values)
        {
            foreach (string value in values)
            {
                if (@this.StartsWith(value, true, CultureInfo.CurrentCulture))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether the end of this string instance matches any of the specified strings.
        /// 是否以指定字符串中任意一个结尾。
        /// </summary>
        /// <param name="this"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool EndsWithAny(this string @this, params string[] values)
        {
            foreach (string value in values)
            {
                if (@this.EndsWith(value))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether the end of this string instance matches any of the specified strings, ignoring case.
        /// 是否以指定字符串中任意一个结尾，忽略大小写。
        /// </summary>
        /// <param name="this"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool EndsWithAnyIgnoreCase(this string @this, params string[] values)
        {
            foreach (string value in values)
            {
                if (@this.EndsWith(value, true, CultureInfo.CurrentCulture))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <param name="pattern"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string[] SplitByRegex(this string @this, string pattern, StringSplitOptions options = StringSplitOptions.None)
        {
            List<string> list = new List<string>();
            MatchCollection matches = Regex.Matches(@this, pattern);
            int lastIndex = 0;
            foreach (Match match in matches)
            {
                int index = match.Index;
                if (index > 0)
                {
                    list.Add(@this.Substring(lastIndex, index - lastIndex));
                }
                lastIndex = index + match.Length;
            }
            if (lastIndex < @this.Length)
            {
                list.Add(@this.Substring(lastIndex));
            }
            return list.ToArray();
        }

        /// <summary>
        /// 使用指定字符串分割源字符串，得到字符串数组
        /// </summary>
        /// <param name="this"></param>
        /// <param name="seperator"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string[] Split(this string @this, string seperator, StringSplitOptions options)
        {
            return @this.Split(new string[] { seperator }, options);
        }
    }
}
