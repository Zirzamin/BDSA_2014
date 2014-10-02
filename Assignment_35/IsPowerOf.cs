using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDSA12
{

    class Program
    {

        static bool IsPowerOf(int a, int b)
        {
            // YOUR CODE GOES HERE
	        if (a == 0 || b == 0)
	        {
		        throw new Exception("One of the arguments is 0");
	        }

            if (a == 1)
            {
                return true;
            }
            if (a % b == 0)
            {
                int c = a / b;
                return IsPowerOf(c, b);
            }
            return false;
        }

        static void Main(string[] args)
        {
            //MODIFY THIS SECTION TO USE args PARAMETERS
	        if (args.Length != 2)
	        {
		        Console.WriteLine("Incorrect input. Should be 2 arguments");
		        Console.ReadKey();
		        return;
	        }

	        int a1 = 0;
	        int a2 = 0;
			Int32.TryParse(args[0], out a1);
			Int32.TryParse(args[1], out a2);

	        bool res = false;
	        try
	        {
		         res = IsPowerOf(a1, a2);
	        }
	        catch (Exception e)
	        {
				Console.WriteLine(e.ToString());
		        Console.ReadKey();
		        return;
	        }
	        
            Console.WriteLine(res);

            Console.ReadKey();
        }
    }
}
