﻿using MyCoin_Desktop.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoin_Desktop.Entities
{
    public class Rook : Piece
    {
        public Rook(ChessPiecesColors color) : base(ChessPieces.ROOK, color)
        {
        }

        public override void Capture()
        {
            throw new NotImplementedException();
        }

        public override List<Position> GetPossiblesMoves()
        {
            List<Position> possiblesPositions = new List<Position>();

            for (int i = 1; i < ChessBoard.Board.GetLength(0); i++)
            {
                if (!ChessBoard.CheckIfPositionIsOutBoard(Position.line - i, Position.column))
                {
                    if (ChessBoard.IsPositionEmpty(Position.line - i, Position.column))
                    {
                        possiblesPositions.Add(new Position(Position.line - i, Position.column));
                    }
                    else
                    {
                        if (ChessBoard.HasAPieceToCapture(Position.line - i, Position.column, this))
                            possiblesPositions.Add(new Position(Position.line - i, Position.column));

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
                        possiblesPositions.Add(new Position(Position.line + i, Position.column));
                    }
                    else
                    {
                        if (ChessBoard.HasAPieceToCapture(Position.line + i, Position.column, this))
                            possiblesPositions.Add(new Position(Position.line + i, Position.column));

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
                        possiblesPositions.Add(new Position(Position.line, Position.column - i));
                    }
                    else
                    {
                        if (ChessBoard.HasAPieceToCapture(Position.line, Position.column - i, this))
                            possiblesPositions.Add(new Position(Position.line, Position.column - i));

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
                        possiblesPositions.Add(new Position(Position.line, Position.column + i));
                    }
                    else
                    {
                        if (ChessBoard.HasAPieceToCapture(Position.line, Position.column + i, this))
                            possiblesPositions.Add(new Position(Position.line, Position.column + i));

                        break;
                    }
                }
            }

            return possiblesPositions;
        }
    }
}
