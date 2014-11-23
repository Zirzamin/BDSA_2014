using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.CalendarModel;
using ConsoleApplication1.CalendarController;
using ConsoleApplication1.CalendarView;

namespace ConsoleApplication1
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
