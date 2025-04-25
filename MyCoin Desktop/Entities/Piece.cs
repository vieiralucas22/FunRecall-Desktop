using MyCoin_Desktop.Common.Enums;

namespace MyCoin_Desktop.Entities
{
    public abstract class Piece
    {
        public ChessPieces PieceType { get; set; }
        public ChessPiecesColors Color { get; set; }

        public Piece(ChessPieces pieceType, ChessPiecesColors color) {
            PieceType = pieceType;
            Color = color;
        }

        public abstract void Move();
        public abstract void Capture();
    }
}
