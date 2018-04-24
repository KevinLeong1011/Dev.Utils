/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/7/25 18:15:29
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Get the last moment of current hour.
        /// 获取当前小时的最后一刻
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime LastOfHour(this DateTime dt)
        {
            DateTime temp = dt.AddHours(1);
            return new DateTime(temp.Year, temp.Month, temp.Day, temp.Hour, 0, 0).AddSeconds(-1);
        }

        /// <summary>
        /// Get the start moment of current hour.
        /// 获取当前小时的开始时刻
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime StartOfHour(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0);
        }

        /// <summary>
        /// Get the last moment.
        /// 获取当天最后时刻
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime LastOfDay(this DateTime dt)
        {
            DateTime temp = dt.AddDays(1);
            return new DateTime(temp.Year, temp.Month, temp.Day).AddSeconds(-1);
        }

        /// <summary>
        /// Get the start moment.
        /// 获取当天开始时刻
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime StartOfDay(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime LastOfWeek(this DateTime dt)
        {
            DayOfWeek day = dt.DayOfWeek;
            return dt.AddDays(7 - (int)day).LastOfDay();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime StartOfWeek(this DateTime dt)
        {
            DayOfWeek day = dt.DayOfWeek;
            return dt.AddDays(1 - (int)day).StartOfDay();
        }

        /// <summary>
        /// 获取当月最后一刻
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime LastOfMonth(this DateTime dt)
        {
            DateTime temp = dt.AddMonths(1);
            return new DateTime(temp.Year, temp.Month, 1).AddSeconds(-1);
        }

        public static DateTime StartOfMonth(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }

        /// <summary>
        /// 获取当年最后一刻
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime LastOfYear(this DateTime dt)
        {
            DateTime temp = dt.AddYears(1);
            return new DateTime(temp.Year, 1, 1).AddSeconds(-1);
        }

        public static DateTime StartOfYear(this DateTime dt)
        {
            return new DateTime(dt.Year, 1, 1);
        }

        public static DateTime LastOfMinute(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 59);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime StartOfMimute(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);
        }

        /// <summary>
        /// 获取所在月份的天数
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int DaysOfMonth(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month + 1, 1).AddDays(-1).Day;
        }
    }
}