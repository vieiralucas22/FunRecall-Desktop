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
        public Queen(ChessPiecesColors color) : base(ChessPieces.QUEEN, color)
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
            //if (IsTheFirstMovement)
            //{
            //}
            //else if (!IsTheFirstMovement)
            //{

            //}
            return new List<Position>();
        }
    }
}
