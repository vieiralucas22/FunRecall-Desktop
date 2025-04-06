using MyCoin_Desktop.Common;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace MyCoin_Desktop.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public LoginPageViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }

        public void navigateToCreateAccount()
        {
            _navigationService.Navigate(PageTokens.CREATE_ACCOUNT_PAGE, null);
        }
    }
}
