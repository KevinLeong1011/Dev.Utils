using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Dev.Utils.Test
{
    public class DateTimeExtensionsTest
    {
        [TestMethod]
        public void LastOfHour()
        {
            DateTime last = new DateTime(2018,1,13,13,20,34).LastOfHour();
            Assert.AreEqual(new DateTime(2018, 1, 13, 13, 59, 59), last);
        }

        [TestMethod]
        public void StartOfHour()
        {
            DateTime last = new DateTime(2018, 1, 13, 13, 20, 34).StartOfHour();
            Assert.AreEqual(new DateTime(2018, 1, 13, 13, 0, 0), last);
        }

        [TestMethod]
        public void LastOfYear()
        {
            DateTime last = new DateTime(2018, 1, 13, 13, 20, 34).LastOfYear();
            Assert.AreEqual(new DateTime(2018, 12, 31, 23, 59, 59), last);
        }

        [TestMethod]
        public void StartOfYear()
        {
            DateTime last = new DateTime(2018, 1, 13, 13, 20, 34).StartOfYear();
            Assert.AreEqual(new DateTime(2018, 1, 1, 0, 0, 0), last);
        }

        [TestMethod]
        public void LastOfMonth()
        {
            DateTime last = new DateTime(2018, 1, 13, 13, 20, 34).LastOfMonth();
            Assert.AreEqual(new DateTime(2018, 1, 31, 23, 59, 59), last);
        }

        [TestMethod]
        public void StartOfMonth()
        {
            DateTime last = new DateTime(2018, 1, 13, 13, 20, 34).StartOfMonth();
            Assert.AreEqual(new DateTime(2018, 1, 1, 0, 0, 0), last);
        }

        [TestMethod]
        public void LastOfWeek()
        {
            DateTime last = new DateTime(2018, 1, 13, 13, 20, 34).LastOfWeek();
            Assert.AreEqual(new DateTime(2018, 1, 14, 23, 59, 59), last);
        }

        [TestMethod]
        public void StartOfWeek()
        {
            DateTime last = new DateTime(2018, 1, 13, 13, 20, 34).StartOfWeek();
            Assert.AreEqual(new DateTime(2018, 1, 8, 0, 0, 0), last);
        }

        [TestMethod]
        public void LastOfDay()
        {
            DateTime last = new DateTime(2018, 1, 13, 13, 20, 34).LastOfDay();
            Assert.AreEqual(new DateTime(2018, 1, 13, 23, 59, 59), last);
        }

        [TestMethod]
        public void StartOfDay()
        {
            DateTime last = new DateTime(2018, 1, 13, 13, 20, 34).StartOfDay();
            Assert.AreEqual(new DateTime(2018, 1, 13, 0, 0, 0), last);
        }

        [TestMethod]
        public void LastOfMinute()
        {
            DateTime last = new DateTime(2018, 1, 13, 13, 20, 34).LastOfMinute();
            Assert.AreEqual(new DateTime(2018, 1, 13, 13, 20, 59), last);
        }

        [TestMethod]
        public void StartOfMinute()
        {
            DateTime last = new DateTime(2018, 1, 13, 13, 20, 34).StartOfMimute();
            Assert.AreEqual(new DateTime(2018, 1, 13, 13, 20, 0), last);
        }

        [TestMethod]
        public void DaysOfMonth()
        {
            int n = new DateTime(2018, 1, 13, 13, 20, 34).DaysOfMonth();
            Assert.AreEqual(31, n);

            n = new DateTime(2018, 2, 13, 13, 20, 34).DaysOfMonth();
            Assert.AreEqual(28, n);
        }
    }
}
