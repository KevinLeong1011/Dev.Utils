/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/11/18 19:24:44
 * ***********************************************/
using System;

namespace Dev.Utils.Helpers
{
    /// <summary>
    /// 环境变量帮助类
    /// </summary>
    public static class EnvironmentHelper
    {
        /// <summary>
        /// Get or set system variable value.
        /// 获取或设置指定的系统变量值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SystemVar(string name, string value = null)
        {
            return EnvirVar(name, EnvironmentVariableTarget.Machine, value);
        }

        /// <summary>
        /// Get or set user variable value.
        /// 获取或设置用户变量值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string UserVar(string name, string value = null)
        {
            return EnvirVar(name, EnvironmentVariableTarget.User, value);
        }

        /// <summary>
        /// 
        /// 向指定名称的系统变量追加值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void AppendSystemVar(string name, string value)
        {
            string oldValue = SystemVar(name);
            SystemVar(name, oldValue + ";" + value);
        }

        /// <summary>
        /// 删除系统变量
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="keys"></param>
        public static void DeleteSystemVar(string name, bool ignoreCase, params string[] keys)
        {
            string[] valueArr = SystemVar(name).Split(';');
            string newValue = string.Empty;
            for (int i = 0, l = valueArr.Length; i < l; i++)
            {
                foreach (string key in keys)
                {
                    string value = ignoreCase ? valueArr[i].ToLower() : valueArr[i];
                    string k = ignoreCase ? key.ToLower() : key;
                    if (!value.Contains(k))
                    {
                        newValue += valueArr[i] + ";";
                    }
                }
            }
            SystemVar(name, newValue);
        }

        /// <summary>
        /// 删除系统变量Path中包含指定关键字的变量值
        /// </summary>
        /// <param name="keys"></param>
        public static void DeletePath(params string[] keys)
        {
            DeleteSystemVar("Path", true, keys);
        }

        static string EnvirVar(string name, EnvironmentVariableTarget target, string value = null)
        {
            if (value == null)
            {
                return Environment.GetEnvironmentVariable(name, target);
            }
            else
            {
                Environment.SetEnvironmentVariable(name, value, target);
                return value;
            }
        }
    }
}
