using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Application
{
	[Activity (Label = "Decimális - Bináris Átváltó", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			TextView dec = FindViewById<TextView> (Resource.Id.editText1);
			Button atvaltas = FindViewById<Button> (Resource.Id.atvaltas);
			TextView bin = FindViewById<TextView> (Resource.Id.editText2);
			Button Menu = FindViewById<Button> (Resource.Id.menu);

			atvaltas.Click += delegate {
				string decim = dec.Text;
				if (decim.Contains('.'.ToString()))
				{
					String egeszszoveg = decim;
					String[] bontottszoveg = egeszszoveg.Split('.');

					int bejovoszamrendszer = 10;
					int kimenoszamrendszer = 2;
					String egeszresz = Convert.ToString(Convert.ToInt32(bontottszoveg[0], bejovoszamrendszer), kimenoszamrendszer);

					String Tizedes = "0." + bontottszoveg[1];

					double tizedes = 0 + double.Parse(bontottszoveg[1])/(Math.Pow(10,bontottszoveg[1].Length));
					string kettedes;
					String tizedeseredmeny = ".";
					double szorzat;
					int szamlalo = 0;
					bool ism = false;
					string[] voltak=new string[75];
					do
					{
						szorzat = tizedes * 2;
						if (szorzat >= 1)
						{
							kettedes = "1";
							tizedes = szorzat - 1;
						}
						else
						{
							kettedes = "0";
							tizedes = szorzat;
						}
						tizedeseredmeny += kettedes;
						for (int i = 0; i < szamlalo; i++) {
							if (tizedes.ToString()==voltak[i]) {
								ism = true;
							}
						}
						szamlalo++;
					} while ((szorzat > 0) && (szamlalo < 75)&&(!ism));                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
					string tizedesresz = "";
					for (int i = 0; i < tizedeseredmeny.Length-1; i++)
					{
						tizedesresz += tizedeseredmeny[i];
					}   
					if (ism) {
						bin.Text = egeszresz + tizedesresz +" ism.";
					}
					else {
						bin.Text = egeszresz+tizedesresz;
					}
				}
				else
				{
					String egeszszoveg = decim;
					int bejovoszamrendszer = 10;
					int kimenoszamrendszer = 2;
					String eredmeny = Convert.ToString(Convert.ToInt32(egeszszoveg, bejovoszamrendszer), kimenoszamrendszer);

					bin.Text = eredmeny;

				}
			};

			Menu.Click += delegate {
				StartActivity(typeof(Menu));
			};
		}
	}
}


