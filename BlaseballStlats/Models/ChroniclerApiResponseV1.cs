using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlaseballStlats.Models
{
    public class ChroniclerApiResponseV1<T> where T : class, IBlaseballData
    {
        [JsonProperty("data")]
        public List<ChroniclerApiDataV1<T>> Data { get; set; }

        public List<T> ExtractData()
        {
            return Data.Select(d => d.ExtractData()).ToList();
        }
    }

    public class ChroniclerApiDataV1<T> where T : class, IBlaseballData
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("lastUpdate")]
        public DateTimeOffset LastUpdate { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        public T ExtractData()
        {
            Data.ValidFrom = LastUpdate;
            return Data;
        }
    }
}
