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
		public string direccionIP;
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
			EditText EditDireccionIP = FindViewById<EditText> (Resource.Id.textboxIP);

			btnLogin.Click += (sender, e) => {

				direccionIP = EditDireccionIP.Text;

				//Salir si la dirección IP no esta digitada.
				if(EditDireccionIP.Text==string.Empty)
				{
					infoMensaje = "El Campo DireccionIP esta vacio";
					Mensaje(infoMensaje);
					return;
				}

				//Salir si el nombre no esta digitado.
				else if(EditNombre.Text==string.Empty)
				{
					infoMensaje = "El Campo Nombre esta vacio";
					Mensaje(infoMensaje);
					return;
				}
				//si la contraseña no esta digitada.
				else if(EditContrasena.Text==string.Empty)
				{
					infoMensaje = "El Campo Contraseña esta vacio";
					Mensaje(infoMensaje);
					return;
				}

				else
				{
					try
					{
						Cliente = new TcpClient(direccionIP, 6080);
						StreamCliente = Cliente.GetStream();
						byte[] data = Encoding.ASCII.GetBytes(EditNombre.Text+":"+EditContrasena.Text);
						StreamCliente.Write(data, 0, data.Length);
						StreamCliente.Flush();
						
						infoMensaje = "Conectando Con el Servidor...";
						Recivir()
						Mensaje(infoMensaje);
					}
					
					catch 
					{
						infoMensaje=("Error Al conectar");
						verificacion = false;
					}
					
					finally
					{
						Console.WriteLine(infoMensaje);

						if (verificacion)
						{
							StartActivity(typeof(VentanaPrincipal));
						}
						else
						{
							Mensaje(infoMensaje);
						}
					}
				}
			};
		}

		public void Mensaje (string infoMensaje)
		{
			RunOnUiThread (() => {
				
				AlertDialog.Builder builder = new AlertDialog.Builder (this);
				builder.SetTitle ("Aviso");
				builder.SetMessage (infoMensaje);
				builder.SetCancelable (false);

				if (!verificacion) {
					builder.SetPositiveButton ("OK", delegate {	});
				}

				builder.Show ();
			});
		}
		void Recivir()
		{
			bool ciclo=true;
			string MensajeServidor;
			while(ciclo)
			{
				Byte[] msj_en_Byte = new Byte[4];
				//leer msj
				NetworkStream NetworCliente = Cliente.GetStream();
				NetworCliente.Read(msj_en_Byte, 0, msj_en_Byte.Length);
				
				MensajeServidor = Encoding.ASCII.GetString(msj_en_Byte, 0, msj_en_Byte.Length);
				if(MensajeServidor=="true")
				{
					verificacion = true;
					ciclo=false;
				}
				if(MensajeServidor=="fals")
				{
					infoMensaje=("No esta en la base de datos");
					verificacion = false;
					ciclo=false;
				}
			}
		}
	}
}
