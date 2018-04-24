/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2018/1/13 13:38:40
 * ***********************************************/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Dev.Utils.Test
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class ArrayExtensionsTest
    {
        [TestMethod]
        public void Index()
        {
            int[] array = new int[] { 2, 12, 34, 5, 7 };
            Assert.AreEqual(12, array.Index(1));

            Assert.AreEqual(5, array.Index(5, 5));

            string[] strings = new string[] { "abc", "def" };
            Assert.AreEqual(null, strings.Index(2));
        }

        [TestMethod]
        public void Clear()
        {
            string[] strings = new string[] { "abc", "def", "ghi" };
            bool succeeded = strings.Clear(-2, 2);
            Assert.IsTrue(succeeded);
            Assert.AreEqual("abc", strings[0]);
            Assert.AreEqual(null, strings[1]);
            Assert.AreEqual(null, strings[2]);
            strings = new string[] { "abc", "def", "ghi" };
            strings.Clear(1, 3);
            Assert.IsTrue(succeeded);
            Assert.AreEqual("abc", strings[0]);
            Assert.AreEqual(null, strings[1]);
            Assert.AreEqual(null, strings[2]);

            strings = new string[] { "abc", "def", "ghi" };
            Assert.IsFalse(strings.Clear(-4, 3));

            strings = new string[] { "abc", "def", "ghi" };
            Assert.IsFalse(strings.Clear(4, 3));
        }

        [TestMethod]
        public void Reverse()
        {
            string[] strings = new string[] { "a", "b", "c" };
            strings.Reverse();
            Assert.AreEqual(new string[] { "c", "b", "a" }, strings);
        }

        [TestMethod]
        public void ReverseIndex()
        {
            string[] strings = new string[] { "a", "b", "c" };
            strings.Reverse(1, 2);
            Assert.AreEqual(new string[] { "a", "c", "b" }, strings);
        }
    }
}
