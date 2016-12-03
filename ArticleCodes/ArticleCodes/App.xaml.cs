using Prism.Unity;
using ArticleCodes.Views;
using Xamarin.Forms;
using ArticleCodes.Models;
using Microsoft.Practices.Unity;

namespace ArticleCodes
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("/NavigationPage/MainPage?title=メインページ");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<NotificationPage>();
            Container.RegisterTypeForNavigation<OverlayPage>();

            Container.RegisterType<IAllPageModel, AllPageModel>(new ContainerControlledLifetimeManager());
        }
    }
}
