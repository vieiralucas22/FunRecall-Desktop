using MyCoin_Desktop.Common;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace MyCoin_Desktop.ViewModels
{
    public class CreateAccountPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public CreateAccountPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void navigateToLogin()
        {
            _navigationService.Navigate(PageTokens.LOGIN_PAGE, null);
        }

    }
}
