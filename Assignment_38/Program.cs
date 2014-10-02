
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
			
			//IOperation oper = new UnaryOperation(x => Math.Sqrt(x));
			//IOperation oper1 = new BinaryOperation((x, y) => (x + y));

			//Console.WriteLine(oper.Execute(9));
			//Console.WriteLine(oper1.Execute(7, 79));

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
							tempResult = oper.Execute(stack[stack.Count - 1]);
							stack.RemoveAt(stack.Count - 1);
							stack.Add(tempResult);
						}
						else if (oper is BinaryOperation)
						{
							tempResult = oper.Execute(stack[stack.Count - 2], stack[stack.Count - 1]);
							stack.RemoveAt(stack.Count - 2);
							stack.RemoveAt(stack.Count - 1);
							stack.Add(tempResult);
						}
						
					}
					catch (Exception e)
					{
						Console.WriteLine(e.ToString());
					}
				}
			}

			if(stack.Count == 1)
				Console.WriteLine(stack[0]);

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