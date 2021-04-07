using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlaseballStlats.Models
{
    public class ElectionItem
    {
        [JsonProperty("percent")]
        public string Percent { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
