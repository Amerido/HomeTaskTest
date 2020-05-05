using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary.Logic
{
	/// <summary>
	/// Сотрудники с фиксированной ставкой
	/// </summary>
	public class FixedSalary : SalaryBase
	{
		public FixedSalary(string fio, double salary) : base(fio, salary, false)
		{
		}

		protected override double Calculate(double fixedSalary)
		{
			return fixedSalary;
		}

	}
}
