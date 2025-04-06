using MyCoin_Desktop.ViewModels;
using Prism.Commands;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MyCoin_Desktop.Views
{
    public sealed partial class TicTacToePage : Page
    {
        public TicTacToePageViewModel ViewModel => (TicTacToePageViewModel)DataContext;

        public TicTacToePage()
        {
            this.InitializeComponent();
        }
    }
}
