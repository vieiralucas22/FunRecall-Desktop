using MyCoin_Desktop.Common;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoin_Desktop.ViewModels
{
    public class CreateAccountPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public CreateAccountPageViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }

        public void navigateToLogin()
        {
            _navigationService.Navigate(PageTokens.LOGIN_PAGE, null);
        }

    }
}
