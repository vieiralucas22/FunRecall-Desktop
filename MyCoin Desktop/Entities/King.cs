using MyCoin_Desktop.Common.Enums;
using System;
using System.Collections.Generic;

namespace MyCoin_Desktop.Entities
{
    public class King : Piece
    {
        public King(ChessPiecesColors color) : base(ChessPieces.KING, color)
        {
        }

        public override void Capture()
        {
            throw new NotImplementedException();
        }

        public override List<Position> GetPossiblesMoves()
        {
            List<Position> possibleMoves = new List<Position>();

            if (ChessBoard.IsValidPosition(Position.line, Position.column - 1, this))
                possibleMoves.Add(new Position(Position.line, Position.column - 1));

            if (ChessBoard.IsValidPosition(Position.line, Position.column + 1, this))
                possibleMoves.Add(new Position(Position.line, Position.column + 1));

            if (ChessBoard.IsValidPosition(Position.line - 1, Position.column, this))
                possibleMoves.Add(new Position(Position.line - 1, Position.column));

            if (ChessBoard.IsValidPosition(Position.line + 1, Position.column, this))
                possibleMoves.Add(new Position(Position.line + 1, Position.column));

            if (ChessBoard.IsValidPosition(Position.line - 1, Position.column - 1, this))
                possibleMoves.Add(new Position(Position.line - 1, Position.column - 1));

            if (ChessBoard.IsValidPosition(Position.line + 1, Position.column - 1, this))
                possibleMoves.Add(new Position(Position.line + 1, Position.column - 1));

            if (ChessBoard.IsValidPosition(Position.line - 1, Position.column + 1, this))
                possibleMoves.Add(new Position(Position.line - 1, Position.column + 1));

            if (ChessBoard.IsValidPosition(Position.line + 1, Position.column + 1, this))
                possibleMoves.Add(new Position(Position.line + 1, Position.column + 1));

            return possibleMoves;
        }
    }
}
