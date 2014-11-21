using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_38
{
	public class TooFewValuesException : Exception
	{
		public TooFewValuesException() : base() { 
		}

		public TooFewValuesException(string s) : base(s)
		{
		}
	}
}
