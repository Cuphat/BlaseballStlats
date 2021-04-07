using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlaseballStlats.Models
{
    public class RenovationProgress
    {
        [JsonProperty("progress")]
        public Progress Progress { get; set; }

        [JsonProperty("stats")]
        public List<ElectionItem> Stats { get; set; }
    }

    public class Progress
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("toNext")]
        public double ToNext { get; set; }
    }
}
