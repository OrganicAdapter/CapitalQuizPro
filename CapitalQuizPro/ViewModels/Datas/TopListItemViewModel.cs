using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalQuizPro.ViewModels.Datas
{
    public class TopListItemViewModel
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int Place { get; set; }



        public TopListItemViewModel()
        {
            Name = "";
            Score = 0;
            Place = 0;
        }

        public TopListItemViewModel(string name, int score, int place)
        {
            Name = name;
            Score = score;
            Place = place;
        }
    }
}
