using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using ArticleCodes.Models;

namespace ArticleCodes.ViewModels
{
    public class OverlayPageViewModel : BindableBase
    {
        private readonly IAllPageModel _page;
        public DelegateCommand OverlayOnCommand { get; private set; }
        public DelegateCommand OverlayOffCommand { get; private set; }
        public OverlayPageViewModel(IAllPageModel page)
        {
            _page = page;
            OverlayOnCommand = new DelegateCommand(() => _page.OverlayViewCreate());
            OverlayOffCommand = new DelegateCommand(() => _page.OverlayViewDestroy());
        }
    }
}
