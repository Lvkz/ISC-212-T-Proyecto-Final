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
	public class fragmentContactos : ListFragment 
	{
		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			base.OnActivityCreated(savedInstanceState); 

			var ventanaPrincipal = (VentanaPrincipal) this.Activity;
			ventanaPrincipal.ActionBar.RemoveTabAt(1);

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
			ventanaPrincipal.AddTab ("Chats", 1);
			ventanaPrincipal.ActionBar.SetSelectedNavigationItem(1);
		}
	}
}