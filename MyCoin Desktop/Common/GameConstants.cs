using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoin_Desktop.Common
{
    public static class GameConstants
    {
        public const string PLAYER_ONE = "Player 1";
        public const string PLAYER_TWO = "Player 2";
        public const string PLAYER_ONE_SOURCE = "ms-appx:///Assets/Images/X.png";
        public const string PLAYER_TWO_SOURCE = "ms-appx:///Assets/Images/O.png";

        #region Games
        public const string TIC_TAC_TOE = "TicTacToe";
        public const string HANGMAN = "Hangman";
        public const string CHESS = "Chess";
        public const string WHAT_IS_MY_NUMBER = "WhatIsMyNumber";
        #endregion

        #region Chess Pieces
        public const string PAWN = "Pawn";
        public const string ROOK = "Rook";
        public const string KNIGHT = "Knight";
        public const string BISHOP = "Bishop";
        public const string QUEEN = "Queen";
        public const string KING = "King";
        #endregion
    }
}
