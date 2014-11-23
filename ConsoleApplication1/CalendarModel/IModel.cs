﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.CalendarModel
{
	interface IModel
	{
		//	here bunch of methods every model should implement
		List<Day> getMonth();
		List<Day> getWeek();
		Day getDay();
	}
}
