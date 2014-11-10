using CapitalQuizPro.Models.Datas;
using CapitalQuizPro.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalExtensions;
using Windows.Storage;

namespace CapitalQuizPro.Models.Implementations
{
    public class SampleTopListService : ITopListService
    {
        private List<TopListItem> TopList { get; set; }


        public async Task<List<TopListItem>> GetTopList()
        {
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("TopList"))
            {
                var listjson = ApplicationData.Current.LocalSettings.Values["TopList"].ToString();

                TopList = await JsonSerializer.Deserialize<List<TopListItem>>(listjson);
                
                return TopList;
            }
            else
                return new List<TopListItem>();
        }

        public async Task<List<TopListItem>> Add(string userName, int score)
        {
            if (TopList == null)
            {
                if (ApplicationData.Current.LocalSettings.Values.ContainsKey("TopList"))
                {
                    var listjson = ApplicationData.Current.LocalSettings.Values["TopList"].ToString();

                    TopList = await JsonSerializer.Deserialize<List<TopListItem>>(listjson);
                }
                else
                    TopList = new List<TopListItem>();
            }

            TopList.Add(new TopListItem(userName, score, TopList.Count));
            ApplicationData.Current.LocalSettings.Values["TopList"] = await JsonSerializer.Serialize(TopList);

            return TopList;
        }
    }
}
