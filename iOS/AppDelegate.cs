using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace SqliteApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            //iOS일 경우 SQLite 초기화
            SQLitePCL.Batteries.Init();

            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
