/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2018/3/26 21:15:30
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace System.IO
{
    /// <summary>
    /// 
    /// </summary>
    public class IOHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string FindFile(string directory, string fileName)
        {
            string path = null;
            foreach (string file in Directory.GetFiles(directory))
            {
                if (fileName.ToLower() == Path.GetFileNameWithoutExtension(file).ToLower() ||
                    fileName.ToLower() == Path.GetFileName(file).ToLower())
                {
                    return file;
                }
            }
            foreach (string dir in Directory.GetDirectories(directory))
            {
                path = FindFile(dir, fileName);
                if (!path.NullOrWhiteSpace()) return path;
            }
            return path;
        }

        public static string GetCurrentLocation()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public static string Parse(string path, string basePath = null)
        {
            if (path[1] == ':') return path;
            string[] array = path.Split(new char[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            string result = (basePath.NullOrWhiteSpace() ? GetCurrentLocation() : basePath).TrimEnd('/').TrimEnd('\\');
            foreach (string part in array)
            {
                if (part == "..")
                {
                    int index = result.LastIndexOfAny(new char[] { '\\', '/' });
                    result = result.Substring(0, index);
                }
                else
                {
                    result = Path.Combine(result, part);
                }
            }
            return result;
        }
    }
}
