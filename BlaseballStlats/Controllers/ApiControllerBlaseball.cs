using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BlaseballStlats.Models;

namespace BlaseballStlats.Controllers
{
    public class ApiControllerBlaseball : ApiControllerBase
    {

        public ApiControllerBlaseball() : base(new Uri("https://www.blaseball.com/database"))
        {
            // Force TLS 1.2.
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }

        public async Task<List<Team>> GetAllTeams(string dumpFileName = null)
        {
            var endpoint = new Uri($"{Endpoint}/allTeams");
            var result = await ApiGet<List<Team>>(endpoint, dumpFileName);

            return result;
        }

        public async Task<Team> GetTeam(Guid teamId, string dumpFileName = null)
        {
            var endpoint = new Uri($"{Endpoint}/team?id={teamId}");
            var result = await ApiGet<Team>(endpoint, dumpFileName);

            return result;
        }

        public async Task<List<Player>> GetPlayers(List<Guid> playerIds, string dumpFileName=null)
        {
            var endpoint = new Uri($"{Endpoint}/players?ids={string.Join(",", playerIds)}");
            var result = await ApiGet<List<Player>>(endpoint, dumpFileName);

            return result;
        }
    }
}
