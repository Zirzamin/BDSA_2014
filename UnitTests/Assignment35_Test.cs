using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment_35;

namespace UnitTests
{
	[TestClass]
	public class Assignment35_Test
	{
		[TestMethod]
		public void isPowerOf_Test()
		{
			bool computed = Program.IsPowerOf(8, 2);
			bool expected = true;

			Assert.AreEqual(expected, computed, "failed first");
		}

		[ExpectedException(typeof(Exception))]
		[TestMethod]
		public void isPowerOf_Zero()
		{
			bool computed = Program.IsPowerOf(0, 0);
			bool expected = false;

			Assert.AreEqual(expected, computed, "failed second");
		}

		[TestMethod]
		public void isPowerOf_Fail()
		{
			bool computed = Program.IsPowerOf(11, 3);
			bool expected = false;

			Assert.AreEqual(expected, computed, "failed third");
		}
	}
}
