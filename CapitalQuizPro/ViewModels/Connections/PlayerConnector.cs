using CapitalQuizPro.Models.Datas;
using CapitalQuizPro.ViewModels.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalQuizPro.ViewModels.Connections
{
    public class PlayerConnector
    {
        public static PlayerViewModel ConvertToViewModel(Player player, PlayerValues values)
        {
            return new PlayerViewModel(player.PlayerId, player.UserName, player.ProfileImageUri, values.Money, values.Score, values.Guesses, values.Breaks, values.Skips);
        }

        public static Player ConvertToPlayer(PlayerViewModel viewModel)
        {
            return new Player(viewModel.UserName, viewModel.PlayerId, viewModel.ProfileImage.UriSource.OriginalString);
        }

        public static PlayerValues ConvertToValues(PlayerViewModel viewModel)
        {
            return new PlayerValues(viewModel.Money, viewModel.Score, viewModel.Breaks, viewModel.Guesses, viewModel.Skips);
        }
    }
}
