using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment_36;

namespace UnitTests
{
	[TestClass]
	public class Assignment36_Test
	{
		[TestMethod]
		public void polish1()
		{
			string test = "3 8 + 6 - 2 *";

			double computed = Assignment36.doMath(test);
			double expected = 10;

			Assert.AreEqual(expected, computed, "failed");
		}

		[TestMethod]
		public void polish2()
		{
			string test = "3 8 + 6 - 2 * 10";

			try
			{
				Assignment36.doMath(test);
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

		[ExpectedException(typeof(Exception))]
		[TestMethod]
		public void polish3()
		{
			string test = "3 8 + 6 - 2 unknown";

			try
			{
				Assignment36.doMath(test);
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


	}
}
