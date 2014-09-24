using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Assignment_37
{
    static class TextFileReader
    {
        public static void Main(string[] args)
        {
            string keyLine = "";
            if (args.Length != 0)
                keyLine = args[0];

            // ReSharper disable once ConvertToConstant.Local
            var keyword = "isaac";

            var urlReg = "((?:http|https)(?::\\/{2}[\\w]+)(?:[\\/|\\.]?)(?:[^\\s\"]*))"; // -- URL
            var dateReg =
                "((?:Jan(?:uary)?|Feb(?:ruary)?|Mar(?:ch)?|Apr(?:il)?|May|Jun(?:e)?|Jul(?:y)?|Aug(?:ust)?|Sep(?:tember)?|Sept|Oct(?:ober)?|Nov(?:ember)?|Dec(?:ember)?))";

                //"/^(?:(Sun|Mon|Tue|Wed|Thu|Fri|Sat),\s+)?(0[1-9]|[1-2]?[0-9]|3[01])\s+(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\s+(19[0-9]{2}|[2-9][0-9]{3})\s+(2[0-3]|[0-1][0-9]):([0-5][0-9])(?::(60|[0-5][0-9]))?\s+([-\+][0-9]{2}[0-5][0-9]|(?:UT|GMT|(?:E|C|M|P)(?:ST|DT)|[A-IK-Z]))(\s+|\(([^\(\)]+|\\\(|\\\))*\))*$/"; // -- Date

            var content = TextFileReader.ReadFile("../../TestFile.txt");
            var words = Regex.Split(content, @"\ |\r");

            foreach (var word in words)
            {
                //test(word, keyword);
                SearchKeyword(word, keyword, urlReg, dateReg);

                Console.Write(" ");
            }

            Console.ReadKey();

        }

        public static void print(string word, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(word);
            Console.ResetColor();
        }

        public static void print(string word, ConsoleColor ForegroundColor, ConsoleColor BackgroundColor)
        {
            Console.BackgroundColor = BackgroundColor;
            Console.ForegroundColor = ForegroundColor;
            Console.Write(word);
            Console.ResetColor();
        }

        private static void SearchKeyword(string word, string keyword, string urlReg, string dateReg)
        {
            var flag = 0;


            if (Regex.IsMatch(word, urlReg, RegexOptions.IgnoreCase))
            {
                flag = 1;
                if (Regex.IsMatch(word, keyword, RegexOptions.IgnoreCase))
                {
                    var sWord = Regex.Split(word, keyword, RegexOptions.IgnoreCase);
                    var matches = Regex.Matches(word, keyword, RegexOptions.IgnoreCase);
                    
                    for (var i = 0; i < sWord.Length; ++i)
                    {
                        print(sWord[i], ConsoleColor.Blue);
                        if (i == sWord.Length - 1)
                            break;

                        print(matches[i].ToString(), ConsoleColor.Black, ConsoleColor.DarkYellow);
                    }
                }
                else
                {
                    print(word, ConsoleColor.Blue);
                }

            }
            if (Regex.IsMatch(word, dateReg, RegexOptions.IgnoreCase))
            {
                flag = 1;
                print(word,ConsoleColor.DarkRed);

            }
            if (Regex.IsMatch(word, keyword, RegexOptions.IgnoreCase) & flag == 0)
            {
                flag = 1;

                var sWord = Regex.Split(word, keyword, RegexOptions.IgnoreCase);
                var matches = Regex.Matches(word, keyword, RegexOptions.IgnoreCase);

                for (var i = 0; i < sWord.Length; ++i)
                {
                    Console.Write(sWord[i]);
                    if (i == sWord.Length - 1)
                        break;

                    print(matches[i].ToString(), ConsoleColor.Black, ConsoleColor.DarkYellow);
                }
            }


            if (flag == 0)
            {
                Console.Write(word);
            }
        }

        public static void HighLight()
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