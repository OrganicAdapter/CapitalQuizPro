using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalExtensions.MVVM;

namespace CapitalQuizPro.ViewModels.Datas
{
    public class QuestionViewModel
    {
        public string Text { get; set; }
        public string GoodAnswer { get; set; }
        public List<AnswerViewModel> AllAnswers { get; set; }



        public QuestionViewModel()
        {
            Text = "";
            GoodAnswer = "";
            AllAnswers = new List<AnswerViewModel>();
        }

        public QuestionViewModel(string text, string goodAnswer, List<AnswerViewModel> badAnswers, string selectedAnswer = "")
        {
            Text = text;
            GoodAnswer = goodAnswer;
            AllAnswers = badAnswers;
        }
    }
}
