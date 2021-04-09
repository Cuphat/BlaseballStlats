using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BlaseballStlats.Models;

namespace BlaseballStlats.DataControllers
{
    public class ApiControllerChronicler : ApiControllerBase
    {
        public ApiControllerChronicler() : base(new Uri("https://api.sibr.dev/chronicler"))
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }

        protected class ApiCache
        {
            public KeyValuePair<DateTimeOffset, List<Stadium>> Stadiums { get; set; }
        }
        protected ApiCache Cache = new();

        public async Task<List<Stadium>> GetAllStadiums(string dumpFileName = null)
        {
            // Check cache.
            if (Cache.Stadiums.Key > DateTimeOffset.Now.AddMinutes(-2))
                return Cache.Stadiums.Value.ToList();

            // Call the API.
            var endpoint = new Uri($"{Endpoint}/v2/entities?type=stadium");
            var result = await ApiGet<ChroniclerApiResponseV2<Stadium>>(endpoint, dumpFileName);
            var stadiums = result.ExtractData();

            // Update the cache.
            Cache.Stadiums = new KeyValuePair<DateTimeOffset, List<Stadium>>(DateTimeOffset.Now, stadiums);

            return stadiums;
        }

        public async Task<Player> GetPlayer(Guid playerId, DateTimeOffset time, string dumpFileName = null)
        {
            var endpoint = new Uri($"{Endpoint}/v2/entities?type=player&id={playerId}&at={time:s}Z");
            var result = await ApiGet<ChroniclerApiResponseV2<Player>>(endpoint, dumpFileName);
            var player = result.ExtractData().FirstOrDefault();

            return player;
        }
    }
}
