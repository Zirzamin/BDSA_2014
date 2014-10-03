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
        public void regexp_url()
        {
            string expected = "http://msdn.microsoft.com/en-us/library/ms182524%28v=vs.90%29.aspx";
            string regEx = @"(([\w-]+://?|www[.])[^\s()<>]+)";

            string actualMatch = Regex.Match(expected, regEx, RegexOptions.IgnoreCase).ToString();

            Assert.AreEqual<string>(expected, actualMatch, "You have failed!!");
        }

		[TestMethod]
		public void regexp_date()
		{
			string expected = "Sat, 25 Aug 2012 18:36:26 -0400";
			string regEx = @"(Sun|Mon|Tue|Wed|Thu|Fri|Sat),\s+([0-9]?[1-9])\s+(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\s+[0-9]{4,4}\s+((2[0-3])|([0-1][0-9])):([0-5][0-9]):([0-5][0-9])\s+([-\+][0-9]{2}[0-5][0-9])";

			string actualMatch = Regex.Match(expected, regEx, RegexOptions.IgnoreCase).ToString();

			Assert.AreEqual<string>(expected, actualMatch, "You have failed!!");
		}

		[TestMethod]
		public void regexp_word()
		{
			string test = "some sentence blah blah";
			string expected = "sentence";
			string regEx = @"(?i)Sent[\w'-]*";

			string actualMatch = Regex.Match(test, regEx, RegexOptions.IgnoreCase).ToString();

			Assert.AreEqual<string>(expected, actualMatch, "You have failed!!");
		}
    }
}
