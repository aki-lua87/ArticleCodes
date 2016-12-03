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

using ArticleCodes.Models;
using Xamarin.Forms;

namespace ArticleCodes.Droid
{
    class CreateOverrayView_Android : ICreateOverrayView
    {
        private static readonly Context Context = Forms.Context;

        private readonly Intent _intent = new Intent(Context, typeof(TestService));

        public void OverlayViewCreate()
        {
            Context.StartService(_intent);
        }

        public void OverlayViewDestroy()
        {
            Context.StopService(_intent);
        }
    }
}