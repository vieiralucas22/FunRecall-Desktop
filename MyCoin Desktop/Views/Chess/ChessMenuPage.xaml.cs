using MyCoin_Desktop.ViewModels.Chess;
using Windows.UI.Xaml.Controls;

namespace MyCoin_Desktop.Views.Chess
{
    public sealed partial class ChessMenuPage : Page
    {
        public ChessMenuPageViewModel ViewModel => (ChessMenuPageViewModel) DataContext;
        public ChessMenuPage()
        {
            InitializeComponent();
        }
    }
}
