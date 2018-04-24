/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2017/11/18 19:31:02
 * ***********************************************/
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace System.Xml
{
    /// <summary>
    /// XML扩展类
    /// </summary>
    public static class XmlExtensions
    {
        #region XML

        /// <summary>
        /// Get or set value for the specified attribute.
        /// 获取或设置属性值
        /// </summary>
        /// <param name="this"></param>
        /// <param name="attrName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Attr(this XmlNode @this, string attrName, object value = null)
        {
            var attr = @this.Attributes[attrName];
            if (value != null && attr != null) attr.Value = value.ToString();
            return attr?.Value;
        }

        #endregion

        #region XDocument

        /// <summary>
        /// 获取XElement的属性值，若无指定属性，则返回null
        /// </summary>
        /// <param name="xele"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Attr(this XElement xele, string name, object value)
        {
            var attr = xele.Attribute(name);
            if (attr != null && value != null)
                return attr.Value = value.ToString();
            return attr?.Value;
        }

        /// <summary>
        /// 获取布尔属性值
        /// </summary>
        /// <param name="ele"></param>
        /// <param name="name"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool AttrBoolean(this XElement ele, string name, string pattern = @"^true|1$")
        {
            pattern = string.IsNullOrWhiteSpace(pattern) ? "" : pattern;
            var attr = ele.Attribute(name);
            if (attr != null)
            {
                return Regex.IsMatch(attr.Value, pattern);
            }

            return false;
        }

        public static XElement AddBeforeChild(this XElement xele, object content, Func<XElement, bool> predicate)
        {
            XElement ele = (from e in xele.Elements()
                            where predicate(e)
                            select e).FirstOrDefault();
            ele.AddBeforeSelf(content);
            return xele;
        }

        public static XElement AddBeforeChild(this XElement xele, Func<XElement, bool> predicate, params object[] content)
        {
            XElement ele = (from e in xele.Elements()
                            where predicate(e)
                            select e).FirstOrDefault();
            ele.AddBeforeSelf(content);
            return xele;
        }

        public static XAttribute RemoveAttribute(this XElement xele, string name)
        {
            XAttribute attr = xele.Attribute(name);
            if (attr != null)
            {
                attr.Remove();
                return attr;
            }
            return null;
        }

        public static XAttribute UpdateAttribute(this XElement xele, string name, object value)
        {
            XAttribute attr = xele.Attribute(name);
            if (attr == null) return null;
            attr.SetValue(value);
            return attr;
        }

        #endregion
    }
}
