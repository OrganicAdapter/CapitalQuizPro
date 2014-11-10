using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalQuizPro.Models.Datas
{
    public class TopListItem
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int Place { get; set; }



        public TopListItem()
        {
            Name = "";
            Score = 0;
            Place = 0;
        }

        public TopListItem(string name, int score, int place)
        {
            Name = name;
            Score = score;
            Place = place;
        }
    }
}
