using System;
using System.Text;
using System.Net.Sockets;


using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace PortafolioFinal_Chat
{
	[Activity (Label = "PortafolioFinal_Chat", MainLauncher = true)]
	public class Activity1 : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			TcpClient Cliente;
			NetworkStream StreamCliente;
			string mensaje;

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			//Button button = FindViewById<Button> (Resource.Id.myButton);
			Button Boton_login= FindViewById<Button> (Resource.Id.button2);

			Boton_login.Click += delegate {
				try
				{
					Cliente = new TcpClient("10.0.0.2", 8888);
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
				Boton_login.Text=mensaje;

			};
		}
	}
}


