using Salary.Logic;
using Salary.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Salary
{
	public partial class Form1 : Form
	{
		private List<Employee> _employees;
		public Form1()
		{
			InitializeComponent();
			_employees = new List<Employee>();
			_employees.Add(new HourlySalary("Test", 10).Empl);
			_employees.Add(new HourlySalary("Test1", 3).Empl);
			_employees.Add(new HourlySalary("Test2", 10).Empl);
			_employees.Add(new FixedSalary("Test3", 1014).Empl);
			_employees.Add(new HourlySalary("Test4", 5).Empl);
			_employees.Add(new HourlySalary("Test5", 35).Empl);
			_employees.Add(new FixedSalary("Test6", 101).Empl);
		}

		private void button1_Click(object sender, EventArgs e)
		{			
			OpenFileDialog open = new OpenFileDialog();
			open.Filter = "txt files (*.txt)|*.txt";
			if(open.ShowDialog() == DialogResult.OK)
			{
				var fileContent = File.ReadAllLines(open.FileName);
				processFile(fileContent);
			};
		}

		private void processFile(string[] file)
		{
			int succesCount = 0;
			int failCount = 0;
			foreach(var str in file)
			{
				//info[0] - fio, fio[1] - ставка, fio[2] - признак почасово оплаты
				var info = str.Split(',');
				if(info.Length == 3)
				{
					Employee emp;
					double salary;
					if (!Double.TryParse(info[1].Trim(), out salary))
					{
						failCount++;
						continue;
					}
					if (info[2].Trim() == "+")
					{
						emp = new HourlySalary(info[0], salary).Empl;
					}
					else
					{
						emp = new FixedSalary(info[0], salary).Empl;
					}
					_employees.Add(emp);
					succesCount++;
				}
				else
				{
					failCount++;
				}
			}
			string infoMsg = $"Обработано сотрудников - {succesCount}" + Environment.NewLine
				+ $"Некорректных строк - {failCount}";
			MessageBox.Show(infoMsg);
		}

		private void updateDataTable()
		{
		}

		/// <summary>
		/// Вывести список из 5 высокооплачиваемых сотрудников
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button4_Click(object sender, EventArgs e)
		{
			var sort = new EmployeeSort();
			var sortEmpl = sort.SortEmployee(_employees);
			showMessage(sortEmpl);
		}		

		/// <summary>
		/// Список из 3 самых низкооплачиваемых сотрудников
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button3_Click(object sender, EventArgs e)
		{
			var sort = new EmployeeSort();
			var sortEmpl = sort.SortDescEmployee(_employees);
			showMessage(sortEmpl);
		}

		private void showMessage(List<Employee> sortEmpl)
		{
			string message = string.Empty;
			foreach (var s in sortEmpl)
			{
				message += $"{s.FIO} - {s.SalarySumm}{Environment.NewLine}";
			}

			MessageBox.Show(message);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFile = new SaveFileDialog();
			saveFile.Filter = "txt files (*.txt)|*.txt";
			if(saveFile.ShowDialog() == DialogResult.OK)
			{
				List<string> lines = new List<string>();
				foreach(var emp in _employees)
				{
					string isHourly = emp.IsHourly ? "+" : "-";
					lines.Add($"{emp.FIO}, {emp.Salary}, {isHourly}");
				}

				File.WriteAllLines(saveFile.FileName, lines.ToArray());
			}
		}
	}
}
