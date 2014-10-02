using System;
using System.Collections.Generic;
using System.Globalization;

namespace Assignment_36
{
    internal class Assignment36
    {
        private static void Main()
        {
            //Evaluating 
            string eval = "5 1 2 + 4 * + 3 - 12 - 5 ^"; // result 32
            Console.WriteLine(eval);

	        double res = 0;
	        try
	        {
		        res = doMath(eval);
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

	    private static double doMath(string eval)
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
					switch (split[i])
					{
						case "+":
							if (stack.Count < 2)
								throw new Exception("Not enough values in stack");

							tempResult = stack[stack.Count - 2] + stack[stack.Count - 1];
							stack.RemoveAt(stack.Count - 2);
							stack.RemoveAt(stack.Count - 1);
							stack.Add(tempResult);
							break;
						case "-":
							if (stack.Count < 2)
								throw new Exception("Not enough values in stack");

							tempResult = stack[stack.Count - 2] - stack[stack.Count - 1];
							stack.RemoveAt(stack.Count - 2);
							stack.RemoveAt(stack.Count - 1);
							stack.Add(tempResult);
							break;
						case "*":
							if (stack.Count < 2)
								throw new Exception("Not enough values in stack");

							tempResult = stack[stack.Count - 2]*stack[stack.Count - 1];
							stack.RemoveAt(stack.Count - 2);
							stack.RemoveAt(stack.Count - 1);
							stack.Add(tempResult);
							break;
						case "/":
							if (stack[stack.Count - 1] == 0)
								throw new Exception("cant devide with 0");

							if (stack.Count < 2)
								throw new Exception("Not enough values in stack");

							tempResult = stack[stack.Count - 2]/stack[stack.Count - 1];
							stack.RemoveAt(stack.Count - 2);
							stack.RemoveAt(stack.Count - 1);
							stack.Add(tempResult);
							break;

						case "^":
							if (stack.Count < 2)
								throw new Exception("Not enough values in stack");

							tempResult = Math.Pow(stack[stack.Count - 2], stack[stack.Count - 1]);
							stack.RemoveAt(stack.Count - 2);
							stack.RemoveAt(stack.Count - 1);
							stack.Add(tempResult);
							break;

						case "cos":
							if (stack.Count < 1)
								throw new Exception("Not enough values in stack");

							tempResult = Math.Cos(stack[stack.Count - 1]);
							stack.RemoveAt(stack.Count - 2);
							stack.RemoveAt(stack.Count - 1);
							stack.Add(tempResult);
							break;

						case "sqrt":
							if (stack.Count < 1)
								throw new Exception("Not enough values in stack");

							tempResult = Math.Sqrt(stack[stack.Count - 1]);
							stack.RemoveAt(stack.Count - 2);
							stack.RemoveAt(stack.Count - 1);
							stack.Add(tempResult);
							break;
						default:
							throw new Exception("There is no such operator");
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
}
