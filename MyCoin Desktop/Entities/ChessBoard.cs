
namespace MyCoin_Desktop.Entities
{
    public static class ChessBoard
    {
        public static int[,] Board;

        public static bool IsPositionEmpty(int line, int column) => Board[line, column] == 0;

        public static bool IsValidPosition(int line, int column, Piece piece)
        {
            if (CheckIfPositionIsOutBoard(line, column)) return false;

            return (HasAPieceToCapture(line, column, piece) || IsPositionEmpty(line, column));
        }

        public static bool CheckIfPositionIsOutBoard(int line, int column) => (line < 0 || line > 7) || (column < 0 || column > 7);

        public static bool HasAPieceToCapture(int line, int column, Piece piece)
        {
            return piece.IsWhitePiece() ? Board[line, column] < 0 : Board[line, column] > 0;
        }

    }
}
