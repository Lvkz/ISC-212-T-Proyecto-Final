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
	public class variablesGlobales
	{
		public static string textoConversacion;
	}

	public class fragmentContactos : ListFragment 
	{
		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			base.OnActivityCreated(savedInstanceState); 

			var ventanaPrincipal = (VentanaPrincipal) this.Activity;

			if (ventanaPrincipal.ActionBar.TabCount > 2) {
				ventanaPrincipal.ActionBar.RemoveTabAt(2);
			}

			string[] values = new[] { "Cesar Ortiz", 
									  "Francisco Payes", 
				    				  "David Sánchez",	
									  "Karina Peralta", 
				  					  "César Várgas", 
				 					  "Lukas Gómez", 
									  "Marcos Meléndez", 
									  "Jorge Nuñez", 
									  "Máximo Cepeda", 
									  "Julián Pancracio" };

			this.ListAdapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleExpandableListItem1, values);

		}

		public override void OnListItemClick(ListView l, View v, int index, long id)
		{
			var ventanaPrincipal = (VentanaPrincipal) this.Activity;
			ventanaPrincipal.AddTab ("Chat", 2);
			ventanaPrincipal.ActionBar.SetSelectedNavigationItem(2);

			variablesGlobales.textoConversacion = (string) l.GetItemAtPosition(index);

		}
	}
}