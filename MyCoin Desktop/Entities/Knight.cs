using MyCoin_Desktop.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Shapes;

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

        public override List<Position> GetPossiblesMoves(int[,] chessBoard)
        {
            List<Position> possiblesPositions = new List<Position>();

            if (IsValidPosition(Position.line - 1, Position.column - 2, chessBoard))
                possiblesPositions.Add(new Position(Position.line - 1, Position.column - 2));

            if (IsValidPosition(Position.line - 2, Position.column - 1, chessBoard))
                possiblesPositions.Add(new Position(Position.line - 2, Position.column - 1));

            if (IsValidPosition(Position.line - 2, Position.column + 1, chessBoard))
                possiblesPositions.Add(new Position(Position.line - 2, Position.column + 1));

            if (IsValidPosition(Position.line - 1, Position.column + 2, chessBoard))
                possiblesPositions.Add(new Position(Position.line - 1, Position.column + 2));

            if (IsValidPosition(Position.line + 1, Position.column - 2, chessBoard))
                possiblesPositions.Add(new Position(Position.line + 1, Position.column - 2));

            if (IsValidPosition(Position.line + 2, Position.column - 1, chessBoard))
                possiblesPositions.Add(new Position(Position.line + 2, Position.column - 1));

            if (IsValidPosition(Position.line + 1, Position.column + 2, chessBoard))
                possiblesPositions.Add(new Position(Position.line + 1, Position.column + 2));

            if (IsValidPosition(Position.line + 2, Position.column + 1, chessBoard))
                possiblesPositions.Add(new Position(Position.line + 2, Position.column + 1));

            return possiblesPositions;
        }

        public override List<Position> GetCapturePosition(int[,] chessBoard)
        {
            List<Position> capturePositions = new List<Position>();

            foreach (Position position in GetPossiblesMoves(chessBoard))
            {
                if (HasAPieceToCapture(chessBoard, position.line, position.column))
                    capturePositions.Add(position);
            }
            return capturePositions;
        }

        private bool CheckIfPositionIsOutBoard(int line, int column) => (line < 0 || line > 7) || (column < 0 || column > 7);

        private bool IsValidPosition(int line, int column, int[,] chessBoard)
        {
            if (CheckIfPositionIsOutBoard(line, column)) return false;

            return (HasAPieceToCapture(chessBoard, line, column) || IsPositionEmpty(line, column, chessBoard));
        }

        private bool IsPositionEmpty(int line, int column, int[,] chessBoard) => chessBoard[line, column] == 0;
    }
}
