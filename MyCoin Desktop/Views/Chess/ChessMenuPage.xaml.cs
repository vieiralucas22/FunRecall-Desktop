using MyCoin_Desktop.ViewModels;
using Windows.UI.Xaml.Controls;

namespace MyCoin_Desktop.Views
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
