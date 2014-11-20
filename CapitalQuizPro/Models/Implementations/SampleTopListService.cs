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
                
                return TopList.OrderBy((x) => x.Place).ToList();
            }
            else
                return new List<TopListItem>();
        }

        public async Task<int> Add(string userName, int score)
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

            var place = 0;

            if (TopList.Count == 0)
            {
                var item = new TopListItem(userName, score, 1);
                TopList.Add(item);
                ApplicationData.Current.LocalSettings.Values["TopList"] = await JsonSerializer.Serialize(TopList);

                return 1;
            }
            else
            {
                foreach (var player in TopList)
                {
                    if (place == 0)
                    {
                        if (player.Score < score)
                        {
                            place = player.Place;
                            player.Place++;
                        }
                    }
                    else
                    {
                        player.Place++;
                    }
                }

                var item = new TopListItem(userName, score, place);
                TopList.Add(item);
                ApplicationData.Current.LocalSettings.Values["TopList"] = await JsonSerializer.Serialize(TopList);

                return place;
            }
        }
    }
}
