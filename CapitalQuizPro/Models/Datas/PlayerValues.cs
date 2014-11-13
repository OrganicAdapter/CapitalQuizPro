using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalQuizPro.Models.Datas
{
    public class PlayerValues
    {
        public int Money { get; set; }
        public int Score { get; set; }
        public int Breaks { get; set; }
        public int Guesses { get; set; }
        public int Skips { get; set; }



        public PlayerValues()
        {
            Money = 0;
            Score = 0;
            Breaks = 0;
            Guesses = 0;
            Skips = 0;
        }

        public PlayerValues(int money, int score, int breaks, int guesses, int skips)
        {
            Money = money;
            Score = score;
            Breaks = breaks;
            Guesses = guesses;
            Skips = skips;
        }
    }
}
