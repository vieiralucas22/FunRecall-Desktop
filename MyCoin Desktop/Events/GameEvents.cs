using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCoin_Desktop.Common.Enums;

namespace MyCoin_Desktop.Events
{
    public delegate void GameIsOverEvent(string game, Players winner);

    public interface IGameEvents
    {
        event GameIsOverEvent GameIsOverEvent;
        void RaiseOnGameIsOverEvent(string game, Players winner);
    }

    public class GameEvents : IGameEvents
    {
        public event GameIsOverEvent GameIsOverEvent = delegate { };

        public void RaiseOnGameIsOverEvent(string game, Players winner)
        {
            GameIsOverEvent(game, winner);
        }
    }
}
