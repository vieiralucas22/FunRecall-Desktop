using MyCoin_Desktop.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override List<Position> GetPossiblesMoves(int[,] _chessBoard)
        {
            return new List<Position>();
        }

        public override List<Position> GetCapturePosition(int[,] chessBoard)
        {
            throw new NotImplementedException();
        }
    }
}
