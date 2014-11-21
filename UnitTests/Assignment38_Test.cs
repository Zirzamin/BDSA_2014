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
		public void polish2_1()	//	OK case
		{
			Dictionary<String, IOperation> dictionary = new Dictionary<string, IOperation>();
			dictionary.Add("sqrt", new UnaryOperation(x => Math.Sqrt(x)));
			dictionary.Add("+", new BinaryOperation((x, y) => (x + y)));
			dictionary.Add("-", new BinaryOperation((x, y) => (x - y)));
			dictionary.Add("*", new BinaryOperation((x, y) => (x * y)));
			dictionary.Add("/", new BinaryOperation((x, y) => (x / y)));
			
			string test = "1 2 + 6 +";
			double expected = 9;
			double actual = Program.doMath(test, dictionary);
			Assert.AreEqual(expected, actual, "fail 1");

			test = "17 5 - 4 + sqrt";
			expected = 4;
			actual = Program.doMath(test, dictionary);
			Assert.AreEqual(expected, actual, "fail 2");

			test = "2 2 * 2 * 2 * 2 *";
			expected = 32;
			actual = Program.doMath(test, dictionary);
			Assert.AreEqual(expected, actual, "fail 3");

			test = "4 10 - 6 * -1 * 6 /";
			expected = 6;
			actual = Program.doMath(test, dictionary);
			Assert.AreEqual(expected, actual, "fail 4");
		}

		[ExpectedException(typeof(ExtraValueException))]
		[TestMethod]
		public void polish2_2()	//	extra value in a stack, exception
		{
			string test = "1 2 + 6 + sqrt 7";

			Dictionary<String, IOperation> dictionary = new Dictionary<string, IOperation>();

			dictionary.Add("sqrt", new UnaryOperation(x => Math.Sqrt(x)));
			dictionary.Add("+", new BinaryOperation((x, y) => (x + y)));

			Program.doMath(test, dictionary);
		}

		[ExpectedException(typeof(TooFewValuesException))]
		[TestMethod]
		public void polish2_4()	//	extra operator in a stack, exception
		{
			string test = "1 2 + 6 + sqrt 7 + +";

			Dictionary<String, IOperation> dictionary = new Dictionary<string, IOperation>();

			dictionary.Add("sqrt", new UnaryOperation(x => Math.Sqrt(x)));
			dictionary.Add("+", new BinaryOperation((x, y) => (x + y)));

			Program.doMath(test, dictionary);
		}

		[ExpectedException(typeof(UnknownOperatorException))]
		[TestMethod]
		public void polish2_3()	//	unknown operator, exception
		{
			string test = "1 2 + 6 + sqrt 7 unknown";

			Dictionary<String, IOperation> dictionary = new Dictionary<string, IOperation>();

			dictionary.Add("sqrt", new UnaryOperation(x => Math.Sqrt(x)));
			dictionary.Add("+", new BinaryOperation((x, y) => (x + y)));

			Program.doMath(test, dictionary);
		}
	}
}
