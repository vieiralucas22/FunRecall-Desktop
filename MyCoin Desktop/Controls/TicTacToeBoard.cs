using MyCoin_Desktop.Common.Enums;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Media;

namespace MyCoin_Desktop.Controls
{
    public sealed class TicTacToeBoard : Control
    {

        #region DependencyProperties

        public Players CurrentPlayer
        {
            get { return (Players)GetValue(CurrentPlayerProperty); }
            set { SetValue(CurrentPlayerProperty, value); }
        }

        public static readonly DependencyProperty CurrentPlayerProperty =
            DependencyProperty.Register("CurrentPlayer", typeof(Players), typeof(TicTacToeBoard), new PropertyMetadata(Players.PLAYER_1));

        #endregion

        private TicTacToeBoardButton _btn1;
        private TicTacToeBoardButton _btn2;
        private TicTacToeBoardButton _btn3;
        private TicTacToeBoardButton _btn4;
        private TicTacToeBoardButton _btn5;
        private TicTacToeBoardButton _btn6;
        private TicTacToeBoardButton _btn7;
        private TicTacToeBoardButton _btn8;
        private TicTacToeBoardButton _btn9;

        public TicTacToeBoard()
        {
            DefaultStyleKey = typeof(TicTacToeBoard);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _btn1 = GetTemplateChild("Btn1") as TicTacToeBoardButton;
            _btn2 = GetTemplateChild("Btn2") as TicTacToeBoardButton;
            _btn3 = GetTemplateChild("Btn3") as TicTacToeBoardButton;
            _btn4 = GetTemplateChild("Btn4") as TicTacToeBoardButton;
            _btn5 = GetTemplateChild("Btn5") as TicTacToeBoardButton;
            _btn6 = GetTemplateChild("Btn6") as TicTacToeBoardButton;
            _btn7 = GetTemplateChild("Btn7") as TicTacToeBoardButton;
            _btn8 = GetTemplateChild("Btn8") as TicTacToeBoardButton;
            _btn9 = GetTemplateChild("Btn9") as TicTacToeBoardButton;

            for (int i = 1; i <= 9; i++)
            {
                if (GetTemplateChild($"Btn{i}") is TicTacToeBoardButton btn)
                    btn.Click += Btn_click;
            }
        }

        private void Btn_click(object sender, RoutedEventArgs args)
        {
            var boardButton = sender as Button;

            var (line, column) = GetLineAndColumn(boardButton.Tag.ToString());

            boardButton.Content = CurrentPlayer == Players.PLAYER_1 ?
                GetBackgroundImage(true) : GetBackgroundImage(false);

        }

        private Image GetBackgroundImage(bool isPlayerOne)
        {
            var image = new Image();

            image.Source = isPlayerOne ?
                new BitmapImage(new Uri("ms-appx:///Assets/Images/X.png"))
                : new BitmapImage(new Uri("ms-appx:///Assets/Images/O.png"));

            return image;

        }

        private (string, string) GetLineAndColumn(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag)) return ("", "");

            var lineAndColumn = tag.Split(":");

            return (lineAndColumn[0], lineAndColumn[1]);

        }
    }
}
