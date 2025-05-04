using MyCoin_Desktop.Common.Enums;
using MyCoin_Desktop.Controls;
using MyCoin_Desktop.Extensions;
using System.Collections.Generic;
using System.Data.Common;
using Windows.UI.Xaml.Shapes;

namespace MyCoin_Desktop.Entities
{
    public abstract class Piece
    {
        public ChessPieces PieceType { get; set; }
        public ChessPiecesColors Color { get; set; }
        public Position Position { get; set; }
        protected ChessBoard chessBoard;

        public Piece(ChessPieces pieceType, ChessPiecesColors color)
        {
            PieceType = pieceType;
            Color = color;
            chessBoard = ChessBoard.GetInstance;
        }

        public virtual void Move(int line, int column)
        {
            chessBoard.Board[line, column] = chessBoard.Board[Position.line, Position.column];
            chessBoard.Board[Position.line, Position.column] = 0;
        }
        public abstract void Capture();
        public abstract List<Position> GetCapturePosition();
        public bool IsWhitePiece() => Color.GetDescription().Equals("White");
        public abstract List<Position> GetPossiblesMoves();
        
    }
}
