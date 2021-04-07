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
            public KeyValuePair<DateTimeOffset, List<Stadium>> StadiumsCache { get; set; }
        }
        protected ApiCache Cache = new();

        public async Task<List<Stadium>> GetAllStadiums(string dumpFileName = null)
        {
            // Check cache.
            if (Cache.StadiumsCache.Key > DateTimeOffset.Now.AddMinutes(-2))
                return Cache.StadiumsCache.Value.ToList();

            // Call the API.
            var endpoint = new Uri($"{Endpoint}/v1/stadiums");
            var result = await ApiGet<ChroniclerApiResponse<Stadium>>(endpoint, dumpFileName);
            var stadiums = result.ExtractData();

            // Update the cache.
            Cache.StadiumsCache = new KeyValuePair<DateTimeOffset, List<Stadium>>(DateTimeOffset.Now, stadiums);

            return stadiums;
        }
    }
}
