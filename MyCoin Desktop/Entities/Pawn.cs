using MyCoin_Desktop.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoin_Desktop.Entities
{
    public class Pawn : Piece
    {

        private bool _isTheFirstMovement = true;

        public bool IsTheFirstMovement
        {
            get { return _isTheFirstMovement; }
            set { _isTheFirstMovement = value; }
        }


        public Pawn(ChessPiecesColors color) : base(ChessPieces.PAWN, color)
        {
        }

        public override void Capture()
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            IsTheFirstMovement = false;
        }

        public override List<Position> GetPossiblesMoves(int[,] chessBoard)
        {
            List<Position> positions = new List<Position>();

            foreach(Position capturePosition in GetCapturePosition(chessBoard)){
                positions.Add(capturePosition);
            }

            if (IsTheFirstMovement)
            {
                if (IsWhitePiece())
                {
                    if (IsPositionEmpty(Position.line - 1, Position.column, chessBoard))
                    {
                        positions.Add(new Position(Position.line - 1, Position.column));

                        if (IsPositionEmpty(Position.line - 2, Position.column, chessBoard))
                        {
                            positions.Add(new Position(Position.line - 2, Position.column));
                        }
                    }

                    return positions;
                }

                if (IsPositionEmpty(Position.line + 1, Position.column, chessBoard))
                {
                    positions.Add(new Position(Position.line + 1, Position.column));

                    if (IsPositionEmpty(Position.line + 2, Position.column, chessBoard))
                    {
                        positions.Add(new Position(Position.line + 2, Position.column));
                    }
                }
            }
            else if (!IsTheFirstMovement)
            {
                if (IsWhitePiece())
                {
                    if (IsValidPosition() && IsPositionEmpty(Position.line - 1, Position.column, chessBoard))
                        positions.Add(new Position(Position.line - 1, Position.column));
                }
                else
                {
                    if (IsValidPosition() && IsPositionEmpty(Position.line + 1, Position.column, chessBoard))
                        positions.Add(new Position(Position.line + 1, Position.column));
                }
            }

            return positions;
        }

        public override List<Position> GetCapturePosition(int[,] chessBoard)
        {
            List<Position> capturePositions = new List<Position>();

            if (IsWhitePiece())
            {
                if (Position.column != 7 && chessBoard[Position.line - 1, Position.column + 1] < 0)
                {
                    capturePositions.Add(new Position(Position.line - 1, Position.column + 1));
                }

                if (Position.column != 0 && chessBoard[Position.line - 1, Position.column - 1] < 0)
                {
                    capturePositions.Add(new Position(Position.line - 1, Position.column - 1));
                }

                return capturePositions;
            }

            if (Position.column != 7 && chessBoard[Position.line + 1, Position.column + 1] > 0)
            {
                capturePositions.Add(new Position(Position.line + 1, Position.column + 1));
            }

            if (Position.column != 0 && chessBoard[Position.line + 1, Position.column - 1] > 0)
            {
                capturePositions.Add(new Position(Position.line + 1, Position.column - 1));
            }

            return capturePositions;
        }

        private bool IsPositionEmpty(int line, int column, int[,] chessBoard) => chessBoard[line, column] == 0;
        private bool IsValidPosition() => IsWhitePiece() ? Position.line - 1 >= 0 : Position.line + 1 <= 7;
    }
}
