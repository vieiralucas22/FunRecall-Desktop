using MyCoin_Desktop.Common.Enums;
using MyCoin_Desktop.Entities;
using MyCoin_Desktop.Util;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace MyCoin_Desktop.Controls
{
    public sealed class ChessBoard : Control
    {

        #region States
        private const string STATE_SELECTED = "Selected";
        private const string STATE_NO_SELECTED = "NoSelected";
        private const string STATE_POSSIBLE_POSITION = "PossiblePosition";
        #endregion

        private Piece _currentPiece { get; set; }

        private int[,] _chessBoard = new int[8, 8]
        {
        { 2, 3, 4, 6, 5, 4, 3, 2 },
        { 1, 1, 1, 1, 1, 1, 1, 1 },
        { 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0 },
        { -1, -1, -1, -1, -1, -1, -1, -1 },
        { -2, -3, -4, -6, -5, -4, -3, -2 }
        };

        public ChessBoard()
        {
            DefaultStyleKey = typeof(ChessBoard);
        }

        protected override void OnApplyTemplate()
        {
            for (int line = 0; line < 8; line++)
            {
                for (int column = 0; column < 8; column++)
                {
                    if (GetTemplateChild($"ChessButton{line}{column}") is ChessBoardButton chessBoardButton)
                        chessBoardButton.Click += ChessBoardButton_Click;
                }
            }
        }

        private void ChessBoardButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is ChessBoardButton chessBoardButton)) return;

            (int line, int column) = GameBoardUtil.GetLineAndColumn(chessBoardButton.Tag.ToString());

            _currentPiece = chessBoardButton.GetPiece();

            if (_currentPiece == null) return;

            _currentPiece.Position = new Position(line, column);

            SelectButtonClicked(chessBoardButton);
        }

        private void SelectButtonClicked(ChessBoardButton chessBoardButton)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == _currentPiece.Position.line && j == _currentPiece.Position.column)
                        continue;

                    if (GetTemplateChild($"ChessButton{i}{j}") is ChessBoardButton button)
                        VisualStateManager.GoToState(button, STATE_NO_SELECTED, false);
                }
            }

            if (chessBoardButton.GetPiece() != null)
            {
                VisualStateManager.GoToState(chessBoardButton, STATE_SELECTED, false);
                ShowPossiblePosition(chessBoardButton);
            }
        }

        private void ShowPossiblePosition(ChessBoardButton chessBoardButton)
        {
            int currentPieceLine = _currentPiece.Position.line;
            int currentPieceColumn = _currentPiece.Position.column;
            List<Position> possiblePositions = new List<Position>();

            switch (_currentPiece.PieceType)
            {
                case ChessPieces.PAWN:
                    if (_currentPiece is Pawn pawn)
                        possiblePositions = pawn.GetPossiblesMoves(_chessBoard);
                    break;
                case ChessPieces.KNIGHT:
                    break;
                case ChessPieces.BISHOP:
                    break;
                case ChessPieces.QUEEN:
                    break;
                case ChessPieces.ROOK:
                    break;
                case ChessPieces.KING:
                    break;
            }

            foreach (Position position in possiblePositions)
            {
                Button button = GetTemplateChild($"ChessButton{position.line}{position.column}") as Button;
                VisualStateManager.GoToState(button, STATE_POSSIBLE_POSITION, false);
            }
        }
    }
}
