using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using ArticleCodes.Models;

namespace ArticleCodes.ViewModels
{
    public class UsageStatsManagerPageViewModel : BindableBase
    {
        private readonly IAllPageModel _page;
        private string _testLabel;

        public string TestLabel
        {
            get { return _testLabel; }
            set { this.SetProperty(ref this._testLabel, value); }
        }
        public DelegateCommand GetPackageCommand { get; private set; }
        public DelegateCommand GetTypeCommand { get; private set; }

        public UsageStatsManagerPageViewModel(IAllPageModel page)
        {
            _page = page;

            TestLabel = "aaaaaaaaaaaaaa";

            GetPackageCommand = new DelegateCommand(() => 
            TestLabel = _page.UsageStatsManager.GetAppName());

            GetTypeCommand = new DelegateCommand(() =>
            TestLabel = _page.UsageStatsManager.GetType());
        }
    }
}
