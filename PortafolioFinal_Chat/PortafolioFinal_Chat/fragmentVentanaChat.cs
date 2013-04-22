
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

namespace PortafolioFinal_Chat
{
	public class fragmentVentanaChat : Fragment
	{
		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			//var ventanaPrincipal = (VentanaPrincipal) this.Activity;
			//VentanaPrincipal.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

			var view = inflater.Inflate (Resource.Layout.fragmentVentanaChat, container, false);
			var labelConversacion = view.FindViewById<TextView> (Resource.Id.label_Titulo);

			labelConversacion.Text = "Conversando con : " + variablesGlobales.textoConversacion;

			return view;
		}
	}
}

