using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.CalendarModel;

namespace ConsoleApplication1.CalendarView
{
	class ViewWeek : View
	{
		public ViewWeek(IModel m)
			: base(m)
		{
		}

		override public void view()
		{
			foreach (Day d in model.getWeek())
			{
				//	display somehow
			}
		}
	}
}
