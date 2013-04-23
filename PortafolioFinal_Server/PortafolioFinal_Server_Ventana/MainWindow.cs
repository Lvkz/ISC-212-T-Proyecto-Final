using System;
using Gtk;
using PortafolioFinal_Server_Ventana;
using System.Threading;


public partial class MainWindow: Gtk.Window
{	
	public Thread HiloServidor;
	public Thread HiloEstado;
	public Clase_Servidor Servidor;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		btnTerminar.Sensitive = false;
		labelEstadoServidor.LabelProp = @"<span foreground=""red"">        Desconectado</span>";
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
		Servidor = new Clase_Servidor();
		HiloServidor = new Thread(Servidor.ClaseServidor);
		HiloEstado = new Thread(CambioEstadoBotones);

		HiloServidor.Start();
		Thread.Sleep(300);
		HiloEstado.Start ();
	}

	protected void btnTerminar_Clicked (object sender, EventArgs e)
	{
		Clase_Servidor.CerrarServidor();
		HiloServidor.Abort();

		labelEstadoServidor.LabelProp = @"<span foreground=""red"">        Desconectado.</span>";

		btnIniciar.Sensitive = true;
		btnCerrar.Sensitive = true;
		btnTerminar.Sensitive = false;
	}

	protected void CambioEstadoBotones ()
	{
		if (Clase_Servidor.EstadoServidor) {
			btnIniciar.Sensitive = false;
			btnCerrar.Sensitive = false;
			btnTerminar.Sensitive = true;
			
			labelEstadoServidor.LabelProp = @"<span foreground=""darkgreen"">        ¡Conectado!</span>";
		} 

		else {
			Console.WriteLine("Eh Dime!");
		}
	}
}
