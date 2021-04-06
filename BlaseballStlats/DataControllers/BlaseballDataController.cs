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

        public async Task<List<Team>> GetAllTeams(Dictionary<Guid, Player> playersDict = null)
        {
            playersDict ??= new Dictionary<Guid, Player>();

            var teams = await BlaseballApi.GetAllTeams();
            foreach (var team in teams)
                await GetPlayersInTeam(team, playersDict);

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
    }
}
