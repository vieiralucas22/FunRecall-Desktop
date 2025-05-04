using MyCoin_Desktop.Common.Enums;
using MyCoin_Desktop.Entities;
using MyCoin_Desktop.Util;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MyCoin_Desktop.Controls
{
    public sealed class ChessBoard : Control
    {

        #region States
        private const string STATE_SELECTED = "Selected";
        private const string STATE_NO_SELECTED = "NoSelected";
        private const string STATE_MOVE_POSITION = "MovePosition";
        private const string STATE_CAPTURE_POSITION = "CapturePosition";
        #endregion

        private Piece _currentPiece { get; set; }
        private Piece _selectedPiece { get; set; }
        private ChessBoardButton _selectedChessButton { get; set; }

        private bool _isUserSelectingAPossition = false;

        public bool IsUserSelectingAPosition
        {
            get { return _isUserSelectingAPossition; }
            set { _isUserSelectingAPossition = value; }
        }

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

            DiselectAllChessButtons();

            (int line, int column) = GameBoardUtil.GetLineAndColumn(chessBoardButton.Tag.ToString());

            _currentPiece = chessBoardButton.ButtonPiece;

            MoveAPiece(chessBoardButton, line, column);

            if (_currentPiece == null) return;

            _currentPiece.Position = new Position(line, column);

            SelectButtonClicked(chessBoardButton);
        }

        private void SelectButtonClicked(ChessBoardButton chessBoardButton)
        {
            if (chessBoardButton.ButtonPiece != null)
            {
                VisualStateManager.GoToState(chessBoardButton, STATE_SELECTED, false);
                ShowPossiblePosition(chessBoardButton);
                _selectedPiece = _currentPiece;
                _selectedChessButton = chessBoardButton;
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
                        possiblePositions = pawn.GetPossiblesMoves();
                    break;
                case ChessPieces.KNIGHT:
                    if (_currentPiece is Knight knight)
                        possiblePositions = knight.GetPossiblesMoves();
                    break;
                case ChessPieces.BISHOP:
                    if (_currentPiece is Bishop bishop)
                        possiblePositions = bishop.GetPossiblesMoves();
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
                ChessBoardButton button = GetTemplateChild($"ChessButton{position.line}{position.column}") as ChessBoardButton;
                if (button.ButtonPiece == null)
                    VisualStateManager.GoToState(button, STATE_MOVE_POSITION, false);
                else
                    VisualStateManager.GoToState(button, STATE_CAPTURE_POSITION, false);
            }
            IsUserSelectingAPosition = true;
        }

        private void DiselectAllChessButtons()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (GetTemplateChild($"ChessButton{i}{j}") is ChessBoardButton button)
                        VisualStateManager.GoToState(button, STATE_NO_SELECTED, false);
                }
            }
        }

        private void MoveAPiece(ChessBoardButton chessBoardButton, int line, int column)
        {
            if (IsUserSelectingAPosition && _selectedPiece.GetPossiblesMoves().Contains(new Position(line, column)))
            {
                chessBoardButton.ImagePath = _selectedChessButton.ImagePath;
                chessBoardButton.ButtonPiece = _selectedChessButton.ButtonPiece;

                _selectedChessButton.ResetButton();
                _selectedPiece.Move(line, column);

                _currentPiece = null;

                if (chessBoardButton.ButtonPiece is Pawn pawn)
                    pawn.IsTheFirstMovement = false;
            }

            IsUserSelectingAPosition = false;
        }
    }
}
