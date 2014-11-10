using CapitalQuizPro.Models.Datas;
using CapitalQuizPro.ViewModels.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalQuizPro.ViewModels.Connections
{
    public class TopListConnector
    {
        public static TopListItemViewModel ConvertToViewModel(TopListItem question)
        {
            return new TopListItemViewModel(question.Name, question.Score, question.Place);
        }

        public static TopListItem ConvertToModel(TopListItemViewModel question)
        {
            return new TopListItem(question.Name, question.Score, question.Place);
        }
    }
}
