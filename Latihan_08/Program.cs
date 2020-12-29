using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan_08
{
	static class Program
	{
		public static FormUtama frmUtama;
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			frmUtama = new FormUtama();
			Application.Run(new FormUtama());
		}
	}
}
