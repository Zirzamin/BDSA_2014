using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.CalendarModel;

namespace ConsoleApplication1.CalendarView
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
