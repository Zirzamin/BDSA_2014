using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Assignment_37
{
    static class TextFileReader
    {
        public static void Main(string[] args)
        {
            string keyLine = "";
            if(args.Length != 0)
                keyLine = args[0];

            string keyword = "isaac";
            
            Console.Write("Some normal text, ");
            // Changes the background color of the console
            Console.BackgroundColor = ConsoleColor.Yellow;
            // Changes the color of the font
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Some highlighted text");
            // Resets the colors to the default
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(", and some green text.\n");
            Console.ResetColor();

            //  ^(([^:/?#]+):)?(//([^/?#]*))?([^?#]*)(\?([^#]*))?(#(.*))? -- URL
            //  /^(?:(Sun|Mon|Tue|Wed|Thu|Fri|Sat),\s+)?(0[1-9]|[1-2]?[0-9]|3[01])\s+(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\s+(19[0-9]{2}|[2-9][0-9]{3})\s+(2[0-3]|[0-1][0-9]):([0-5][0-9])(?::(60|[0-5][0-9]))?\s+([-\+][0-9]{2}[0-5][0-9]|(?:UT|GMT|(?:E|C|M|P)(?:ST|DT)|[A-IK-Z]))(\s+|\(([^\(\)]+|\\\(|\\\))*\))*$/ -- Date

            var content = TextFileReader.ReadFile("../../TestFile.txt");
            var lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                var matches = Regex.Matches(line, keyword, RegexOptions.IgnoreCase);
                var arr = Regex.Split(line, keyword, RegexOptions.IgnoreCase);

                for (int i = 0; i < arr.Length; ++i)
                {
                    Console.Write(arr[i]);
                    if (i == arr.Length - 1)
                        break;

                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write(matches[i].ToString());
                    Console.ResetColor();
                }

                Console.WriteLine("");
            }

            Console.ReadKey();

        }

        public void findKeyword()
        {
            
        }

        public static string ReadFile(string filename)
        {
            try
            {
                using (var reader = new StreamReader(filename))
                {
                    //This reads the entire file
                    return reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                //Might happen if the file is not text or non-existent
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return e.ToString();
            }
        }
    }
}