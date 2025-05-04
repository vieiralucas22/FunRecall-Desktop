using MyCoin_Desktop.Common.Enums;
using System;
using System.Collections.Generic;

namespace MyCoin_Desktop.Entities
{
    public class Bishop : Piece
    {
        public Bishop(ChessPiecesColors color) : base(ChessPieces.BISHOP, color)
        {
        }

        public override void Capture()
        {
            throw new NotImplementedException();
        }

        public override List<Position> GetPossiblesMoves()
        {
            List<Position> possiblePosition = new List<Position>();

            for (int i = 1; i < chessBoard.Board.GetLength(0); i++)
            {
                if (!chessBoard.CheckIfPositionIsOutBoard(Position.line + i, Position.column + i))
                {
                    if (chessBoard.IsPositionEmpty(Position.line + i, Position.column + i))
                    {
                        possiblePosition.Add(new Position(Position.line + i, Position.column + i));
                    }
                    else
                    {
                        if (chessBoard.HasAPieceToCapture(Position.line + i, Position.column + i, this))
                            possiblePosition.Add(new Position(Position.line + i, Position.column + i));

                        break;
                    }
                }
            }

            for (int i = 1; i < chessBoard.Board.GetLength(0); i++)
            {
                if (!chessBoard.CheckIfPositionIsOutBoard(Position.line + i, Position.column - i))
                {
                    if (chessBoard.IsPositionEmpty(Position.line + i, Position.column - i))
                    {
                        possiblePosition.Add(new Position(Position.line + i, Position.column - i));
                    }
                    else
                    {
                        if (chessBoard.HasAPieceToCapture(Position.line + i, Position.column - i, this))
                            possiblePosition.Add(new Position(Position.line + i, Position.column - i));

                        break;
                    }
                }
            }

            for (int i = 1; i < chessBoard.Board.GetLength(0); i++)
            {
                if (!chessBoard.CheckIfPositionIsOutBoard(Position.line - i, Position.column + i))
                {
                    if (chessBoard.IsPositionEmpty(Position.line - i, Position.column + i))
                    {
                        possiblePosition.Add(new Position(Position.line - i, Position.column + i));
                    }
                    else
                    {
                        if (chessBoard.HasAPieceToCapture(Position.line - i, Position.column + i, this))
                            possiblePosition.Add(new Position(Position.line - i, Position.column + i));

                        break;
                    }
                }
            }

            for (int i = 1; i < chessBoard.Board.GetLength(0); i++)
            {
                if (!chessBoard.CheckIfPositionIsOutBoard(Position.line - i, Position.column - i))
                {
                    if (chessBoard.IsPositionEmpty(Position.line - i, Position.column - i))
                    {
                        possiblePosition.Add(new Position(Position.line - i, Position.column - i));
                    }
                    else
                    {
                        if (chessBoard.HasAPieceToCapture(Position.line - i, Position.column - i, this))
                            possiblePosition.Add(new Position(Position.line - i, Position.column - i));

                        break;
                    }
                }
            }

            return possiblePosition;
        }
    }
}
