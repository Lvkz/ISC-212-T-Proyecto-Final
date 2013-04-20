using System;
<<<<<<< HEAD:PortafolioFinal_Chat/PortafolioFinal_Chat/Activity1.cs
using System.Text;
using System.Net.Sockets;

=======
using System.Threading;
>>>>>>> Agregada Actividad y Layout Contactos:PortafolioFinal_Chat/PortafolioFinal_Chat/Main.cs

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
<<<<<<< HEAD:PortafolioFinal_Chat/PortafolioFinal_Chat/Activity1.cs
			TcpClient Cliente;
			NetworkStream StreamCliente;
			string mensaje;

=======
			
>>>>>>> Agregada Actividad y Layout Contactos:PortafolioFinal_Chat/PortafolioFinal_Chat/Main.cs
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			ProgressBar mProgressBar = FindViewById<ProgressBar> (Resource.Id.progressBarLogin);
			Button btnEntrar = FindViewById<Button> (Resource.Id.btn_entrar);

			btnEntrar.Click += (sender, e) => {
				//StartActivity(typeof(Contactos));
			};

			// Get our button from the layout resource,
			// and attach an event to it
<<<<<<< HEAD:PortafolioFinal_Chat/PortafolioFinal_Chat/Activity1.cs
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
=======
>>>>>>> Agregada Actividad y Layout Contactos:PortafolioFinal_Chat/PortafolioFinal_Chat/Main.cs
		}
	}			
}
