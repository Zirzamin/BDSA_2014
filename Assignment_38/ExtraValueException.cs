using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_38
{
	public class ExtraValueException : Exception
	{
		public ExtraValueException() : base() { 
		}

		public ExtraValueException(string s) : base(s) {
		}
	}
}
