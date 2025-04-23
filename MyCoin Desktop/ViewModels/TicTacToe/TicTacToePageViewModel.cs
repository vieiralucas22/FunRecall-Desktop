using MyCoin_Desktop.Common;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace MyCoin_Desktop.ViewModels
{
    public class TicTacToePageViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        public TicTacToePageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public void GoToMatchPage()
        {
            navigationService.Navigate(PageTokens.TIC_TAC_TOE_MATCH_PAGE, null);
        }
    }
}
