using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlaseballStlats.Models
{
    public class ChroniclerApiResponseV2<T> where T : class, IBlaseballData
    {
        [JsonProperty("nextPage")]
        public string NextPage { get; set; }

        [JsonProperty("items")]
        public List<ChroniclerApiItemsV2<T>> Items { get; set; }

        public List<T> ExtractData()
        {
            return Items.Select(d => d.ExtractData()).ToList();
        }
    }

    public class ChroniclerApiItemsV2<T> where T : class, IBlaseballData
    {
        [JsonProperty("entityId")]
        public Guid EntityId { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("validFrom")]
        public DateTimeOffset ValidFrom { get; set; }

        [JsonProperty("validTo")]
        public DateTimeOffset? ValidTo { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        public T ExtractData()
        {
            Data.Id = EntityId;
            Data.ValidFrom = ValidFrom;
            Data.ValidTo = ValidTo;
            return Data;
        }
    }
}
