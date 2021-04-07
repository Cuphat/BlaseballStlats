using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlaseballStlats.Models
{
    public class ChroniclerApiResponse<T> where T : class, IChroniclerApiData
    {
        [JsonProperty("data")]
        public List<ChroniclerApiData<T>> Data { get; set; }

        public List<T> ExtractData()
        {
            return Data.Select(d => d.ExtractData()).ToList();
        }
    }

    public class ChroniclerApiData<T> : IChroniclerApiData where T : class, IChroniclerApiData
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("lastUpdate")]
        public DateTimeOffset LastUpdate { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        public T ExtractData()
        {
            Data.LastUpdate = LastUpdate;
            return Data;
        }
    }

    public interface IChroniclerApiData
    {
        Guid Id { get; set; }
        DateTimeOffset LastUpdate { get; set; }
    }
}
