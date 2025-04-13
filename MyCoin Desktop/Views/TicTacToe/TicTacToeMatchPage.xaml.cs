using MyCoin_Desktop.Common;
using MyCoin_Desktop.Controls;
using MyCoin_Desktop.ViewModels;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace MyCoin_Desktop.Views
{
    public sealed partial class TicTacToeMatchPage : Page
    {
        public TicTacToeMatchPageViewModel ViewModel => (TicTacToeMatchPageViewModel)DataContext;

        private PlayerCardInfo _playerOneCardInfo, _playerTwoCardInfo;


        public TicTacToeMatchPage()
        {
            InitializeComponent();
            Loaded += TicTacToeMatchPage_Loaded;
            Unloaded += TicTacToeMatchPage_Unloaded;
        }

        private void TicTacToeMatchPage_Loaded(object sender, RoutedEventArgs e)
        {
            _playerOneCardInfo = FindName("CardPlayer1") as PlayerCardInfo;

            if (_playerOneCardInfo != null)
            {
                _playerOneCardInfo.PlayerName.Text = GameConstants.PLAYER_ONE;
                _playerOneCardInfo.PlayerRepresentation.Source = new BitmapImage(new Uri(GameConstants.PLAYER_ONE_SOURCE));
            }

            _playerTwoCardInfo = FindName("CardPlayer2") as PlayerCardInfo;

            if (_playerTwoCardInfo != null)
            {
                _playerTwoCardInfo.PlayerName.Text = GameConstants.PLAYER_TWO;
                _playerTwoCardInfo.PlayerRepresentation.Source = new BitmapImage(new Uri(GameConstants.PLAYER_TWO_SOURCE));

            }
        }

        private void TicTacToeMatchPage_Unloaded(object sender, RoutedEventArgs e)
        {
            _playerOneCardInfo = null;
            _playerTwoCardInfo = null;
        }

    }
}
