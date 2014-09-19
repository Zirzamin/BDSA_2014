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

        public static void Main()
        {
            var content = ReadFile("../../TestFile.txt");
            var lines = content.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            foreach(string line in lines)
        	{
        	    Console.Out.WriteLine(line);
        	}
            Console.ReadKey();
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
            }

            return "";
        }
    }
}