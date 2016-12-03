using ArticleCodes.Models;
using Xamarin.Forms;
using Android.App;
using Android.Content;

namespace ArticleCodes.Droid
{
    public sealed class NotificationOnAndOff_Android : INotificationOnAndOff
    {
        int id = 0;

        public void NotificationOn()
        {
            var context = Forms.Context;
            var intent = new Intent(context, typeof(MainActivity)); 
            var pendingIntent = PendingIntent.GetActivity(context, 0, intent, 0); 

            var n = new Notification.Builder(context)
                    .SetContentTitle("�ʒm���o���܂����B")
                    .SetSmallIcon(Resource.Drawable.icon)
                    .SetContentText("�����͖{���ł��B��낵�����˂������܂��B")
                    .SetOngoing(false) //�풓���邩�ǂ���
                    .SetContentIntent(pendingIntent)
                    .Build();

            var nm = (NotificationManager)context.GetSystemService(Context.NotificationService);
            nm.Notify(id, n);
        }

        public void NotificationOff()
        {
            var context = Forms.Context;
            var nm = (NotificationManager)context.GetSystemService(Context.NotificationService);
            nm.Cancel(id);
        }
    }
}