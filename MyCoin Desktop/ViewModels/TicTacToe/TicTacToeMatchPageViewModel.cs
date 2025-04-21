using Microsoft.Practices.ServiceLocation;
using MyCoin_Desktop.Common;
using MyCoin_Desktop.Common.Enums;
using MyCoin_Desktop.Events;
using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoin_Desktop.ViewModels
{
    public class TicTacToeMatchPageViewModel : ViewModelBase
    {
        #region Event Listeners
        private IGameEvents _gameEvents;
        private IGameEvents GameEvents => _gameEvents ?? ServiceLocator.Current.GetInstance<IGameEvents>();
        #endregion

        #region Properties
        private string _gameResult;
        public string GameResult
        {
            get { return _gameResult; }
            set { SetProperty(ref _gameResult, value); }
        }
        #endregion

        #region Constructor
        public TicTacToeMatchPageViewModel()
        {
            GameEvents.GameIsOverEvent += GameEvents_GameIsOverEvent;
        }
        #endregion

        #region Methods trigger by events
        private void GameEvents_GameIsOverEvent(string game, Players winner)
        {
            if (string.IsNullOrEmpty(game)) return;

            if (game.Equals(GameConstants.TIC_TAC_TOE))
            {
                UpdateResult(winner);
            }
        }

        #endregion

        #region Private Methods
        private void UpdateResult(Players winner)
        {
            string result = "It's a tie";

            if (winner.ToString().Equals("PLAYER_1"))
            {
                result = "Player 1 wins!";
            }
            else if (winner.ToString().Equals("PLAYER_2"))
            {
                result = "Player 2 wins!";
            }

            GameResult = result;
        }
        #endregion
    }
}
