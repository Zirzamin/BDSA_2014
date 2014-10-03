using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment_38;

namespace UnitTests
{
	[TestClass]
	public class Assignment38_Test
	{
		[TestMethod]
		public void polish2_1()
		{
			string test = "1 2 + 6 + sqrt";
			double expected = 3;

			Dictionary<String, IOperation> dictionary = new Dictionary<string, IOperation>();

			dictionary.Add("sqrt", new UnaryOperation(x => Math.Sqrt(x)));
			dictionary.Add("+", new BinaryOperation((x, y) => (x + y)));
			
			double actual = Program.doMath(test, dictionary);

			Assert.AreEqual(expected, actual, "fail");
		}

		[TestMethod]
		public void polish2_2()
		{
			string test = "1 2 + 6 + sqrt 7";

			Dictionary<String, IOperation> dictionary = new Dictionary<string, IOperation>();

			dictionary.Add("sqrt", new UnaryOperation(x => Math.Sqrt(x)));
			dictionary.Add("+", new BinaryOperation((x, y) => (x + y)));

			try
			{
				Program.doMath(test, dictionary);
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
		public void polish2_3()
		{
			string test = "1 2 + 6 + sqrt 7 unknown";

			Dictionary<String, IOperation> dictionary = new Dictionary<string, IOperation>();

			dictionary.Add("sqrt", new UnaryOperation(x => Math.Sqrt(x)));
			dictionary.Add("+", new BinaryOperation((x, y) => (x + y)));

			try
			{
				Program.doMath(test, dictionary);
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
