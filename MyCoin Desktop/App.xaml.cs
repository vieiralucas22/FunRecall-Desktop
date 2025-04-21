using MyCoin_Desktop.Common;
using MyCoin_Desktop.Events;
using Prism.Unity.Windows;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;

namespace MyCoin_Desktop
{
   
    sealed partial class App : PrismUnityApplication
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args) 
        {
            NavigationService.Navigate(PageTokens.HOME, null);
            return Task.CompletedTask;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            RegisterTypeIfMissing(typeof(IGameEvents), typeof(GameEvents), true);
        }
    }
}
