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
using Android.Views;
using Android.Widget;
using ArticleCodes.Models;
using Xamarin.Forms;
using TimeZone = Android.Icu.Util.TimeZone;

namespace ArticleCodes.Droid
{
    class UsageStatsManager_Android : IUsageStatsManager
    {
        public const String USAGE_STATS_SERVICE = "usagestats";
        public UsageStatsManager usageStatsManager1;
        public DateTime currentToday;
        public long currentTimeBegin;
        public long currentTimeEnd;
        public IList<UsageStats> queryUsageStats1;
        public UsageEvents UsageEvent1;
        private Calendar beginCal, endCal;
        private static readonly Context _context = Forms.Context;

        public UsageStatsManager_Android()
        {
            Intent _intent = new Intent(Settings.ActionUsageAccessSettings);
            _context.StartActivity(_intent);

            beginCal = Calendar.GetInstance(TimeZone.Default);
            beginCal.Set(Calendar.Date, 1);
            beginCal.Set(Calendar.Month, 0);
            beginCal.Set(Calendar.Year, 2017);

            endCal = Calendar.GetInstance(TimeZone.Default);
            endCal.Set(Calendar.Date, 6);
            endCal.Set(Calendar.Month, 0);
            endCal.Set(Calendar.Year, 2017);

            usageStatsManager1 = (UsageStatsManager)_context.GetSystemService(USAGE_STATS_SERVICE);
            currentToday = DateTime.Today;
            currentTimeBegin = beginCal.TimeInMillis;
            currentTimeEnd = endCal.TimeInMillis;
            queryUsageStats1 = usageStatsManager1.QueryUsageStats(UsageStatsInterval.Yearly, currentTimeBegin, currentTimeEnd);
            UsageEvent1 = usageStatsManager1.QueryEvents(currentTimeBegin, currentTimeEnd);
        }


        string IUsageStatsManager.GetAppName()
        {
            string str = "";
            foreach (var q in queryUsageStats1)
            {
                if (q.TotalTimeInForeground != 0)
                {
                    str = str + "ÉAÉvÉäñº : " + q.PackageName + "\n\r" + "ëçé¿çséûä‘ : " + q.TotalTimeInForeground + "ms" + "\n\r\n\r";
                }
            }
            return str;
        }

        string IUsageStatsManager.GetType()
        {
            return "";
        }

        public string GetTestA()
        {
            throw new NotImplementedException();
        }

        public string GetTestB()
        {
            throw new NotImplementedException();
        }

        public string GetTestC()
        {
            throw new NotImplementedException();
        }

        public string GetTestD()
        {
            throw new NotImplementedException();
        }
    }
}