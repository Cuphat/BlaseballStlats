using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlaseballStlats.Models
{
    public class TeamElectionStats : IBlaseballData
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("validFrom")]
        public DateTimeOffset ValidFrom { get; set; }

        [JsonProperty("validTo")]
        public DateTimeOffset? ValidTo { get; set; }

        [JsonProperty("wills")]
        public List<ElectionItem> Wills { get; set; }
    }
}
