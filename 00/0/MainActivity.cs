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

			// Set our view from the "main" layout resource HÁT IGEN
			SetContentView (Resource.Layout.Main);

			//változók felvétele + a layoutról hozzárendelés
			TextView dec = FindViewById<TextView> (Resource.Id.editText1);
			Button atvaltas = FindViewById<Button> (Resource.Id.atvaltas);
			TextView bin = FindViewById<TextView> (Resource.Id.editText2);
			Button Menu = FindViewById<Button> (Resource.Id.menu);

			//Átváltás gomb megnyomásakor ez fut le
			atvaltas.Click += delegate {
				//szám string-é alakítása
				string decim = dec.Text;

				//ellenőrzi, hogy van e a számban . --> hogy tört-e
				if (decim.Contains('.'.ToString()))
				{
					//string kettébontása: egészrész + tizedesrész
					String egeszszoveg = decim;
					String[] bontottszoveg = egeszszoveg.Split('.');


					//egészrész átváltása binárisba
					int bejovoszamrendszer = 10;
					int kimenoszamrendszer = 2;
					String egeszresz = Convert.ToString(Convert.ToInt32(bontottszoveg[0], bejovoszamrendszer), kimenoszamrendszer);


					//kezdő "0." hozzáadása a törtrész elő, hogy ugye lehessen törtnek kezelni
					String Tizedes = "0." + bontottszoveg[1];


					// 'Tizedes' string változó double-é alakítása, hogy tudjunk vele számolni
					double tizedes = 0 + double.Parse(bontottszoveg[1])/(Math.Pow(10,bontottszoveg[1].Length));



					//ismétlődő tört figyelésére felvett változó (HAMIS alapértékkel) és tömb a már volt tizedesjegyeknek
					bool ism = false;
					string[] voltak=new string[75];



					//a többi az ugye a bináris törtté váltás alapján
					string kettedes;
					String tizedeseredmeny = ".";
					double szorzat;
					int szamlalo = 0;
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

						//ismétlődő tört figyelése
						for (int i = 0; i < szamlalo; i++) {
							//ha már volt az a tizedesjegy, akkor 'ism' IGAZ értéket ad vissza
							if (tizedes.ToString()==voltak[i]) {
								ism = true;
							}
						}
						szamlalo++;
					} while ((szorzat > 0) && (szamlalo < 75)&&(!ism));  
					//ez addig megy, amíg el nem érte a törtrész utolsó elemét, ÉS a titedesjegyek száma kevesebb mint 75 ÉS nem ismétlődő tört



					//kiíratandó (bináris)szám tizedesrészének összefűzése
					string tizedesresz = "";
					for (int i = 0; i < tizedeseredmeny.Length-1; i++)
					{
						tizedesresz += tizedeseredmeny[i];
					}   



					//ha ismétlődik kiírja a (bináris)számot + az "ism." szöveget
					if (ism) {
						bin.Text = egeszresz + tizedesresz +" ism.";
					}
					//ha nem ismétlődő, csak a (bináris)számot írja ki
					else {
						bin.Text = egeszresz+tizedesresz;
					}
				}


				//ha nem tört, akkor átváltja binárisba, és kiírja
				else
				{
					String egeszszoveg = decim;
					int bejovoszamrendszer = 10;
					int kimenoszamrendszer = 2;
					String eredmeny = Convert.ToString(Convert.ToInt32(egeszszoveg, bejovoszamrendszer), kimenoszamrendszer);

					bin.Text = eredmeny;

				}
			};





			//ez átvált a 'Menu' nevő activity-re
			//ahhoz is írok majd kommentet, amint rájövök, hogy miért nem akarja használni a másik layeren a változókat
			Menu.Click += delegate {
				StartActivity(typeof(Menu));
			};
		}
	}
}


