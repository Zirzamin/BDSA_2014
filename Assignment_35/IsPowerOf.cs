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

        static void _Main(string[] args)
        {
            //MODIFY THIS SECTION TO USE args PARAMETERS
            int a1 = Int32.Parse(args[0]);
            int a2 = Int32.Parse(args[1]);
            Console.WriteLine(IsPowerOf(a1, a2));

            Console.ReadLine();
        }
    }
}
