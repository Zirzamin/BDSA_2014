
using System;
using System.Collections.Generic;

namespace Assignment_38
{
	class Program
	{
		static void Main(string[] args)
		{
			var eval = "5 1 2 + 4 * + 3 - 12 - 5 pow"; // result 32

			Dictionary<String, IOperation> dictionary = new Dictionary<string, IOperation>();
			
			dictionary.Add("sqrt", new UnaryOperation(x => Math.Sqrt(x)));
			dictionary.Add("abs", new UnaryOperation((x) => Math.Abs(x)));
			dictionary.Add("+", new BinaryOperation((x, y) => (x + y)));
			dictionary.Add("-", new BinaryOperation((x, y) => (x - y)));
			dictionary.Add("*", new BinaryOperation((x, y) => (x * y)));
			dictionary.Add("/", new BinaryOperation((x, y) => (x / y)));
			dictionary.Add("pow", new BinaryOperation((x, y) => Math.Pow(x, y)));
			
			string[] split = eval.Split(' ');
			List<double> stack = new List<double>();

			double tempResult = 0;

			for (int i = 0; i < split.Length; i++)
			{
				double temp;
				if (double.TryParse(split[i], out temp))
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
								Console.WriteLine("Not enough values in a stack\n" + e.ToString());
								Console.ReadKey();
								return;
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
								Console.WriteLine("Not enough values in a stack\n" + e.ToString());
								Console.ReadKey();
								return;
							}
							
						}
						
					}
					catch (Exception e)
					{
						Console.WriteLine("Unknown operation in formula\n" + e.ToString());
						Console.ReadKey();
						return;
					}
				}
			}

			if (stack.Count == 1)
				Console.WriteLine(stack[0]);
			else
			{
				Console.WriteLine("More than 1 values in stack. Probably formula is wrong");
				Console.ReadKey();
				return;
			}

			Console.ReadKey();
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