using MyCoin_Desktop.Common.Enums;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Media;
using MyCoin_Desktop.Common;
using System.Linq;
using MyCoin_Desktop.Events;
using Microsoft.Practices.ServiceLocation;
using System.Collections.Generic;
using Windows.UI;
using MyCoin_Desktop.Util;

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

        #region Event Listeners
        private IGameEvents _gameEvents;
        private IGameEvents GameEvents => _gameEvents ?? ServiceLocator.Current.GetInstance<IGameEvents>();
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
                {
                    btn.Click += Btn_click;
                    btn.PointerEntered += Btn_PointerEntered;
                    btn.PointerExited += Btn_PointerExited; ;
                }
            }
        }

        private void Btn_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            if (sender is TicTacToeBoardButton button)
                button.SetBackgroundImageButton(null, true);
        }

        private void Btn_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            if (sender is TicTacToeBoardButton button)
                button.SetBackgroundImageButton(GetBackgroundBitmapImage(), true);
        }

        private void Btn_click(object sender, RoutedEventArgs args)
        {
            var boardButton = sender as TicTacToeBoardButton;


            var (line, column) = GameBoardUtil.GetLineAndColumn(boardButton.Tag.ToString());

            boardButton.IsEnabled = false;
            boardButton.SetBackgroundImageButton(GetBackgroundBitmapImage(), false);

            CheckGameIsOver(line, column);
            ChangeCurrentPlayer();
        }

        private BitmapImage GetBackgroundBitmapImage()
        { 
            return IsPlayerOne ?
                new BitmapImage(new Uri(GameConstants.PLAYER_ONE_SOURCE))
                : new BitmapImage(new Uri(GameConstants.PLAYER_TWO_SOURCE));
        }

        private void ChangeCurrentPlayer() => IsPlayerOne = !IsPlayerOne;

        private bool CheckGameIsOver(int line, int column)
        {
            _boardGameMatriz[line, column] = IsPlayerOne ? "X" : "O";
            _columnBoard = string.Empty;
            _diagnolBoard = string.Empty;
            _inverseDiagnolBoard = string.Empty;

            for (int i = 0; i < _boardGameMatriz.GetLength(0); i++)
            {
                for (int j = 0; j < _boardGameMatriz.GetLength(1); j++)
                {
                    if (IsValidPositionOnBoard(i, j))
                        _lineBoard += _boardGameMatriz[i, j];

                    if (column == j && IsValidPositionOnBoard(i, j))
                        _columnBoard += _boardGameMatriz[i, j];

                    if (i == j && IsValidPositionOnBoard(i, j))
                        _diagnolBoard += _boardGameMatriz[i, j];

                    if (i + j == 2 && IsValidPositionOnBoard(i, j))
                        _inverseDiagnolBoard += _boardGameMatriz[i, j];

                    if (CheckIfGameIsOver())
                        break;

                    if (HasNoSpacesOnBoard())
                    {
                        List<(int, int)> winnerPosition = GetWinningPositions();

                        if (winnerPosition.Count != 0)
                        {
                            var firstPosition = winnerPosition.FirstOrDefault();
                            bool isPlayerOneWinner = _boardGameMatriz[firstPosition.Item1, firstPosition.Item2].Equals("X");
                            SetBoardOnWinnerSpacesOnBoard(winnerPosition);
                            GameEvents.RaiseOnGameIsOverEvent(GameConstants.TIC_TAC_TOE, isPlayerOneWinner ? Players.PLAYER_1 : Players.PLAYER_2);
                            break;
                        }

                        DisableAllButtons();
                        GameEvents.RaiseOnGameIsOverEvent(GameConstants.TIC_TAC_TOE, Players.NO_PLAYER);
                        break;
                    }
                }
                _lineBoard = string.Empty;
            }
            return false;
        }

        private bool IsValidPositionOnBoard(int line, int column) => !(_boardGameMatriz[line, column].Equals(string.Empty));

        private bool CheckIfLineOrColumnIsCompleted() => _lineBoard.Length == 3 || _columnBoard.Length == 3 || _diagnolBoard.Length == 3 || _inverseDiagnolBoard.Length == 3;

        private bool CheckIfGameIsOver()
        {
            if (CheckIfLineOrColumnIsCompleted())
            {
                if (_lineBoard.Equals(SEQUENCE_TO_PLAYER_ONE_WIN) || _columnBoard.Equals(SEQUENCE_TO_PLAYER_ONE_WIN)
                    || _diagnolBoard.Equals(SEQUENCE_TO_PLAYER_ONE_WIN) || _inverseDiagnolBoard.Equals(SEQUENCE_TO_PLAYER_ONE_WIN))
                {
                    SetBoardOnWinnerSpacesOnBoard(GetWinningPositions());
                    GameEvents.RaiseOnGameIsOverEvent(GameConstants.TIC_TAC_TOE, Players.PLAYER_1);
                    return true;
                }
                else if (_lineBoard.Equals(SEQUENCE_TO_PLAYER_TWO_WIN) || _columnBoard.Equals(SEQUENCE_TO_PLAYER_TWO_WIN)
                    || _diagnolBoard.Equals(SEQUENCE_TO_PLAYER_TWO_WIN) || _inverseDiagnolBoard.Equals(SEQUENCE_TO_PLAYER_TWO_WIN))
                {
                    SetBoardOnWinnerSpacesOnBoard(GetWinningPositions());
                    GameEvents.RaiseOnGameIsOverEvent(GameConstants.TIC_TAC_TOE, Players.PLAYER_2);
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
                {
                    btn.IsEnabled = false;
                    btn.Click -= Btn_click;
                    btn.PointerEntered -= Btn_PointerEntered;
                    btn.PointerExited -= Btn_PointerExited; ;
                }
            }
        }

        private void SetBoardOnWinnerSpacesOnBoard(List<(int, int)> list)
        {
            DisableAllButtons();
            for (int i = 1; i <= 9; i++)
            {
                if (GetTemplateChild($"Btn{i}") is TicTacToeBoardButton btn)
                {
                    var (line, column) = GameBoardUtil.GetLineAndColumn(btn.Tag.ToString());

                    list.ForEach(position =>
                    {
                        if (position.Item1 == line && position.Item2 == column)
                            btn.SetBtnWithWinnerStyle();
                    });
                }
            }
        }

        private List<(int, int)> GetWinningPositions()
        {
            List<(int, int)> winnerPosition = new List<(int, int)>();

            for (int i = 0; i < 3; i++)
            {
                if (!_boardGameMatriz[i, 0].Equals(string.Empty) &&
                    _boardGameMatriz[i, 0].Equals(_boardGameMatriz[i, 1]) &&
                    _boardGameMatriz[i, 1].Equals(_boardGameMatriz[i, 2]))
                {
                    winnerPosition.Add((i, 0));
                    winnerPosition.Add((i, 1));
                    winnerPosition.Add((i, 2));
                }
            }

            for (int j = 0; j < 3; j++)
            {
                if (!_boardGameMatriz[0, j].Equals(string.Empty) &&
                    _boardGameMatriz[0, j].Equals(_boardGameMatriz[1, j]) &&
                    _boardGameMatriz[1, j].Equals(_boardGameMatriz[2, j]))
                {
                    winnerPosition.Add((0, j));
                    winnerPosition.Add((1, j));
                    winnerPosition.Add((2, j));
                }
            }

            if (_diagnolBoard.Length == 3 && (_diagnolBoard.Equals(SEQUENCE_TO_PLAYER_ONE_WIN) || _diagnolBoard.Equals(SEQUENCE_TO_PLAYER_TWO_WIN)))
            {
                winnerPosition.Add((0, 0));
                winnerPosition.Add((1, 1));
                winnerPosition.Add((2, 2));
            }

            if (_inverseDiagnolBoard.Length == 3 && (_inverseDiagnolBoard.Equals(SEQUENCE_TO_PLAYER_ONE_WIN) || _inverseDiagnolBoard.Equals(SEQUENCE_TO_PLAYER_TWO_WIN)))
            {
                winnerPosition.Add((0, 2));
                winnerPosition.Add((1, 1));
                winnerPosition.Add((2, 0));
            }

            return winnerPosition;
        }

        private bool HasNoSpacesOnBoard() => !_boardGameMatriz.Cast<string>().Contains(string.Empty);
    }
}
