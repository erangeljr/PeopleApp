using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;
using SQLite.Net.Platform.XamarinIOS;

namespace PeopleApp.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			Forms.Init();

			window = new UIWindow(UIScreen.MainScreen.Bounds);

			var dbPath = FileAccessHelper.GetLocalFilePath("people.db3");
			window.RootViewController = App.GetMainPage(new SQLitePlatformIOS(), dbPath).CreateViewController();
			window.MakeKeyAndVisible();
			
			return true;
		}
	}
}

