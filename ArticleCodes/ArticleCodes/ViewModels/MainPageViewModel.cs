using ArticleCodes.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace ArticleCodes.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly IAllPageModel _page;

        public DelegateCommand NavigationToNotificationCommand { get; private set; }
        public DelegateCommand NavigationToOverlayCommand { get; private set; }
        public DelegateCommand NavigationToSaveCommand { get; private set; }
        public DelegateCommand NavigationToUsageCommand { get; private set; }

        public MainPageViewModel(IAllPageModel page, INavigationService navigationService)
        {
            _page = page;
            NavigationToNotificationCommand = new DelegateCommand(() => navigationService.NavigateAsync("NotificationPage"));
            NavigationToOverlayCommand = new DelegateCommand(() => navigationService.NavigateAsync("OverlayPage"));
            NavigationToUsageCommand = new DelegateCommand(() => navigationService.NavigateAsync("UsageStatsManagerPage"));
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }
    }
}
