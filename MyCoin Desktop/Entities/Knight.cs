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

            if (ChessBoard.IsValidPosition(Position.line - 1, Position.column - 2, this))
                possiblesPositions.Add(new Position(Position.line - 1, Position.column - 2));

            if (ChessBoard.IsValidPosition(Position.line - 2, Position.column - 1, this))
                possiblesPositions.Add(new Position(Position.line - 2, Position.column - 1));

            if (ChessBoard.IsValidPosition(Position.line - 2, Position.column + 1, this))
                possiblesPositions.Add(new Position(Position.line - 2, Position.column + 1));

            if (ChessBoard.IsValidPosition(Position.line - 1, Position.column + 2, this))
                possiblesPositions.Add(new Position(Position.line - 1, Position.column + 2));

            if (ChessBoard.IsValidPosition(Position.line + 1, Position.column - 2, this))
                possiblesPositions.Add(new Position(Position.line + 1, Position.column - 2));

            if (ChessBoard.IsValidPosition(Position.line + 2, Position.column - 1, this))
                possiblesPositions.Add(new Position(Position.line + 2, Position.column - 1));

            if (ChessBoard.IsValidPosition(Position.line + 1, Position.column + 2, this))
                possiblesPositions.Add(new Position(Position.line + 1, Position.column + 2));

            if (ChessBoard.IsValidPosition(Position.line + 2, Position.column + 1, this))
                possiblesPositions.Add(new Position(Position.line + 2, Position.column + 1));

            return possiblesPositions;
        }
    }
}
