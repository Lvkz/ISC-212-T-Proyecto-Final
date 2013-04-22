using System;
using Gtk;
using PortafolioFinal_Server_Ventana;
using System.Threading;


public partial class MainWindow: Gtk.Window
{	
	public Thread HiloServidor;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void btnCerrar_Clicked (object sender, EventArgs e)
	{
		Program_servidor.CerrarServidor();
		HiloServidor.Abort();

		Gtk.Main.Quit();
	}

	protected void btn_Iniciar_Clicked (object sender, EventArgs e)
	{
		btn_Iniciar1.IsFocus= false;
		Program_servidor Servidor = new Program_servidor();
<<<<<<< HEAD
		Servidor = new Program_Servidor();
=======
>>>>>>> parent of 5d471e2... Cambio Ventana Servidor - Versión Final
		HiloServidor = new Thread(Servidor.ClaseServidor);
		HiloServidor.Start();
	}
}
