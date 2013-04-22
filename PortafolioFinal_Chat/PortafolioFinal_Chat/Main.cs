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
	[Activity (Label = "Login", MainLauncher = true)]
	public class Main : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			// Set our view from the "main" layout resource

			//Button btnLogin = FindViewById<Button> (Resource.Id.btn_Login);
			Button btnLogin = FindViewById<Button> (Resource.Id.btn_Login);


			btnLogin.Click += (sender, e) => {
				StartActivity(typeof(VentanaPrincipal));
			};

			// Get our button from the layout resource,
			// and attach an event to it

			//Colocar Código Debajo de Esta Línea.		
//			TcpClient Cliente;
//			NetworkStream StreamCliente;
//			string mensaje;
//			btnLogin.Click += delegate {
//				try
//				{
//					Cliente = new TcpClient("127.0.0.1", 6080);
//					StreamCliente = Cliente.GetStream();
//					byte[] data = Encoding.ASCII.GetBytes("Cesar");
//					StreamCliente.Write(data, 0, data.Length);
//					StreamCliente.Flush();
//					mensaje = "Conectando Con el Servidor";
//					//Mensaje_REcivido();
//					//Thread Hilo = new Thread(Recivir_Mensaje);
//					//Hilo.Start();
//					
//				}
//				catch 
//				{
//					mensaje=("Error Al conectar");
//				}
//
//				btnLogin.Text=mensaje;
//
//			};
//
//			btnReset.Click += delegate {
//				btnLogin.Text = "Entrar";
//			};
		}
	}			
}
