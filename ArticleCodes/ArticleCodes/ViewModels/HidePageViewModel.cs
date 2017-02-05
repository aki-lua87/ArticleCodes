using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using ArticleCodes.Models;

namespace ArticleCodes.ViewModels
{
    public class HidePageViewModel : BindableBase
    {
        private readonly IAllPageModel _page;
        public HidePageViewModel(IAllPageModel page)
        {
            _page = page;
        }
    }
}
