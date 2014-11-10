using CapitalQuizPro.Models.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalQuizPro.Models.Interfaces
{
    public interface ITopListService
    {
        Task<List<TopListItem>> GetTopList();
        Task<List<TopListItem>> Add(string userName, int score);
    }
}
