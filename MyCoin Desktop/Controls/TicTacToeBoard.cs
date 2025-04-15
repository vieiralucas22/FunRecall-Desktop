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
        #region Properties

        private bool _isPlayerOne = true;

        public bool IsPlayerOne
        {
            get { return _isPlayerOne; }
            set { _isPlayerOne = value; }
        }

        #endregion

        #region Constants

        private const string SEQUENCE_TO_PLAYER_ONE_WIN = "XXX";
        private const string SEQUENCE_TO_PLAYER_TWO_WIN = "OOO";

        #endregion

        private string[,] _boardGameMatriz = new string[3, 3] {
                { "", "", "" },
                { "", "", "" },
                { "", "", "" },
        };

        private string _lineBoard = string.Empty;
        private string _columnBoard = string.Empty;
        private string _diagnolBoard = string.Empty;
        private string _inverseDiagnolBoard = string.Empty;

        public TicTacToeBoard()
        {
            DefaultStyleKey = typeof(TicTacToeBoard);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

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

        private void ChangeCurrentPlayer() => IsPlayerOne = !IsPlayerOne;

        private bool CheckGameIsOver(int line, int column)
        {
            _boardGameMatriz[line, column] = IsPlayerOne ? "X" : "O";
            _columnBoard = string.Empty;
            _diagnolBoard = string.Empty;
            _inverseDiagnolBoard = string.Empty;

            int spacesToUserTouch = 9;

            for (int i = 0; i < _boardGameMatriz.GetLength(0); i++)
            {
                for (int j = 0; j < _boardGameMatriz.GetLength(1); j++)
                {
                    if (IsValidPositionOnBoard(i,j))
                        _lineBoard += _boardGameMatriz[i, j];

                    if (column == j && IsValidPositionOnBoard(i, j)) 
                        _columnBoard += _boardGameMatriz[i, j];

                    if (i == j && IsValidPositionOnBoard(i, j))
                        _diagnolBoard += _boardGameMatriz[i, j];

                    if (i + j == 2 && IsValidPositionOnBoard(i, j))
                        _inverseDiagnolBoard += _boardGameMatriz[i, j];

                    if (CheckIfGameIsOver())
                    {
                        DisableAllButtons();
                        break;
                    }

                    if (IsValidPositionOnBoard(i, j))
                    {
                        spacesToUserTouch--;

                        if (spacesToUserTouch == 0)
                        {
                            Debug.WriteLine("Deu Velha");
                            break;
                        }
                    }
                }
                _lineBoard = string.Empty;
            }
            return false;
        }

        private bool IsValidPositionOnBoard(int line, int column) => !(_boardGameMatriz[line, column].Equals(string.Empty));

        private bool CheckIfLineOrColumnIsCompleted() => _lineBoard.Length == 3 || _columnBoard.Length == 3 || _diagnolBoard.Length == 3 || _inverseDiagnolBoard.Length == 3;

        private bool CheckIfGameIsOver() {

            if (CheckIfLineOrColumnIsCompleted())
            {
                if (_lineBoard.Equals(SEQUENCE_TO_PLAYER_ONE_WIN) || _columnBoard.Equals(SEQUENCE_TO_PLAYER_ONE_WIN) 
                    || _diagnolBoard.Equals(SEQUENCE_TO_PLAYER_ONE_WIN) || _inverseDiagnolBoard.Equals(SEQUENCE_TO_PLAYER_ONE_WIN))
                {
                    Debug.WriteLine("Player 1 wins");
                    return true;
                }
                else if (_lineBoard.Equals(SEQUENCE_TO_PLAYER_TWO_WIN) || _columnBoard.Equals(SEQUENCE_TO_PLAYER_TWO_WIN) 
                    || _diagnolBoard.Equals(SEQUENCE_TO_PLAYER_TWO_WIN) || _inverseDiagnolBoard.Equals(SEQUENCE_TO_PLAYER_TWO_WIN))
                {
                    Debug.WriteLine("Player 2 wins");
                    return true;
                }
            }

            return false;
        }

        private void DisableAllButtons()
        {
            for (int i = 1; i <= 9; i++)
            {
                if (GetTemplateChild($"Btn{i}") is TicTacToeBoardButton btn)
                    btn.IsEnabled = false;
            }
        }
    }
}
