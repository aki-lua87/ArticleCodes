using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.App.Usage;
using Android.Content;
using Android.Icu.Util;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Test.Suitebuilder;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace ArticleCodes.Droid
{
    public class ParmissionSetting
    {
        public void aaaaa()
        {
            Context _context = Forms.Context;
            Intent _intent = new Intent(Settings.ActionUsageAccessSettings);
            //ContextWrapper.StartActivity(_intent);
        }
    }

    
}