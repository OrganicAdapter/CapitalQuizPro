using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalQuizPro.Models.Datas
{
    public class Capital
    {
        public string Country { get; set; }
        public string Name { get; set; }

        

        public Capital()
        {
            Country = "";
            Name = "";
        }

        public Capital(string country, string name)
        {
            Country = country;
            Name = name;
        }
    }
}
