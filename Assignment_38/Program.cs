
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Assignment_38
{
	public class Program
	{
		static void Main(string[] args)
		{
			var eval = "5 1 2 + 4 * + 3 - 12 - 5 pow 7 -"; // result 25
			Console.WriteLine(eval);

			Dictionary<String, IOperation> dictionary = new Dictionary<string, IOperation>();
			
			dictionary.Add("sqrt", new UnaryOperation(x => Math.Sqrt(x)));
			dictionary.Add("abs", new UnaryOperation((x) => Math.Abs(x)));
			dictionary.Add("+", new BinaryOperation((x, y) => (x + y)));
			dictionary.Add("-", new BinaryOperation((x, y) => (x - y)));
			dictionary.Add("*", new BinaryOperation((x, y) => (x * y)));
			dictionary.Add("/", new BinaryOperation((x, y) => (x / y)));
			dictionary.Add("pow", new BinaryOperation((x, y) => Math.Pow(x, y)));
			dictionary.Add("^", new BinaryOperation((x, y) => Math.Pow(x, y)));

			double res = 0;
			try
			{
				res = doMath(eval, dictionary);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				Console.ReadKey();
				return;
			}

			Console.WriteLine("= " + res);

			Console.ReadKey();
		}

		public static double doMath(string eval, Dictionary<string, IOperation> dictionary)
		{
			string[] split = eval.Split(' ');
			List<double> stack = new List<double>();

			double tempResult = 0;

			for (int i = 0; i < split.Length; i++)
			{
				double temp;
				if (double.TryParse(split[i], NumberStyles.Any, CultureInfo.InvariantCulture, out temp))
				{
					stack.Add(temp);
				}
				else
				{
					try
					{
						IOperation oper = dictionary[split[i]];

						if (oper is UnaryOperation)
						{
							try
							{
								tempResult = oper.Execute(stack[stack.Count - 1]);
								stack.RemoveAt(stack.Count - 1);
								stack.Add(tempResult);
							}
							catch (Exception e)
							{
								throw new Exception("Not enough values in the stack. Invalid formula");
							}

						}
						else if (oper is BinaryOperation)
						{
							try
							{
								tempResult = oper.Execute(stack[stack.Count - 2], stack[stack.Count - 1]);
								stack.RemoveAt(stack.Count - 2);
								stack.RemoveAt(stack.Count - 1);
								stack.Add(tempResult);
							}
							catch (Exception e)
							{
								throw new Exception("Not enough values in the stack. Invalid formula");
							}
						}
					}
					catch (Exception e)
					{
						throw new Exception("Unknown operation in formula");
					}
				}
			}

			if (stack.Count == 1)
				return stack[0];
			else
			{
				throw new Exception("More than 1 value in the stack. Invalid formula");
			}
		}
	}


	public interface IOperation
	{
		double Execute(double arg1, params double[] argn);
	}


	public class UnaryOperation : IOperation
	{
		public delegate double Operation(double d);

		private Operation operation;

		public UnaryOperation(Operation op)
		{
			operation = op;
		}

		public double Execute(double arg1, params double[] argn)
		{
			return operation(arg1);
		}
	}


	public class BinaryOperation : IOperation
	{
		public delegate double Operation(double d1, double double2);

		private Operation operation;

		public BinaryOperation(Operation op)
		{
			operation = op;
		}

		public double Execute(double arg1, params double[] argn)
		{
			return operation(arg1, argn[0]);
		}
	}

}