
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.Net.Sockets;
using System.Threading;

namespace PortafolioFinal_Chat
{
	public class fragmentVentanaChat : Fragment
	{
		public NetworkStream StreamCliente;
		public string infoMensaje;
		public bool verificacion;
		string mensaje;
		static public Thread Hilo;
		LayoutInflater inflater;
		ViewGroup container;
		
		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			this.inflater= inflater;
			this.container= container;
			base.OnCreateView (inflater, container, savedInstanceState);
			Hilo = new Thread(Recivir_Mensaje);
			Hilo.Start();
			//var ventanaPrincipal = (VentanaPrincipal) this.Activity;
			//VentanaPrincipal.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
			
			var view = inflater.Inflate (Resource.Layout.fragmentVentanaChat, container, false);
			var labelConversacion = view.FindViewById<TextView> (Resource.Id.label_Titulo);
			var listviewContactos = view.FindViewById<ListView> (Resource.Id.listview_Contactos);
			var txtMensaje = view.FindViewById<EditText> (Resource.Id.txt_Mensaje);
			var txtVerMensaje = view.FindViewById<EditText> (Resource.Id.text_ver);
			var btnEnviar = view.FindViewById<Button> (Resource.Id.btn_Enviar);
			btnEnviar.Click += (sender, e) => {
				
				try
				{
					StreamCliente =  Login.Cliente.GetStream();
					byte[] data = Encoding.ASCII.GetBytes(txtMensaje.Text);
					StreamCliente.Write(data, 0, data.Length);
					StreamCliente.Flush();
					txtMensaje.Text="";
				}
				catch
				{
					Console.WriteLine("No pudo enviar el msj");
				}
				
			};
			labelConversacion.Text = "Conversando con : " + variablesGlobales.textoConversacion;
			
			return view;
		}
		public void Mensaje_REcivido()
		{
			var view = inflater.Inflate (Resource.Layout.fragmentVentanaChat, container, false);
			var txtVerMensaje = view.FindViewById<EditText> (Resource.Id.text_ver);
			
			txtVerMensaje.Text = "asdasdasdasdas  =>>" ;
			Hilo.Abort();
		}
		private void Recivir_Mensaje()
		{ 
			while(true)
			{
				StreamCliente = Login.Cliente.GetStream();
				byte[] bit = new byte[140];
				StreamCliente.Read(bit, 0, bit.Length);
				mensaje = Encoding.ASCII.GetString(bit);
				Mensaje_REcivido();
				
			}
			
		}
	}
}

