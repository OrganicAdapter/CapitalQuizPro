using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalQuizPro.ViewModels.Datas
{
    public class PlayerViewModel
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int Breaks { get; set; }
        public int Guesses { get; set; }
    }
}
