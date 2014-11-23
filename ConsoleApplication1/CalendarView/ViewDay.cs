using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarSystem.CalendarModel;

namespace CalendarSystem.CalendarView
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
