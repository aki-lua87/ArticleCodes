using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCodes.Models
{
    public interface IAllPageModel : INotifyPropertyChanged
    {
        INotificationOnAndOff NotificationOnOff { get; set; }
        void TestMethod();
    }
}
