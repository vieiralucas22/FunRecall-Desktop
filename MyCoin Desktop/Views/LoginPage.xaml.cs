using MyCoin_Desktop.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MyCoin_Desktop.Views
{
    public sealed partial class LoginPage : Page
    {
        public LoginPageViewModel ViewModel => (LoginPageViewModel)DataContext;

        public LoginPage()
        {
            this.InitializeComponent();
        }

    }
}
