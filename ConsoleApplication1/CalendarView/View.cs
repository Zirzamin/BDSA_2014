using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarSystem.CalendarModel;

namespace CalendarSystem.CalendarView
{
	abstract class View : IView
	{
		protected IModel model;

		protected View(IModel m)
		{
			model = m;
		}

		public abstract void view();
	}
}
