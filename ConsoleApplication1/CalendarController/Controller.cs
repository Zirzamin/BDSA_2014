using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.CalendarModel;
using ConsoleApplication1.CalendarView;

namespace ConsoleApplication1.CalendarController
{
	class Controller
	{
		public enum ViewOptions
		{
			MONTH, WEEK, DAY
		}

		IModel model;
		IView view;

		public Controller(IModel m, IView v) 
		{
			model = m;
			view = v;
		}

		//	controller should listen to user actions in the gui and update model, view then listens to changes in model and updates itself
	}
}
