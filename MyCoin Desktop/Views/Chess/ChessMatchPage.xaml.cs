using MyCoin_Desktop.ViewModels.Chess;
using Windows.UI.Xaml.Controls;

namespace MyCoin_Desktop.Views
{
    public sealed partial class ChessMatchPage : Page
    {
        public ChessMatchPageViewModel ViewModel => (ChessMatchPageViewModel) DataContext;

        private Grid _chessBoardGrid;

        public ChessMatchPage()
        {
            InitializeComponent();
            Loaded += ChessMatchPage_Loaded;
        }

        private void ChessMatchPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            
        }
    }
}
