using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_38
{
	public class UnknownOperatorException : Exception
	{
		public UnknownOperatorException() : base() { 
		}

		public UnknownOperatorException(string s) : base(s) {
		}
	}
}
