/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/11/18 19:26:18
 * ***********************************************/
using System.Text.RegularExpressions;

namespace Dev.Utils.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class IPAddressHelper
    {
        /// <summary>
        /// Indicates whether the specified string is a valid IPv4 address.
        /// 验证是否有效的IPv4地址。
        /// </summary>
        /// <param name="ipAddress">String of IPv4 address.</param>
        /// <returns></returns>
        public static bool IsValidIPv4(string ipAddress)
        {
            return Regex.IsMatch(ipAddress, @"^([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-1][0-9]|22[0-3])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$");
        }
    }
}
