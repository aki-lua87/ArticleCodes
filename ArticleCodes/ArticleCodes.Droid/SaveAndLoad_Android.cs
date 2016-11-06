using ArticleCodes.Droid;
using ArticleCodes.Models;
using ArticleCodes.Views;
using System.IO;
using Xamarin.Forms;
using Android.App;
using Android.Content;


[assembly: Dependency(typeof(INotificationOnAndOff_Android))]
namespace ArticleCodes.Droid
{
    public sealed class INotificationOnAndOff_Android : INotificationOnAndOff
    {
        int id = 0;

        public void NotificationOn()
        {
            var context = Forms.Context;
            var intent = new Intent(context, typeof(MainActivity)); //タッチして遷移するとき用
            var pendingIntent = PendingIntent.GetActivity(context, 0, intent, 0); //タッチして遷移するとき用2

            var n = new Notification.Builder(context)
                    .SetContentTitle("通知を出しました。")
                    .SetSmallIcon(Resource.Drawable.icon)
                    .SetContentText("ここは本文です。よろしくおねがいします。")
                    .SetOngoing(false) //常駐するかどうか
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