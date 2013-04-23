using System;
using Gtk;
using PortafolioFinal_Server_Ventana;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;



public partial class MainWindow : Gtk.Window
{	
	public static Thread HiloServidor;
	public static Thread HiloEstado;
	public static Clase_Servidor Servidor;
	public static string stringIP;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		btnTerminar.Sensitive = false;
		labelEstadoServidor.LabelProp = @"<span foreground=""red"">        Desconectado</span>";

		Servidor = new Clase_Servidor();
		HiloServidor = new Thread(Servidor.ClaseServidor);
		HiloEstado = new Thread(CambioEstadoBotones);

		HiloServidor.Start();
		HiloServidor.Abort();
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
		if (textboxIP.Text == string.Empty) {
			MessageDialog md = new MessageDialog (this, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "Campo IP no puede estar vacío.");
			md.Run ();
			md.Destroy();
			return;
		}

		Servidor = new Clase_Servidor();
		HiloServidor = new Thread(Servidor.ClaseServidor);
		HiloEstado = new Thread(CambioEstadoBotones);

		stringIP = textboxIP.Text;

		HiloServidor.Start();
		Thread.Sleep(800);
		HiloEstado.Start ();
	}

	protected void btnTerminar_Clicked (object sender, EventArgs e)
	{
		HiloServidor.Abort();

		labelEstadoServidor.LabelProp = @"<span foreground=""red"">        Desconectado.</span>";

		btnIniciar.Sensitive = true;
		btnCerrar.Sensitive = true;
		btnTerminar.Sensitive = false;

		textboxIP.Sensitive = true;
		textboxIP.Text = "";

	}

	protected void CambioEstadoBotones ()
	{
		if (Clase_Servidor.EstadoServidor) {
			btnIniciar.Sensitive = false;
			btnCerrar.Sensitive = false;
			btnTerminar.Sensitive = true;

			textboxIP.Sensitive = false;
			
			labelEstadoServidor.LabelProp = @"<span foreground=""darkgreen"">        ¡Conectado!</span>";
		} 
	}


	protected void btn_Enviar_Clicked (object sender, EventArgs e)
	{

	}
	void GtkTextviewAppend(GtkWidget *textview, gchar *text)
	{
		GtkTextBuffer *tbuffer;
		GtkTextIter ei;
		
		tbuffer = gtk_text_view_get_buffer(GTK_TEXT_VIEW(textview));
		gtk_text_buffer_get_end_iter(tbuffer, &ei);
		gtk_text_buffer_insert(tbuffer, &ei, text, -1);
	}

}
