/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/6/29 19:05:48
 * ***********************************************/

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public static class MathHelper
    {
        /// <summary>
        /// 求最小值
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static double Min(params double[] numbers)
        {
            if (numbers.Length == 0 || numbers == null) throw new Exception("numbers");
            if (numbers.Length == 1) return numbers[0];
            double min = Math.Min(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                min = Math.Min(min, numbers[i]);
            }
            return min;
        }

        /// <summary>
        /// 求最大值
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static double Max(params double[] numbers)
        {
            if (numbers.Length == 0 || numbers == null) throw new Exception("numbers");
            if (numbers.Length == 1) return numbers[0];
            double max = Math.Max(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                max = Math.Max(max, numbers[i]);
            }
            return max;
        }

        /// <summary>
        /// 求最大公约数
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int GCD(int a, int b)
        {
            if (a < b) { a = a + b; b = a - b; a = a - b; }
            return (a % b == 0) ? b : GCD(a % b, b);
        }

        /// <summary>
        /// 求最小公倍数
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int LCM(int a, int b)
        {
            return a * b / GCD(a, b);
        }

        /// <summary>
        /// 求阶乘
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double Fac(this double n)
        {
            if (n == 0) return 1;
            return n * Fac(n - 1);
        }
    }
}