using CapitalQuizPro.Models.Datas;
using CapitalQuizPro.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalQuizPro.Models.Implementations
{
    public class SamplePlayerService : IPlayerService
    {
        public async Task<Player> GetPlayer()
        {
            return new Player("Geri", 0);
        }

        public async Task<PlayerValues> GetPlayerValues()
        {
            return new PlayerValues(0, 0, 2, 2, 2);
        }

        public void SetPlayerAndValues(Player player, PlayerValues playerValues)
        {
            
        }
    }
}
