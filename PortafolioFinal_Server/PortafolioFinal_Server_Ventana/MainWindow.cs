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

		Program_servidor Servidor = new Program_servidor();
		HiloServidor = new Thread(Servidor.ClaseServidor);
		HiloServidor.Start();
	}
}
