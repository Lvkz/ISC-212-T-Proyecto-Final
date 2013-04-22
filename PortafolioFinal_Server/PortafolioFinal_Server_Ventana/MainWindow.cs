using System;
using Gtk;
using PortafolioFinal_Server_Ventana;
using System.Threading;


public partial class MainWindow: Gtk.Window
{	
	public Thread HiloServidor;
	public Clase_Servidor Servidor;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		btnTerminar.Sensitive = false;
		labelEstadoServidor.LabelProp = @"<span foreground=""red"">Desconectado</span>";
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void btnCerrar_Clicked (object sender, EventArgs e)
	{                          
		Gtk.Main.Quit();
	}

	protected void btn_Iniciar_Clicked (object sender, EventArgs e)
	{
		if (Clase_Servidor.EstadoServidor) {
			btnIniciar.Sensitive = false;
			btnCerrar.Sensitive = false;
			btnTerminar.Sensitive = true;
			
			labelEstadoServidor.LabelProp = @"<span foreground=""darkgreen"">¡Conectado!</span>";
		}

		Servidor = new Clase_Servidor();
		HiloServidor = new Thread(Servidor.ClaseServidor);
		HiloServidor.Start();
	}

	protected void btnTerminar_Clicked (object sender, EventArgs e)
	{
		Clase_Servidor.CerrarServidor();
		HiloServidor.Abort();

		labelEstadoServidor.LabelProp = @"<span foreground=""red"" text-align=""left"">Desconectado.</span>";


		btnIniciar.Sensitive = true;
		btnCerrar.Sensitive = true;
	}
}
