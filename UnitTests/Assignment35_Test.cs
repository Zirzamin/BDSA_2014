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

		[TestMethod]
		public void isPowerOf_Zero()
		{
			try
			{
				Program.IsPowerOf(0, 0);
				Assert.Fail();
			}
			catch (AssertFailedException e)
			{
				Assert.Fail();
			}
			catch (Exception e)
			{
				//passed
			}
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
