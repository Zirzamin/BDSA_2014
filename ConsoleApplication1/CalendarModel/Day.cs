using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.CalendarModel
{
	class Day
	{
		DateTime date;
		List<Entry> entries;

		public Day(DateTime d)
		{
			date = d;
			entries = new List<Entry>();
		}

		public DateTime getDate()
		{
			return date;
		}

		List<Entry> getEntries()
		{
			return entries;
		}

		public void createEntry(Entry e) {
			entries.Add(e);
		}

		public void deleteEntry(Entry e) {
			entries.Remove(e);
		}
	}
}
