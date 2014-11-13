using CapitalQuizPro.Models.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalQuizPro.Models.Interfaces
{
    public interface IPlayerService
    {
        Task<Player> GetPlayer();
        Task<PlayerValues> GetPlayerValues();
        void SetPlayerAndValues(Player player, PlayerValues playerValues);
    }
}
