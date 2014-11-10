using CapitalQuizPro.Models.Datas;
using CapitalQuizPro.ViewModels.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalQuizPro.ViewModels.Connections
{
    public class QuestionConnector
    {
        private static Random _rnd = new Random();



        public static QuestionViewModel ConvertToViewModel(Question question)
        {
            var allanswers = new List<AnswerViewModel>();

            allanswers.Add(new AnswerViewModel(question.GoodAnswer));

            foreach (var answer in question.BadAnswers)
                allanswers.Add(new AnswerViewModel(answer));

            allanswers = Shuffle(allanswers);

            return new QuestionViewModel(question.Text, question.GoodAnswer, allanswers);
        }

        public static Question ConvertToModel(QuestionViewModel question)
        {
            var badanswers = new List<string>();

            foreach (var answer in question.AllAnswers)
            {
                if (!answer.Text.Equals(question.GoodAnswer))
                    badanswers.Add(answer.Text);
            }

            return new Question(question.Text, question.GoodAnswer, badanswers);
        }

        private static List<AnswerViewModel> Shuffle(List<AnswerViewModel> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var idx = _rnd.Next(list.Count);
                var akt = list[idx];
                list[idx] = list[i];
                list[i] = akt;
            }

            return list;
        }
    }
}
