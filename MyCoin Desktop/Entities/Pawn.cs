using MyCoin_Desktop.Common.Enums;
using System;
using System.Collections.Generic;

namespace MyCoin_Desktop.Entities
{
    public class Pawn : Piece
    {

        private bool _isTheFirstMovement = true;

        public bool IsTheFirstMovement
        {
            get { return _isTheFirstMovement; }
            set { _isTheFirstMovement = value; }
        }

        public Pawn(ChessPiecesColors color) : base(ChessPieces.PAWN, color)
        {
        }

        public override void Capture()
        {
            throw new NotImplementedException();
        }

        public override List<Position> GetPossiblesMoves()
        {
            List<Position> positions = new List<Position>();

            foreach(Position capturePosition in GetCapturePosition()) {
                positions.Add(capturePosition);
            }

            if (IsTheFirstMovement)
            {
                if (IsWhitePiece())
                {
                    if (ChessBoard.IsPositionEmpty(Position.line - 1, Position.column))
                    {
                        positions.Add(new Position(Position.line - 1, Position.column));

                        if (ChessBoard.IsPositionEmpty(Position.line - 2, Position.column))
                        {
                            positions.Add(new Position(Position.line - 2, Position.column));
                        }
                    }

                    return positions;
                }

                if (ChessBoard.IsPositionEmpty(Position.line + 1, Position.column))
                {
                    positions.Add(new Position(Position.line + 1, Position.column));

                    if (ChessBoard.IsPositionEmpty(Position.line + 2, Position.column))
                    {
                        positions.Add(new Position(Position.line + 2, Position.column));
                    }
                }
            }
            else if (!IsTheFirstMovement)
            {
                if (IsWhitePiece())
                {
                    if (ChessBoard.IsValidPosition(Position.line - 1, Position.column, this) && ChessBoard.IsPositionEmpty(Position.line - 1, Position.column))
                        positions.Add(new Position(Position.line - 1, Position.column));
                }
                else
                {
                    if (ChessBoard.IsValidPosition(Position.line + 1, Position.column, this) && ChessBoard.IsPositionEmpty(Position.line + 1, Position.column))
                        positions.Add(new Position(Position.line + 1, Position.column));
                }
            }

            return positions;
        }

        public override List<Position> GetCapturePosition()
        {
            List<Position> capturePositions = new List<Position>();

            if (IsWhitePiece())
            {
                if (!ChessBoard.CheckIfPositionIsOutBoard(Position.line - 1, Position.column + 1) && ChessBoard.HasAPieceToCapture(Position.line - 1, Position.column + 1, this))
                    capturePositions.Add(new Position(Position.line - 1, Position.column + 1));

                if (!ChessBoard.CheckIfPositionIsOutBoard(Position.line - 1, Position.column - 1) && ChessBoard.HasAPieceToCapture(Position.line - 1, Position.column - 1, this))
                    capturePositions.Add(new Position(Position.line - 1, Position.column - 1));

                return capturePositions;
            }

            if (!ChessBoard.CheckIfPositionIsOutBoard(Position.line + 1, Position.column + 1) && ChessBoard.HasAPieceToCapture(Position.line + 1, Position.column + 1, this))
                capturePositions.Add(new Position(Position.line + 1, Position.column + 1));

            if (!ChessBoard.CheckIfPositionIsOutBoard(Position.line + 1, Position.column - 1) && ChessBoard.HasAPieceToCapture(Position.line + 1, Position.column - 1, this))
                capturePositions.Add(new Position(Position.line + 1, Position.column - 1));

            return capturePositions;
        }
    }
}
