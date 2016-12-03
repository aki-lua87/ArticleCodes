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
        private readonly Context _context = Forms.Context;
        private View _overlayView;
        private bool _isOverlayViewPresenceCheck;

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            // ViewがすでにあるならRemoveする
            if (_isOverlayViewPresenceCheck)
            {
                _windowManager.RemoveView(_overlayView);
                _isOverlayViewPresenceCheck = false;
            }

            _windowManager = _context.GetSystemService(WindowService).JavaCast<IWindowManager>();
            var layoutInflater = LayoutInflater.From(_context);
            _overlayView = layoutInflater.Inflate(Resource.Layout.overlay_test_layout, null);

            // 画面サイズを取得
            var psize = new Android.Graphics.Point();
            _windowManager.DefaultDisplay.GetSize(psize);

            // オーバーレイ範囲指定 ＆　オーバーレイ設定
            var param = new WindowManagerLayoutParams(
                (int)(psize.X * 0.8),
                (int)(psize.Y * 0.9), // なんかいい感じに範囲を指定
                WindowManagerTypes.SystemAlert, 
                WindowManagerFlags.Fullscreen, 　// なんかいい感じに属性を追加
                Android.Graphics.Format.Translucent // 半透明とか
            )
            { Gravity = GravityFlags.Top };
            
            // OverlayViewのクリックイベントを登録
            var closeButton = _overlayView.FindViewById<Button>(Resource.Id.closeButton);
            closeButton.Click += CloseButton_Click;

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

        public override IBinder OnBind(Intent intent) => null;
    }
}