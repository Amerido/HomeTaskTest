using System.Collections.Generic;
using System.Linq;

namespace Salary.Model
{
	public class Employee
	{
		
		public string FIO { get; set; }

		/// <summary>
		/// Признак, что ставка почасовая
		/// </summary>
		public bool IsHourly { get; set; }

		/// <summary>
		/// Ставка
		/// </summary>
		public double Salary { get; set; }
		
		/// <summary>
		/// Среднемесячная зарплата
		/// </summary>
		public double SalarySumm { get; set; }
	}

	public class EmployeeSort
	{
		/// <summary>
		/// Получить 5 самых высокооплачиваемых сотрудников
		/// </summary>
		/// <param name="employees">Список сотрудников</param>
		/// <returns></returns>
		public List<Employee> SortEmployee(List<Employee> employees)
		{
			return (from emp in employees
					orderby emp.SalarySumm, emp.FIO
					select emp).Reverse().Take(5).ToList();
		}

		/// <summary>
		/// Получить 3 самых менее оплачиваемых сотрудников 
		/// </summary>
		/// <param name="employees"></param>
		/// <returns></returns>
		public List<Employee> SortDescEmployee(List<Employee> employees)
		{
			return (from emp in employees
					orderby emp.SalarySumm, emp.FIO
					select emp).Take(3).ToList();
		}
	}
}
