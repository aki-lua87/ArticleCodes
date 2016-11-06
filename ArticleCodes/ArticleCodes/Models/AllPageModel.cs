﻿using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Navigation;
using Prism.Services;

namespace ArticleCodes.Models
{
    class AllPageModel : BindableBase, IAllPageModel
    {
        
        //private INotificationOnAndOff _notificationOnAndOff;

        public INotificationOnAndOff NotificationOnOff{ get; set;}

        public AllPageModel(INotificationOnAndOff nof)
        {
            NotificationOnOff = nof;
        }

        public void TestMethod()
        {
            
        }
            
    }
}
