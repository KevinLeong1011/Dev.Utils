/* ***********************************************
 * Author : Kevin
 * Function : 
 * Created : 2018/4/10 1:19:11
 * ***********************************************/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dev.Utils.Test
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class IOHelperTest
    {
        [TestMethod]
        public void ParseTest()
        {
            string path = IOHelper.Parse("../../Test/sample.txt", @"C:\New\Files\Coding\");
            Assert.AreEqual(@"C:\New\Test\sample.txt", path);
        }
    }
}
