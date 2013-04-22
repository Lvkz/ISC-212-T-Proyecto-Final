using System;
using Gtk;
using PortafolioFinal_Server_Ventana;
using System.Threading;


public partial class MainWindow: Gtk.Window
{	
	public Program_Servidor Servidor;
	public Thread HiloServidor;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		labelTitulo.LabelProp = @"<span foreground=""blue"" font-weight=""bold"">Servicio de Mensajería - Programación 1</span>";
		labelEstadoActual.LabelProp = @"<span foreground=""red"" font-weight=""bold"">Desconectado</span>";
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void btnCerrar_Clicked (object sender, EventArgs e)
	{
		Program_Servidor.CerrarServidor();
		HiloServidor.Abort();

		Gtk.Main.Quit();
	}

	protected void btn_Iniciar_Clicked (object sender, EventArgs e)
	{
<<<<<<< HEAD
		btn_Iniciar1.IsFocus= false;
		Program_servidor Servidor = new Program_servidor();
=======
		Servidor = new Program_Servidor();
>>>>>>> Cambio Ventana Servidor - Versión Final
		HiloServidor = new Thread(Servidor.ClaseServidor);
		HiloServidor.Start();

		if (Program_Servidor.conexionExitosa) {
			labelEstadoActual.LabelProp = @"<span foreground=""darkgreen"" font-weight=""bold"">¡Conectado!</span>";
			btnIniciar.Sensitive = false;
		}

	}

	protected void btnTerminar_Clicked (object sender, EventArgs e)
	{
		Program_Servidor.CerrarServidor();
		//HiloServidor.Abort;
	}
}
