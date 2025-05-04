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
            return new List<Position>();
        }

        public override List<Position> GetCapturePosition()
        {
            throw new NotImplementedException();
        }
    }
}
