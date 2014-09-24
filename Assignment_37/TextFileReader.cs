using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;

namespace Assignment_37
{
	static class TextFileReader
	{
		private const string RegExUrl = @"(([\w-]+://?|www[.])[^\s()<>]+)";
		private const string RegExDate = @"(Sun|Mon|Tue|Wed|Thu|Fri|Sat),\s+([0-9]?[1-9])\s+(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\s+[0-9]{4,4}\s+(2[0-3]|[0-1][0-9]):([0-5][0-9]):([0-5][0-9])\s+([-\+][0-9]{2}[0-5][0-9])";
		private static string content;
		private static string[] keys;
		
		public static void Main(string[] args)
		{
			content = TextFileReader.ReadFile("../../TestFile.txt");

			var keyLine = "";
			if (args.Length != 0)
			{
				keyLine = args[0];
			}
			else
			{
				Console.WriteLine("You have not entered anything");
				return;
			}

			Console.WriteLine(keyLine + "\n\n");

			keys = Regex.Split(keyLine, @"\+");

			if (keys.Length == 0 || keys.Length > 2)
			{
				Console.WriteLine("Incorrect input");
				return;
			}

			DoSearching();

			/*Console.Write("Some normal text, ");
			// Changes the background color of the console
			Console.BackgroundColor = ConsoleColor.Yellow;
			// Changes the color of the font
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Write("Some highlighted text");
			// Resets the colors to the default
			Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(", and some green text.\n");
			Console.ResetColor();*/

			Console.ReadKey();

		}

		public static void DoSearching()
		{
			string[] exps = new string[keys.Length];		//	array for strings containing reg expressions for every keyword

			for (var i=0; i<keys.Length; ++i)
			{
				exps[i] = keys[i].Replace(@"*", @"\w*").Trim();		//	replace * sign with regex
			}

			string keyQuery = string.Join(" ", exps);		// make final expression for keywords
			Console.WriteLine(keyQuery + "\n\n");

			string query = "(" + keyQuery + ")|(" + RegExDate +")|(" + RegExUrl + ")";
			Console.WriteLine(query + "\n\n");

			string match = Regex.Match(content, query, RegexOptions.IgnoreCase).ToString();

			while (!match.Equals(""))
			{
				Console.WriteLine(content + "\n\n");
				Console.WriteLine(match + "\n\n");
				match = Regex.Match(content, query, RegexOptions.IgnoreCase).NextMatch().ToString();
				content = content.Substring(content.IndexOf(match) + match.Length);
			}

			//if()

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