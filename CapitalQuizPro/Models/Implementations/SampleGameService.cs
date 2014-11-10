using CapitalQuizPro.Models.Datas;
using CapitalQuizPro.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalQuizPro.Models.Implementations
{
    public class SampleGameService : IGameService
    {
        private List<Capital> Capitals { get; set; }
        private List<Capital> CloneCapitals { get; set; }
        private static Random _rnd = new Random();


        public SampleGameService()
        {
            Capitals = new List<Capital>()
            {
                new Capital("Magyarország", "Budapest"),
                new Capital("Románia", "Bucharest"),
                new Capital("Németország", "Berlin"),
                new Capital("Oroszország", "Moszkva"),
                new Capital("Amerika", "Washington")
            };

            CloneCapitals = new List<Capital>(Capitals);
        }


        public async Task<Question> GetQuestion()
        {
            //Return, if not enough questions left.
            if (CloneCapitals.Count == 0) return null;

            //Select capital
            var capital = CloneCapitals[_rnd.Next(CloneCapitals.Count)];
            CloneCapitals.Remove(capital);

            //Select bad answers
            var badanswers = new List<string>();
            var clonecapitals = new List<Capital>(Capitals);

            for (int i = 0; i < 3; i++)
            {
                var bad = clonecapitals[_rnd.Next(clonecapitals.Count)];

                if (bad.Equals(capital))
                    i--;
                else
                {
                    clonecapitals.Remove(bad);
                    badanswers.Add(bad.Name);
                }
            }

            return new Question("What's the capital of " + capital.Country + "?", capital.Name, badanswers);
        }

        public async Task<bool> SetAnswer(int userId, Question question, string answer)
        {
            if (question.GoodAnswer.Equals(answer))
                return true;
            else
                return false;
        }

        public void SetFailed(int userId, int score)
        {
            
        }

        public void SetFinished(int userId, int score)
        {
            
        }
    }
}
