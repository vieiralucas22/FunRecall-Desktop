using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoin_Desktop.Common.Enums
{
    public enum ChessPieces
    {
        [Description("None")]
        NONE = 0,

        [Description("Pawn")]
        PAWN = 1,

        [Description("Rook")]
        ROOK = 2,

        [Description("Knight")]
        KNIGHT = 3,

        [Description("Bishop")]
        BISHOP = 4,

        [Description("Queen")]
        QUEEN = 5,

        [Description("King")]
        KING = 6
    }
}
