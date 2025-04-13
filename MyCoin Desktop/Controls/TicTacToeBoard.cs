using MyCoin_Desktop.Common.Enums;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Media;
using MyCoin_Desktop.Common;
using System.Diagnostics;

namespace MyCoin_Desktop.Controls
{
    public sealed class TicTacToeBoard : Control
    {
        #region Xaml Components

        private TicTacToeBoardButton _btn1;
        private TicTacToeBoardButton _btn2;
        private TicTacToeBoardButton _btn3;
        private TicTacToeBoardButton _btn4;
        private TicTacToeBoardButton _btn5;
        private TicTacToeBoardButton _btn6;
        private TicTacToeBoardButton _btn7;
        private TicTacToeBoardButton _btn8;
        private TicTacToeBoardButton _btn9;

        #endregion

        #region Properties

        private bool _isPlayerOne = true;

        public bool IsPlayerOne
        {
            get { return _isPlayerOne; }
            set { _isPlayerOne = value; }
        }

        #endregion

        private int[,] _boardGameMatriz = new int[3, 3];

        private int _countButtonValue = 0;


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
            var boardButton = sender as TicTacToeBoardButton;

            var (line, column) = GetLineAndColumn(boardButton.Tag.ToString());

            boardButton.SetBackgroundImageButton(GetBackgroundBitmapImage());
            boardButton.IsEnabled = false;

            CheckGameIsOver(line, column);
            ChangeCurrentPlayer();
        }

        private BitmapImage GetBackgroundBitmapImage()
        {
            return IsPlayerOne ?
                new BitmapImage(new Uri(GameConstants.PLAYER_ONE_SOURCE))
                : new BitmapImage(new Uri(GameConstants.PLAYER_TWO_SOURCE));
        }

        private (int, int) GetLineAndColumn(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag)) return (0, 0);

            var lineAndColumn = tag.Split(":");

            return (int.Parse(lineAndColumn[0]), int.Parse(lineAndColumn[1]));
        }

        private void ChangeCurrentPlayer()
        {
            IsPlayerOne = !IsPlayerOne;
        }

        private bool CheckGameIsOver(int line, int column)
        {
            _boardGameMatriz[line, column] = IsPlayerOne ? 1 : 2;


            for (int i = 0; i < _boardGameMatriz.Rank; i++)
            {
                for (int j = 0; j < _boardGameMatriz.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        if (_boardGameMatriz[i, j] == 1)
                            _countButtonValue++;
                        else if (_boardGameMatriz[i, j] == 2)
                            _countButtonValue--;
                    }
                }
            }

            Debug.WriteLine($"Valor: {_countButtonValue}");

            if (_countButtonValue == 3)
                Debug.WriteLine($"Player One wins");
            else if (_countButtonValue == -3)
                Debug.WriteLine($"Player Two wins");

            return false;
        }
    }
}
