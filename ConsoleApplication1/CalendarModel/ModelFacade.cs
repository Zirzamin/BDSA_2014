using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.CalendarModel
{
	class ModelFacade : IModel
	{
		List<Day> days;	//	imagine that this is sorted by date list of days

		public ModelFacade()
		{
			days = new List<Day>();
		}

		//	possible implementation of getters for view updating
		public List<Day> getMonth() {
			int n = getCurrentMonthLength();
			int current = getCurrentDayIndex();

			return days.GetRange(current-n, n);
		}

		public List<Day> getWeek()
		{
			int current = getCurrentDayIndex();

			return days.GetRange(current-7, 7);
		}

		public Day getDay()
		{
			int current = getCurrentDayIndex();

			return days[current];
		}

		private int getCurrentMonthLength() {
			//	somehow get number of days in the current month
			return 0;
		}

		private int getCurrentDayIndex()
		{
			return days.FindIndex(
			delegate(Day d)
			{
				return d.getDate().Equals(DateTime.Now);
			}
			);
		}
	}
}
