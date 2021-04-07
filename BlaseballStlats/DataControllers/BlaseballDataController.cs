using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlaseballStlats.Models;

namespace BlaseballStlats.DataControllers
{
    public class BlaseballDataController
    {
        protected readonly ApiControllerBlaseball BlaseballApi = new();
        protected readonly ApiControllerChronicler ChroniclerApi = new();

        public async Task<List<Team>> GetAllTeams(Dictionary<Guid, Player> playersDict = null)
        {
            playersDict ??= new Dictionary<Guid, Player>();

            var teams = await BlaseballApi.GetAllTeams();
            var stadiums = await ChroniclerApi.GetAllStadiums();
            var stadiumDict = stadiums.ToDictionary(s => s.Id);
            foreach (var team in teams)
            {
                await GetPlayersInTeam(team, playersDict);
                await GetStatsAndStadium(team, stadiumDict);
            }

            return teams;
        }

        protected async Task GetPlayersInTeam(Team team, Dictionary<Guid, Player> playersDict = null)
        {
            playersDict ??= new Dictionary<Guid, Player>();

            team.Lineup = await BlaseballApi.GetPlayers(team.LineupIds, playersDict);
            team.Rotation = await BlaseballApi.GetPlayers(team.RotationIds, playersDict);
            team.Bench = await BlaseballApi.GetPlayers(team.BenchIds, playersDict);
            team.Bullpen = await BlaseballApi.GetPlayers(team.BullpenIds, playersDict);

            foreach (var player in team.Players)
            {
                if (player.LeagueTeamId.GetValueOrDefault() == team.Id)
                    player.LeagueTeam = team;
                else if (player.TournamentTeamId.GetValueOrDefault() == team.Id)
                    player.TournamentTeam = team;
            }
        }

        protected async Task GetStatsAndStadium(Team team, Dictionary<Guid, Stadium> stadiumDict)
        {
            // Add Stadium to Team Object
            if (team.StadiumId.HasValue && stadiumDict.ContainsKey(team.StadiumId.Value))
                team.Stadium = stadiumDict[team.StadiumId.Value];

            // Get TeamElectionStats for the team and RenovationProgress for the stadium.
            team.TeamElectionStats = await BlaseballApi.GetTeamElectionStats(team.Id);
            if (team.Stadium != null)
                team.Stadium.RenovationProgress = await BlaseballApi.GetRenovationProgress(team.Stadium.Id);
        }
    }
}
