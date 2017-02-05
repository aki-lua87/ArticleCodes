using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ArticleCodes.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace ArticleCodes.Droid
{
    [Activity(Label = "HidePage_Droid")]
    public class HidePage_Droid : Activity // FormsAppCompat
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Forms‚É‘JˆÚ‚³‚¹‚ÄŽ©ŠQ‚·‚é
            (Xamarin.Forms.Application.Current.MainPage as NavigationPage).PushAsync(new HidePage());
            FinishAndRemoveTask();
        }
    }
}