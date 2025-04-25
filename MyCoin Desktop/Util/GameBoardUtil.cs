using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoin_Desktop.Util
{
    public static class GameBoardUtil
    {
        public static (int, int) GetLineAndColumn(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag)) return (0, 0);

            var lineAndColumn = tag.Split(":");

            return (int.Parse(lineAndColumn[0]), int.Parse(lineAndColumn[1]));
        }
    }
}
