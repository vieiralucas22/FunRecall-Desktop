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

        public Piece(ChessPieces pieceType, ChessPiecesColors color)
        {
            PieceType = pieceType;
            Color = color;
        }

        public virtual void Move(int line, int column)
        {
            ChessBoard.Board[line, column] = ChessBoard.Board[Position.line, Position.column];
            ChessBoard.Board[Position.line, Position.column] = 0;
        }

        public abstract void Capture();

        public virtual List<Position> GetCapturePosition()
        {
            List<Position> capturePositions = new List<Position>();

            foreach (Position position in GetPossiblesMoves())
            {
                if (ChessBoard.HasAPieceToCapture(position.line, position.column, this))
                    capturePositions.Add(position);
            }
            return capturePositions;
        }

        public bool IsWhitePiece() => Color.GetDescription().Equals("White");
        public abstract List<Position> GetPossiblesMoves();

    }
}
