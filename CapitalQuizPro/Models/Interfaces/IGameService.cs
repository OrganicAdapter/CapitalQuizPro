using CapitalQuizPro.Models.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalQuizPro.Models.Interfaces
{
    public interface IGameService
    {
        Task<Question> GetQuestion();
        Task<bool> SetAnswer(int userId, Question question, string answer);
        void SetFailed(int userId, int score);
        void SetFinished(int userId, int score);
    }
}
