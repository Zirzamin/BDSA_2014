using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarSystem.CalendarModel;
using CalendarSystem.CalendarController;
using CalendarSystem.CalendarView;

namespace CalendarSystem
{
	class Program
	{
		static void Main(string[] args) {
			IModel model = new ModelFacade();
			IView view = new ViewMonth(model);
			Controller controller = new Controller(model, view);
		}
	}
}
