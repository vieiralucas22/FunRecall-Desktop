using MyCoin_Desktop.Common.Enums;
using MyCoin_Desktop.Extensions;
using System.Collections.Generic;

namespace MyCoin_Desktop.Entities
{
    public abstract class Piece
    {
        public ChessPieces PieceType { get; set; }
        public ChessPiecesColors Color { get; set; }
        public Position Position { get; set; }

        public Piece(ChessPieces pieceType, ChessPiecesColors color) {
            PieceType = pieceType;
            Color = color;
        }

        public abstract void Move();
        public abstract void Capture();
        public abstract List<Position> GetCapturePosition(int[,] chessBoard);
        public bool IsWhitePiece() => Color.GetDescription().Equals("White");
        public abstract List<Position> GetPossiblesMoves(int[,] _chessBoard);
        public bool HasAPieceToCapture(int[,] chessBoard, int line, int column)
        {
            return IsWhitePiece() ? chessBoard[line, column] < 0 : chessBoard[line, column] > 0;
        }
    }
}
