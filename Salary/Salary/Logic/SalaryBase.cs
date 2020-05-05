using System.Collections.Generic;
using System.Linq;
using Salary.Model;

namespace Salary.Logic
{
	public abstract class SalaryBase
	{
		public Employee Empl{get; set;}

		public SalaryBase(string fio, double salary, bool isHourly)
		{
			Empl = new Employee
			{
				FIO = fio,
				Salary = salary,
				IsHourly = isHourly,
				SalarySumm = Calculate(salary)
			};
		}

		protected abstract double Calculate(double salary);

		

	}
}
