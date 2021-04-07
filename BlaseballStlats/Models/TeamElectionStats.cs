using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlaseballStlats.Models
{
    public class TeamElectionStats
    {
        [JsonProperty("wills")]
        public List<ElectionItem> Wills { get; set; }
    }
}
