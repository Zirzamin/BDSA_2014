using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.CalendarModel
{
	class User
	{
		static int userCount = 0;

		int ID;
		string name;
		string email;

		public User(string n, string em)
		{
			name = n;
			email = em;
			ID = userCount++;
		}
	}
}
