using ArticleCodes.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArticleCodes.ViewModels
{
    public class NotificationPageViewModel : BindableBase
    {
        private readonly IAllPageModel _page;
        public DelegateCommand OnCommand { get; private set; }
        public DelegateCommand OffCommand { get; private set; }
        public NotificationPageViewModel(IAllPageModel page)
        {
            _page = page;
            OnCommand = new DelegateCommand(() => _page.NotificationOnOff.NotificationOn());
            OffCommand = new DelegateCommand(() => _page.NotificationOnOff.NotificationOff());

        }
    }
}
