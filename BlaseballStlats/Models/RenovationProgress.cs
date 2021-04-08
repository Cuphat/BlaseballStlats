using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlaseballStlats.Models
{
    public class RenovationProgress : IBlaseballData
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("validFrom")]
        public DateTimeOffset ValidFrom { get; set; }

        [JsonProperty("validTo")]
        public DateTimeOffset? ValidTo { get; set; }

        [JsonProperty("progress")]
        public RenovationsCompleted Progress { get; set; }

        [JsonProperty("stats")]
        public List<ElectionItem> Stats { get; set; }

        public class RenovationsCompleted
        {
            [JsonProperty("total")]
            public int Total { get; set; }

            [JsonProperty("toNext")]
            public double ToNext { get; set; }
        }
    }
}
