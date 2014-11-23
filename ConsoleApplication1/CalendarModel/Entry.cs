using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.CalendarModel
{
	class Entry
	{
		DateTime date;
		string subject;
		string description;
		DateTime notificationDate;
		int ID;
		User owner;
		string place;
		List<User> sharedWith;

		public Entry(string s, DateTime d)
		{
			date = d;
			subject = s;
			sharedWith = new List<User>();
		}

		//	this is initial system decomposition, so we are not going to implement changing all this fields
		public void setDescription(string d)
		{
			description = d;
		}
	}
}
