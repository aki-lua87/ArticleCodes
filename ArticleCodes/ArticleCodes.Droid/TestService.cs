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
using View = Android.Views.View;
using Button = Android.Widget.Button;

namespace ArticleCodes.Droid
{
    /// <summary>
    /// マニフェストに
    /// &lt;uses-permission android:name="android.permission.SYSTEM_ALERT_WINDOW" /&gt;
    /// を追記してください
    /// </summary>
    [Service]
    class TestService : Service
    {
        private IWindowManager _windowManager;
        private static readonly Context _context = Forms.Context;
        private View _overlayView;
        private bool _isOverlayViewPresenceCheck;
        UsageEvents.Event testUsageEvents = new UsageEvents.Event();

        public const String USAGE_STATS_SERVICE = "usagestats";

        //
        public UsageStatsManager usageStatsManager1;
        public int currentYear1;
        private IList<UsageStats> queryUsageStats1;
        public UsageEvents queryUsageStats2;
        //

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            
            Intent _intent = new Intent(Settings.ActionUsageAccessSettings);
            StartActivity(_intent);
        
            // ViewがすでにあるならRemoveする
            if (_isOverlayViewPresenceCheck)
            {
                _windowManager.RemoveView(_overlayView);
                _isOverlayViewPresenceCheck = false;
            }

            //
            UsageStatsManager usageStatsManager1 = (UsageStatsManager)_context.GetSystemService(USAGE_STATS_SERVICE);
            currentYear1 = DateTime.Now.Year;   // Calendar.GetInstance().Get(Calendar.Year);
            queryUsageStats1 = usageStatsManager1.QueryUsageStats(UsageStatsInterval.Yearly, currentYear1 - 1, currentYear1);
            queryUsageStats2 = usageStatsManager1.QueryEvents(currentYear1 - 1, currentYear1);
            //

            _windowManager = _context.GetSystemService(WindowService).JavaCast<IWindowManager>();
            var layoutInflater = LayoutInflater.From(_context);
            _overlayView = layoutInflater.Inflate(Resource.Layout.overlay_test_layout, null);

            // 画面サイズを取得
            var psize = new Android.Graphics.Point();
            _windowManager.DefaultDisplay.GetSize(psize);

            // オーバーレイ範囲指定 ＆　オーバーレイ設定
            var param = new WindowManagerLayoutParams(
                (int)(psize.X * 0.9),
                (int)(psize.Y * 0.4), // なんかいい感じに範囲を指定
                WindowManagerTypes.SystemAlert, 
                WindowManagerFlags.Fullscreen, 　// なんかいい感じに属性を追加
                Android.Graphics.Format.Translucent // 半透明とか
            )
            { Gravity = GravityFlags.Top };
            
            // OverlayViewのクリックイベントを登録
            var closeButton = _overlayView.FindViewById<Button>(Resource.Id.closeButton);
            closeButton.Click += CloseButton_Click;
            var testButton = _overlayView.FindViewById<Button>(Resource.Id.testButton);
            testButton.Click += (sender, args) => TestMethod();

            // Viewを画面上に重ね合わせする
            _windowManager.AddView(_overlayView, param);
            _isOverlayViewPresenceCheck = true;

            return StartCommandResult.NotSticky;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            StopService(new Intent(this, typeof(TestService)));
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            _windowManager.RemoveView(_overlayView);
            _isOverlayViewPresenceCheck = false;
        }

        private void TestMethod()
        {
            var textText = _overlayView.FindViewById<TextView>(Resource.Id.textText);
            textText.Text =
                "??? : " + queryUsageStats2;
        }

        public override IBinder OnBind(Intent intent) => null;
    }
}