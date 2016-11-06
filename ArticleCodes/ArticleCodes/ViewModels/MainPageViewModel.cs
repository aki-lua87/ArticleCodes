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

        public DelegateCommand OpenPageCommand { get; private set; }

        public MainPageViewModel(IAllPageModel page, INavigationService navigationService)
        {
            _page = page; 
            OpenPageCommand = new DelegateCommand(() => navigationService.NavigateAsync("NotificationPage"));
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }
    }
}
