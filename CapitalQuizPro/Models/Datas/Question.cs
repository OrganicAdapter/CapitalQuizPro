using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalQuizPro.Models.Datas
{
    public class Question
    {
        public string Text { get; set; }
        public string GoodAnswer { get; set; }
        public List<string> BadAnswers { get; set; }



        public Question()
        {
            Text = "";
            GoodAnswer = "";
            BadAnswers = new List<string>();
        }

        public Question(string text, string goodAnswer, List<string> badAnswers)
        {
            Text = text;
            GoodAnswer = goodAnswer;
            BadAnswers = badAnswers;
        }
    }
}
