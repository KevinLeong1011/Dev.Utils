/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/11/19 20:39:41
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Dev.Utils.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class FormatHelper
    {
        /// <summary>
        /// Get parameters that match the specified format string from this. Example: "Tom is playing with Mary.".GetParameters("{0} is playing with {1}.")---> ["Tom", "Mary"]
        /// </summary>
        /// <param name="source"></param>
        /// <param name="formatString"></param>
        /// <returns></returns>
        public static string[] GetParameters(string source, string formatString)
        {
            string[] parts = formatString.SplitByRegex(@"\{\d+\}", StringSplitOptions.RemoveEmptyEntries);
            string id = Guid.NewGuid().ToString();
            parts.ForEach(x =>
            {
                source = source.Replace(x, id);
            });
            return source.Split(id, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
