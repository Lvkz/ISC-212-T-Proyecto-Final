using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PortafolioFinal_Chat
{
	[Activity (Label="@string/app_name")]
	public class VentanaPrincipal : Activity
	{
		private const int InsertId = Menu.First;
		private const int DeleteId = Menu.First + 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.VentanaPrincipal);

			this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

			AddTab ("Salas de Chat", 0);
			AddTab ("Contactos", 1);
			AddTab ("Chat", 2);

			if (this.ActionBar.TabCount > 2)  {
				this.ActionBar.RemoveTabAt(2);
			}
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			base.OnCreateOptionsMenu(menu);
			menu.Add(0, InsertId, 0, Resource.String.menu_insert);
			
			return true;
		}

		public  void AddTab (string tabText, int tabID)
		{
			var tab = this.ActionBar.NewTab ();            
			tab.SetText (tabText);

			// must set event handler before adding tab
			tab.TabSelected += delegate(object sender, ActionBar.TabEventArgs e) {

				switch (tabID) {
				case 0:
					e.FragmentTransaction.Replace (Resource.Id.fragmentContainer, new fragmentSalasChat ());
					break;
				case 1:
					e.FragmentTransaction.Replace (Resource.Id.fragmentContainer, new fragmentContactos ());
					break;
				case 2:
					e.FragmentTransaction.Replace (Resource.Id.fragmentContainer, new fragmentVentanaChat ());
					break;
				}

			};
			
			this.ActionBar.AddTab (tab);
		}
	}
}

