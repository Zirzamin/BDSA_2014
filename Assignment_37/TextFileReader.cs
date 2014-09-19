using System;
using System.IO;

namespace Assignment_37
{
    /// <summary>
    ///   Utility class for reading text files into a single string.
    /// </summary>
    static class TextFileReader
    {
        /// <summary>
        /// Reads a text file and returns its content as a string.
        /// </summary>
        /// <param name="filename">The file name to be read, including the path.</param>
        /// <returns>A string representing the content of the file</returns>
        /// <example>
        /// <code><pre>
        public static void Main()
        {


            Console.Write("Some normal text, ");
            // Changes the background color of the console
            Console.BackgroundColor = ConsoleColor.Yellow;
            // Changes the color of the font
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Some highlighted text");
            // Resets the colors to the default
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(", and some green text.");
            Console.ResetColor();

            Console.ReadLine();


            var content = TextFileReader.ReadFile("../../TestFile.txta");
            var lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                Console.Out.WriteLine(line);
            }

            Console.ReadLine();
        }
        /// </pre></code>
        /// </example>
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