using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

using Client.ServiceReference1;

namespace Client
{
	class Program
	{
		static void Main(string[] args)
		{
			ServiceClient client = new ServiceClient();
			try
			{
				client.Open();
				writeConsole(client.GetData(3));
				client.Close();
			}
			catch
			{

			}

			System.Threading.Thread.Sleep(5000);
		}

		private static void writeConsole(string masg)
		{
			Console.WriteLine(masg);
		}
	}
}
