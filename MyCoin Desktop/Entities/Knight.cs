using MyCoin_Desktop.Common.Enums;
using System;
using System.Collections.Generic;

namespace MyCoin_Desktop.Entities
{
    public class Knight : Piece
    {
        public Knight(ChessPiecesColors color) : base(ChessPieces.KNIGHT, color)
        {
        }

        public override void Capture()
        {
            throw new NotImplementedException();
        }

        public override List<Position> GetPossiblesMoves()
        {
            List<Position> possiblesPositions = new List<Position>();

            if (chessBoard.IsValidPosition(Position.line - 1, Position.column - 2, this))
                possiblesPositions.Add(new Position(Position.line - 1, Position.column - 2));

            if (chessBoard.IsValidPosition(Position.line - 2, Position.column - 1, this))
                possiblesPositions.Add(new Position(Position.line - 2, Position.column - 1));

            if (chessBoard.IsValidPosition(Position.line - 2, Position.column + 1, this))
                possiblesPositions.Add(new Position(Position.line - 2, Position.column + 1));

            if (chessBoard.IsValidPosition(Position.line - 1, Position.column + 2, this))
                possiblesPositions.Add(new Position(Position.line - 1, Position.column + 2));

            if (chessBoard.IsValidPosition(Position.line + 1, Position.column - 2, this))
                possiblesPositions.Add(new Position(Position.line + 1, Position.column - 2));

            if (chessBoard.IsValidPosition(Position.line + 2, Position.column - 1, this))
                possiblesPositions.Add(new Position(Position.line + 2, Position.column - 1));

            if (chessBoard.IsValidPosition(Position.line + 1, Position.column + 2, this))
                possiblesPositions.Add(new Position(Position.line + 1, Position.column + 2));

            if (chessBoard.IsValidPosition(Position.line + 2, Position.column + 1, this))
                possiblesPositions.Add(new Position(Position.line + 2, Position.column + 1));

            return possiblesPositions;
        }

        public override List<Position> GetCapturePosition()
        {
            List<Position> capturePositions = new List<Position>();

            foreach (Position position in GetPossiblesMoves())
            {
                if (chessBoard.HasAPieceToCapture(position.line, position.column, this))
                    capturePositions.Add(position);
            }
            return capturePositions;
        }

    }
}
