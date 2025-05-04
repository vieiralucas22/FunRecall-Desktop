using MyCoin_Desktop.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoin_Desktop.Entities
{
    public class ChessBoard
    {
        public static ChessBoard _instance;

        public int[,] Board { get; private set; }

        public ChessBoard()
        {
            Board = new int[8, 8] {
                { -2, -3, -4, -6, -5, -4, -3, -2 },
                { -1, -1, -1, -1, -1, -1, -1, -1 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 1, 1, 1, 1, 1, 1, 1, 1 },
                { 2, 3, 4, 6, 5, 4, 3, 2 }
            };
        }

        public static ChessBoard GetInstance
        {
            get
            {
                if (_instance == null)
                    _instance = new ChessBoard();
                return _instance;
            }
        }

        public bool IsPositionEmpty(int line, int column) => Board[line, column] == 0;

        public bool IsValidPosition(int line, int column, Piece piece)
        {
            if (CheckIfPositionIsOutBoard(line, column)) return false;

            return (HasAPieceToCapture(line, column, piece) || IsPositionEmpty(line, column));
        }

        public bool CheckIfPositionIsOutBoard(int line, int column) => (line < 0 || line > 7) || (column < 0 || column > 7);

        public bool HasAPieceToCapture(int line, int column, Piece piece)
        {
            return piece.IsWhitePiece() ? Board[line, column] < 0 : Board[line, column] > 0;
        }

    }
}
