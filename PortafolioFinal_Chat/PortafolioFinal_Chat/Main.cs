using System;
using System.Text;
using System.Net.Sockets;

using System.Threading;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace PortafolioFinal_Chat
{
	[Activity (Label = "Android Chat", MainLauncher = true)]
	public class Main : Activity
	{
		int TIMER_RUNTIME = 10000; //En milisegundos son como 10s.
		Boolean mbActive = true;


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			TcpClient Cliente;
			NetworkStream StreamCliente;
			string mensaje;

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			ProgressBar mProgressBar = FindViewById<ProgressBar> (Resource.Id.progressBarLogin);

			// Get our button from the layout resource,
			// and attach an event to it

			Button btnLogin = FindViewById<Button> (Resource.Id.btn_Login);

			btnLogin.Click += delegate {
				try
				{
					Cliente = new TcpClient("192.168.1.6", 6080);
					StreamCliente = Cliente.GetStream();
					byte[] data = Encoding.ASCII.GetBytes("Cesar");
					StreamCliente.Write(data, 0, data.Length);
					StreamCliente.Flush();
					mensaje = "Conectando Con el Servidor";
					//Mensaje_REcivido();
					//Thread Hilo = new Thread(Recivir_Mensaje);
					//Hilo.Start();
					
				}
				catch 
				{
					mensaje=("Error Al conectar");
				}

				btnLogin.Text=mensaje;

			};
		}
	}			
}
