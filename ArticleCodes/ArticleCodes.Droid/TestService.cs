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
    /// �}�j�t�F�X�g��
    /// &lt;uses-permission android:name="android.permission.SYSTEM_ALERT_WINDOW" /&gt;
    /// ��ǋL���Ă�������
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
            // View�����łɂ���Ȃ�Remove����
            if (_isOverlayViewPresenceCheck)
            {
                _windowManager.RemoveView(_overlayView);
                _isOverlayViewPresenceCheck = false;
            }

            _windowManager = _context.GetSystemService(WindowService).JavaCast<IWindowManager>();
            var layoutInflater = LayoutInflater.From(_context);
            _overlayView = layoutInflater.Inflate(Resource.Layout.overlay_test_layout, null);

            // ��ʃT�C�Y���擾
            var psize = new Android.Graphics.Point();
            _windowManager.DefaultDisplay.GetSize(psize);

            // �I�[�o�[���C�͈͎w�� ���@�I�[�o�[���C�ݒ�
            var param = new WindowManagerLayoutParams(
                (int)(psize.X * 0.8),
                (int)(psize.Y * 0.9), // �Ȃ񂩂��������ɔ͈͂��w��
                WindowManagerTypes.SystemAlert, 
                WindowManagerFlags.Fullscreen, �@// �Ȃ񂩂��������ɑ�����ǉ�
                Android.Graphics.Format.Translucent // �������Ƃ�
            )
            { Gravity = GravityFlags.Top };
            
            // OverlayView�̃N���b�N�C�x���g��o�^
            var closeButton = _overlayView.FindViewById<Button>(Resource.Id.closeButton);
            closeButton.Click += CloseButton_Click;

            // View����ʏ�ɏd�ˍ��킹����
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