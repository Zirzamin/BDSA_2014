using System;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using Assignment_37;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAssignment_37
{
    [TestClass]
    public class Assignment37_Test
    {
        [TestMethod]
        public void DoSearching_Test()
        {
            string testString = "http://msdn.microsoft.com/en-us/library/ms182524%28v=vs.90%29.aspx";
            string regExUrl = @"(([\w-]+://?|www[.])[^\s()<>]+)";


            // act
            string actualMatch = Regex.Match(testString, regExUrl, RegexOptions.IgnoreCase).ToString();


            // assert
            Assert.AreEqual<string>(testString, actualMatch, "You have failed!!");

        }
    }
}
