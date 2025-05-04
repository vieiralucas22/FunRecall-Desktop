using MyCoin_Desktop.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoin_Desktop.Entities
{
    public class Queen : Piece
    {

        private List<Position> possiblePositions;

        public Queen(ChessPiecesColors color) : base(ChessPieces.QUEEN, color)
        {
        }

        public override void Capture()
        {
            throw new NotImplementedException();
        }

        public override List<Position> GetPossiblesMoves()
        {
            possiblePositions = new List<Position>();

            AddDiagnolMoves();
            AddVerticalAndHorizontalMoves();

            return possiblePositions;
        }

        private void AddVerticalAndHorizontalMoves() {
            for (int i = 1; i < ChessBoard.Board.GetLength(0); i++)
            {
                if (!ChessBoard.CheckIfPositionIsOutBoard(Position.line - i, Position.column))
                {
                    if (ChessBoard.IsPositionEmpty(Position.line - i, Position.column))
                    {
                        possiblePositions.Add(new Position(Position.line - i, Position.column));
                    }
                    else
                    {
                        if (ChessBoard.HasAPieceToCapture(Position.line - i, Position.column, this))
                            possiblePositions.Add(new Position(Position.line - i, Position.column));

                        break;
                    }
                }
            }

            for (int i = 1; i < ChessBoard.Board.GetLength(0); i++)
            {
                if (!ChessBoard.CheckIfPositionIsOutBoard(Position.line + i, Position.column))
                {
                    if (ChessBoard.IsPositionEmpty(Position.line + i, Position.column))
                    {
                        possiblePositions.Add(new Position(Position.line + i, Position.column));
                    }
                    else
                    {
                        if (ChessBoard.HasAPieceToCapture(Position.line + i, Position.column, this))
                            possiblePositions.Add(new Position(Position.line + i, Position.column));

                        break;
                    }
                }
            }

            for (int i = 1; i < ChessBoard.Board.GetLength(0); i++)
            {
                if (!ChessBoard.CheckIfPositionIsOutBoard(Position.line, Position.column - i))
                {
                    if (ChessBoard.IsPositionEmpty(Position.line, Position.column - i))
                    {
                        possiblePositions.Add(new Position(Position.line, Position.column - i));
                    }
                    else
                    {
                        if (ChessBoard.HasAPieceToCapture(Position.line, Position.column - i, this))
                            possiblePositions.Add(new Position(Position.line, Position.column - i));

                        break;
                    }
                }
            }

            for (int i = 1; i < ChessBoard.Board.GetLength(0); i++)
            {
                if (!ChessBoard.CheckIfPositionIsOutBoard(Position.line, Position.column + i))
                {
                    if (ChessBoard.IsPositionEmpty(Position.line, Position.column + i))
                    {
                        possiblePositions.Add(new Position(Position.line, Position.column + i));
                    }
                    else
                    {
                        if (ChessBoard.HasAPieceToCapture(Position.line, Position.column + i, this))
                            possiblePositions.Add(new Position(Position.line, Position.column + i));

                        break;
                    }
                }
            }
        } 

        private void AddDiagnolMoves() {

            for (int i = 1; i < ChessBoard.Board.GetLength(0); i++)
            {
                if (!ChessBoard.CheckIfPositionIsOutBoard(Position.line + i, Position.column + i))
                {
                    if (ChessBoard.IsPositionEmpty(Position.line + i, Position.column + i))
                    {
                        possiblePositions.Add(new Position(Position.line + i, Position.column + i));
                    }
                    else
                    {
                        if (ChessBoard.HasAPieceToCapture(Position.line + i, Position.column + i, this))
                            possiblePositions.Add(new Position(Position.line + i, Position.column + i));

                        break;
                    }
                }
            }

            for (int i = 1; i < ChessBoard.Board.GetLength(0); i++)
            {
                if (!ChessBoard.CheckIfPositionIsOutBoard(Position.line + i, Position.column - i))
                {
                    if (ChessBoard.IsPositionEmpty(Position.line + i, Position.column - i))
                    {
                        possiblePositions.Add(new Position(Position.line + i, Position.column - i));
                    }
                    else
                    {
                        if (ChessBoard.HasAPieceToCapture(Position.line + i, Position.column - i, this))
                            possiblePositions.Add(new Position(Position.line + i, Position.column - i));

                        break;
                    }
                }
            }

            for (int i = 1; i < ChessBoard.Board.GetLength(0); i++)
            {
                if (!ChessBoard.CheckIfPositionIsOutBoard(Position.line - i, Position.column + i))
                {
                    if (ChessBoard.IsPositionEmpty(Position.line - i, Position.column + i))
                    {
                        possiblePositions.Add(new Position(Position.line - i, Position.column + i));
                    }
                    else
                    {
                        if (ChessBoard.HasAPieceToCapture(Position.line - i, Position.column + i, this))
                            possiblePositions.Add(new Position(Position.line - i, Position.column + i));

                        break;
                    }
                }
            }

            for (int i = 1; i < ChessBoard.Board.GetLength(0); i++)
            {
                if (!ChessBoard.CheckIfPositionIsOutBoard(Position.line - i, Position.column - i))
                {
                    if (ChessBoard.IsPositionEmpty(Position.line - i, Position.column - i))
                    {
                        possiblePositions.Add(new Position(Position.line - i, Position.column - i));
                    }
                    else
                    {
                        if (ChessBoard.HasAPieceToCapture(Position.line - i, Position.column - i, this))
                            possiblePositions.Add(new Position(Position.line - i, Position.column - i));

                        break;
                    }
                }
            }
        }
    }
}
