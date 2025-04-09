using MyCoin_Desktop.ViewModels;
using Windows.UI.Xaml.Controls;

namespace MyCoin_Desktop.Views
{
    public sealed partial class TicTacToeMatchPage : Page
    {
        public TicTacToeMatchPageViewModel ViewModel => (TicTacToeMatchPageViewModel)DataContext;

        public TicTacToeMatchPage()
        {
            this.InitializeComponent();
        }
    }
}
