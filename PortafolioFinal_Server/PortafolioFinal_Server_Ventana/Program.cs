using System;
using System.Net;
using System.Net.Sockets;

using Gtk;

namespace PortafolioFinal_Server_Ventana
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();

		}
	}
}
