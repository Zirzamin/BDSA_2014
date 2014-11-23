using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.CalendarModel;

namespace ConsoleApplication1.CalendarView
{
	class ViewDay : View
	{
		public ViewDay(IModel m) 
			: base(m) 
		{
		}

		override public void view()
		{
			Day d = model.getDay();
			//	here display the day
		}
	}
}
