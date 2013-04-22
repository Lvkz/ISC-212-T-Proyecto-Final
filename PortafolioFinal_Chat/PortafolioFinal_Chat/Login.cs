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
	[Activity (Label = "@string/app_name", MainLauncher = true)]
	public class Login : Activity
	{
		public TcpClient Cliente;
		public NetworkStream StreamCliente;
		public string infoMensaje;
		public bool verificacion;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);	
			SetContentView (Resource.Layout.Login);
			//Variables de la vista
			Button btnLogin = FindViewById<Button> (Resource.Id.btn_Login);
			EditText EditNombre = FindViewById<EditText> (Resource.Id.textboxNombre);
			EditText EditContrasena = FindViewById<EditText> (Resource.Id.textboxContraseña);

			btnLogin.Click += (sender, e) => {

				try
				{
					//Salir si el nombre no esta digitado..
					if(EditNombre.Text==string.Empty)
					{
						RunOnUiThread(() => {
						
						AlertDialog.Builder builder = new AlertDialog.Builder(this);
						builder.SetTitle("Aviso");
						builder.SetMessage("El Campo Nombre esta vacio");
						builder.SetCancelable(false);
						builder.SetPositiveButton("OK", delegate { });
						builder.Show();
						});
						
						return;
					}
					//si la contraseña no esta digitada
					if(EditContrasena.Text==string.Empty)
					{
							RunOnUiThread(() => {
						
						AlertDialog.Builder builder = new AlertDialog.Builder(this);
						builder.SetTitle("Aviso");
						builder.SetMessage("El Campo Contraseña esta vacio");
						builder.SetCancelable(false);
						builder.SetPositiveButton("OK", delegate { });
						builder.Show();
						});
						
						return;
					}
					Cliente = new TcpClient("172.20.10.8", 6080);
					StreamCliente = Cliente.GetStream();
					Console.WriteLine("estoy por aqui");
					byte[] data = Encoding.ASCII.GetBytes(EditNombre.Text+":"+EditContrasena.Text);
					StreamCliente.Write(data, 0, data.Length);
					StreamCliente.Flush();

					infoMensaje = "Conectando Con el Servidor";
					verificacion = true;
				}

				catch 
				{
					infoMensaje=("Error Al conectar");
					verificacion = false;
				}

				finally
				{
					Console.WriteLine(infoMensaje);
				}

				if (verificacion)
				{
					StartActivity(typeof(VentanaPrincipal));
				}
				else
				{
					RunOnUiThread(() => {
						AlertDialog.Builder builder = new AlertDialog.Builder(this);
						builder.SetTitle("Aviso");
						builder.SetMessage(infoMensaje);
						builder.SetCancelable(false);
						builder.SetPositiveButton("OK", delegate { });
						builder.Show();
					});
				}				
			};

		}
	}			
}
