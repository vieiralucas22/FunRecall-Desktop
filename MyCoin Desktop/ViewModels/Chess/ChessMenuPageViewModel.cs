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
    public class ChessMenuPageViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        public ChessMenuPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public void GoToMatchPage()
        {
            navigationService.Navigate(PageTokens.CHESS_MATCH_PAGE, null);
        }
    }
}
