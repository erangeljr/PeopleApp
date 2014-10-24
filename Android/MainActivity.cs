using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using SQLite.Net.Platform.XamarinAndroid;


namespace PeopleApp.Android
{
	[Activity(Label = "PeopleApp.Android.Android", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : AndroidActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			Xamarin.Forms.Forms.Init(this, bundle);

			var dbPath = FileAccessHelper.GetLocalFilePath("people.db3");

			SetPage(App.GetMainPage(new SQLitePlatformAndroid(), dbPath));
		}
	}
}

