using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLStorage;
using Prism.Navigation;
using Prism.Services;

namespace ArticleCodes.Models
{
    class AllPageModel : BindableBase, IAllPageModel
    {
        public INotificationOnAndOff NotificationOnOff{ get; set;}
        public ICreateOverrayView CreateOverrayView { get; set; }
        public IUsageStatsManager UsageStatsManager { get; set; }

        public AllPageModel(INotificationOnAndOff notificationOnAndOff, ICreateOverrayView createOverrayView, IUsageStatsManager usageStatsManager)
        {
            this.NotificationOnOff = notificationOnAndOff;
            this.CreateOverrayView = createOverrayView;
            this.UsageStatsManager = usageStatsManager;
        }

        public void NotificationOn()
        {
            NotificationOnOff.NotificationOn();
        }
        public void NotificationOff()
        {
            NotificationOnOff.NotificationOff();
        }

        public void OverlayViewCreate()
        {
            CreateOverrayView.OverlayViewCreate();
        }

        public void OverlayViewDestroy()
        {
            CreateOverrayView.OverlayViewDestroy();
        }

        
    }
}
