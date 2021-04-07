using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BlaseballStlats.Models;

namespace BlaseballStlats.DataControllers
{
    public class ApiControllerBlaseball : ApiControllerBase
    {
        public ApiControllerBlaseball() : base(new Uri("https://www.blaseball.com/database"))
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }

        protected class ApiCache
        {
            public DateTimeOffset AllTeamsCacheTime { get; set; }
            public Dictionary<Guid, KeyValuePair<DateTimeOffset, Team>> TeamCache { get; set; } = new();
            public Dictionary<Guid, KeyValuePair<DateTimeOffset, Player>> PlayerCache { get; set; } = new();
        }
        protected ApiCache Cache = new();

        public async Task<List<Team>> GetAllTeams(string dumpFileName = null)
        {
            // Check cache.
            if (Cache.AllTeamsCacheTime > DateTimeOffset.Now.AddMinutes(-2))
                return Cache.TeamCache.Select(c => c.Value.Value).ToList();

            // Call the API.
            var endpoint = new Uri($"{Endpoint}/allTeams");
            var teams = await ApiGet<List<Team>>(endpoint, dumpFileName);

            // Set LastUpdate to current time.
            foreach (var team in teams)
                team.LastUpdate = DateTimeOffset.Now;

            // Update the cache.
            Cache.AllTeamsCacheTime = DateTimeOffset.Now;
            foreach (var team in teams)
                Cache.TeamCache[team.Id] = new KeyValuePair<DateTimeOffset, Team>(DateTimeOffset.Now, team);

            return teams;
        }

        public async Task<Team> GetTeam(Guid teamId, string dumpFileName = null)
        {
            // Check cache.
            if (Cache.TeamCache.ContainsKey(teamId) && Cache.TeamCache[teamId].Key > DateTimeOffset.Now.AddMinutes(-2))
                return Cache.TeamCache[teamId].Value;

            // Call the API.
            var endpoint = new Uri($"{Endpoint}/team?id={teamId}");
            var team = await ApiGet<Team>(endpoint, dumpFileName);

            // Set LastUpdate to current time.
            team.LastUpdate = DateTimeOffset.Now;

            // Update the cache.
            Cache.TeamCache[teamId] = new KeyValuePair<DateTimeOffset, Team>(DateTimeOffset.Now, team);

            return team;
        }

        public async Task<List<Player>> GetPlayers(List<Guid> playerIds, Dictionary<Guid, Player> playersDict=null, string dumpFileName=null)
        {
            playersDict ??= new Dictionary<Guid, Player>();

            // Check cache and dictionary.
            foreach (var id in playerIds.Where(id => Cache.PlayerCache.ContainsKey(id) && Cache.PlayerCache[id].Key > DateTimeOffset.Now.AddMinutes(-2)))
                playersDict[id] = Cache.PlayerCache[id].Value;

            var playerIdsToQuery = playerIds.Where(playerId => !playersDict.ContainsKey(playerId)).ToList();

            // Call the API and integrate the results into the cache and playersDict.
            if (playerIdsToQuery.Any())
            {
                var endpoint = new Uri($"{Endpoint}/players?ids={string.Join(",", playerIdsToQuery)}");
                var result = await ApiGet<List<Player>>(endpoint, dumpFileName);
                foreach (var p in result)
                {
                    playersDict.Add(p.Id, p);
                    p.LastUpdate = DateTimeOffset.Now;
                    Cache.PlayerCache[p.Id] = new KeyValuePair<DateTimeOffset, Player>(DateTimeOffset.Now, p);
                }
            }

            return playerIds.Select(id => playersDict[id]).ToList();
        }
    }
}
