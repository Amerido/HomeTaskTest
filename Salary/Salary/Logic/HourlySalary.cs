using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary.Logic
{
	/// <summary>
	/// Сотдруники с почасовой оплатой
	/// </summary>
	public class HourlySalary : SalaryBase
	{
		public HourlySalary(string fio, double salary) : base(fio, salary, true)
		{
		}

		protected override double Calculate(double hourSalary)
		{
			return 20.8 * 8 * hourSalary;
		}
	}
}
