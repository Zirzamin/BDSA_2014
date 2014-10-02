using System;
using System.Collections.Specialized;
using Assignment_37;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAssignment_37
{
    [TestClass]
    public class TextFileReaderTest
    {
        [TestMethod]
        public void DoSearching_Test()
        {
            // arrange
            //string RegExUrl = @"(([\w-]+://?|www[.])[^\s()<>]+)\s+";
            //string RegExDate = @"(Sun|Mon|Tue|Wed|Thu|Fri|Sat),\s+([0-9]?[1-9])\s+(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\s+[0-9]{4,4}\s+((2[0-3])|([0-1][0-9])):([0-5][0-9]):([0-5][0-9])\s+([-\+][0-9]{2}[0-5][0-9])";
            //string content = TextFileReader.ReadFile("../../TestFile.txt");
            //string[] keys = {"Isaac", "*"};

            string regexExpected = @"\s(?i)Isaac\s[\w'-]*\s";

            // act

            TextFileReader.DoSearching();

            // assert
            Assert.AreEqual(regexExpected, TextFileReader.,"Fail!");

        }
    }
}
