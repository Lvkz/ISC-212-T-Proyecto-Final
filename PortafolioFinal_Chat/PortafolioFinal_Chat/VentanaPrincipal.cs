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
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.VentanaPrincipal);

			this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

			AddTab ("Contactos", 0);
			AddTab ("Chats", 1);
		}

		public  void AddTab (string tabText, int tabID)
		{
			var tab = this.ActionBar.NewTab ();            
			tab.SetText (tabText);

			// must set event handler before adding tab
			tab.TabSelected += delegate(object sender, ActionBar.TabEventArgs e) {

				switch (tabID) {
				case 0:
					e.FragmentTransaction.Replace (Resource.Id.fragmentContainer, new fragmentContactos ());
					break;
				case 1:
					e.FragmentTransaction.Replace (Resource.Id.fragmentContainer, new fragmentVentanaChat ());
					break;
				}

			};
			
			this.ActionBar.AddTab (tab);
		}
	}
}

