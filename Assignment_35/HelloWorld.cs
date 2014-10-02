using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class HelloWorld
    {
        static void _Main(string[] args)
        {
            Console.WriteLine("Hello world\n\n\n");

            int i = 0;
            foreach (string a in args)
            {
                Console.WriteLine("arg {0}: {1}", i++, a);
            }

            Console.ReadLine();
        }
    }
}
