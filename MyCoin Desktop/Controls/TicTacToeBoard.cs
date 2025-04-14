using MyCoin_Desktop.Common.Enums;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Media;
using MyCoin_Desktop.Common;
using System.Diagnostics;
using System.Linq;

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

        private string[,] _boardGameMatriz = new string[3, 3] {
                { "", "", "" },
                { "", "", "" },
                { "", "", "" },
        };

        private string _lineBoard = string.Empty;
        private string _columnBoard = string.Empty;

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
            _boardGameMatriz[line, column] = IsPlayerOne ? "X" : "O";
            _columnBoard = string.Empty;

            for (int i = 0; i < _boardGameMatriz.GetLength(0); i++)
            {
                for (int j = 0; j < _boardGameMatriz.GetLength(1); j++)
                {
                    if (IsValidPositionOnBoard(i,j))
                        _lineBoard += _boardGameMatriz[i, j];

                    if (IsValidPositionOnBoard(i, j) && column == j) 
                        _columnBoard += _boardGameMatriz[i, j];

                    if (CheckIfGameIsOver()) break;
                }
                _lineBoard = string.Empty;
            }

            return false;
        }

        private bool IsValidPositionOnBoard(int line, int column) => !(_boardGameMatriz[line, column].Equals(string.Empty));

        private bool CheckIfLineOrColumnIsCompleted() => _lineBoard.Length == 3 || _columnBoard.Length == 3;

        private bool CheckIfGameIsOver() {

            if (CheckIfLineOrColumnIsCompleted())
            {
                if (_lineBoard.Equals("XXX") || _columnBoard.Equals("XXX"))
                {
                    Debug.WriteLine("Player 1 wins");
                    return true;
                }
                else if (_lineBoard.Equals("OOO") || _columnBoard.Equals("OOO"))
                {
                    Debug.WriteLine("Player 2 wins");
                    return true;
                }
            }

            return false;
        }
    }
}
