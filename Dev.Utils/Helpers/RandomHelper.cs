/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/7/22 22:01:05
 * ***********************************************/

using System.Collections.Generic;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public static class RandomHelper
    {
        /// <summary>
        /// 获取随机整数
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int Next(int min, int max)
        {
            return NewRandom().Next(min, max);
        }

        /// <summary>
        /// 获取0到value的随机整数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Next(int value)
        {
            return NewRandom().Next(Math.Min(0, value), Math.Max(0, value));
        }

        /// <summary>
        /// 获取<see cref="double"/>随机值
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static double Next(double min, double max)
        {
            string minString = min.ToString("G");
            string maxString = max.ToString("G");
            return double.Parse(Next(minString, maxString));
        }

        /// <summary>
        /// 获取<see cref="double"/>随机值
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static double Next(double max)
        {
            string maxString = max.ToString("G");
            if (max > 0) return double.Parse(Next("0", maxString));
            else
            {
                return double.Parse(Next(maxString, "0"));
            }
        }

        /// <summary>
        /// 在指定字符串表示的数值之间获取随机值，并返回其字符串。支持整数、小数。
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns> // 可能少考虑负数
        public static string Next(string min, string max)
        {
            if (min == null || max == null) throw new ArgumentNullException("min or max");
            if (min.Trim() == string.Empty) min = "0";
            if (max.Trim() == string.Empty) max = "0";

            int compareResult = min.CompareAsNumber(max);
            if (compareResult == 1) throw new Exception("min cannot be larger than max");
            if (compareResult == 0) return min;

            string[] minParts = min.Split('.');
            string minFloor = minParts.Index(0);
            string minDecimal = minParts.Index(1) ?? "";
            string[] maxParts = max.Split('.');
            string maxFloor = maxParts.Index(0);
            string maxDecimal = maxParts.Index(1) ?? "";
            if (minFloor == maxFloor)
            {
                int decimalLength = Math.Max(minDecimal.Length, maxDecimal.Length);
                minDecimal = minDecimal.PadRight(decimalLength, '0');
                maxDecimal = maxDecimal.PadRight(decimalLength, '0');// 小数部分必须右补0
                string randomDecimal = NextInt(minDecimal, maxDecimal).PadLeft(decimalLength, '0');
                return minFloor + (randomDecimal == "0" ? "" : "." + randomDecimal);
            }
            else
            {
                string randomFloor = NextInt(minFloor, maxFloor);
                int decimalLength = Math.Max(minDecimal.Length, maxDecimal.Length);
                string randomDecimal = NextInt("0", "1".PadRight(decimalLength, '0')).PadRight(decimalLength, '0');
                return randomFloor + (randomDecimal == "0" ? "" : "." + randomDecimal);
            }
        }

        /// <summary>
        /// 获取带有随机种子的<see cref="System.Random"/>对象
        /// </summary>
        /// <returns></returns>
        public static Random NewRandom()
        {
            return new Random(Guid.NewGuid().GetHashCode());
        }

        /// <summary>
        /// 获取随机时间值
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static DateTime Next(DateTime min, DateTime max)
        {
            if (max < min) throw new Exception("max cannot be larger than min");
            double interval = (max - min).TotalSeconds;
            return min.AddSeconds(Next(interval));
        }

        public static IEnumerable<int> Generate(int min, int max, int n)
        {
            for (int i = 0; i < n; i++)
            {
                yield return RandomHelper.Next(min, max);
            }
            yield break;
        }

        #region  Private 

        /// <summary>
        /// 在指定字符串描述的整数之间获取随机值
        /// </summary>
        /// <returns></returns>
        private static string NextInt(string minValue, string maxValue)
        {
            int compareResult = minValue.CompareAsNumber(maxValue);
            if (compareResult > 1) throw new Exception("minValue cannot be bigger than maxValue");
            if (compareResult == 0) return minValue;
            string returnResult = string.Empty;
            bool minNegative = minValue[0] == '-';
            bool maxNegative = maxValue[0] == '-';
            string minString = minValue.TrimStart('-');
            string maxString = maxValue.TrimStart('-');
            if (minString.Length <= 9 && maxString.Length <= 9)
            {
                int min = int.Parse(minValue);
                int max = int.Parse(maxValue);
                int index = NewRandom().Next(Math.Min(min, max), Math.Max(min, max));
                returnResult = index.ToString();
            }
            else
            {
                int minLength = minString.Length;
                int maxLength = maxString.Length;
                int max = maxLength;
                if (minLength != maxLength)
                {
                    max = Math.Max(minLength, maxLength);
                    minString = minString.PadLeft(max, '0');
                    maxString = maxString.PadLeft(max, '0');
                }

                if (minString.CompareTo(maxString) > -1)
                {
                    string temp = maxString;
                    maxString = minString;
                    minString = temp;
                }

                // 将两个数值字符串按每9位截取成可处理的int[]
                for (int i = 0; i <= max / 9; i++)
                {
                    int subLength = max - i * 9 < 9 ? max - i * 9 : 9; // 截取长度
                    string minSub = minString.Substring(i * 9, subLength).TrimStart('0');
                    int minSegment = minSub == "" ? 0 : int.Parse(minSub);
                    string maxSub = maxString.Substring(i * 9, subLength).TrimStart('0');
                    int maxSegment = maxSub == "" ? 0 : int.Parse(maxSub);
                    if (i == 0)
                    {
                        // 支持负数
                        minSegment = minNegative ? -minSegment : minSegment;
                        maxSegment = maxNegative ? -maxSegment : maxSegment;
                    }
                    int randomSegment = 0;
                    if (i == 0)
                    {
                        randomSegment = NewRandom().Next(Math.Min(minSegment, maxSegment), Math.Max(minSegment, maxSegment));
                    }
                    else
                    {
                        // 如果不是第一个随机段，则无所谓大小，只在乎位数
                        randomSegment = NewRandom().Next(0, (int)Math.Pow(10, subLength));
                    }
                    returnResult += randomSegment.ToString().PadLeft(subLength, '0');
                }
            }
            return returnResult.Length == 1 ? returnResult : returnResult.TrimStart('0');
        }

        #endregion
    }
}
