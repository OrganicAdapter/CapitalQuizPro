using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalQuizPro.Models.Datas
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ProfileImageUri { get; set; }



        public Player()
        {
            PlayerId = -1;
            Email = "";
            UserName = "";
            Password = "";
            ProfileImageUri = "";
        }

        public Player(string userName, int playerId, string profileImageUri = "", string email = "", string password = "")
        {
            PlayerId = playerId;
            Email = email;
            UserName = userName;
            Password = password;
            ProfileImageUri = profileImageUri;
        }
    }
}
