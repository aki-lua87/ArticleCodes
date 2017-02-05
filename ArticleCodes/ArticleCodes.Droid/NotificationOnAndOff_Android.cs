using ArticleCodes.Models;
using Xamarin.Forms;
using Android.App;
using Android.Content;
using Android.Content.Res;
using ArticleCodes.Views;

namespace ArticleCodes.Droid
{
    public sealed class NotificationOnAndOff_Android : INotificationOnAndOff
    {
        const int id = 0;

        public void NotificationOn()
        {
            var context = Forms.Context;
            var ToFormsPage = typeof(HidePage_Droid);
            var intent = new Intent(context, ToFormsPage); 
            var pendingIntent = PendingIntent.GetActivity(context, 0, intent, 0); 

            var n = new Notification.Builder(context)
                    .SetContentTitle("通知")
                    .SetSmallIcon(Resource.Drawable.icon)
                    .SetContentText("タップで隠しページを表示")
                    .SetOngoing(true) 
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