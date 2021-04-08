using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlaseballStlats.Models
{
    public class Team : IChroniclerApiData
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("lastUpdate")]
        public DateTimeOffset LastUpdate { get; set; }

        [JsonProperty("lineup")]
        public List<Guid> LineupIds { get; set; }

        [JsonProperty("rotation")]
        public List<Guid> RotationIds { get; set; }

        [JsonProperty("bullpen")]
        public List<Guid> BullpenIds { get; set; }

        [JsonProperty("bench")]
        public List<Guid> BenchIds { get; set; }

        [JsonProperty("seasAttr")]
        public List<string> SeasAttr { get; set; }

        [JsonProperty("permAttr")]
        public List<string> PermAttr { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("mainColor")]
        public string MainColor { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("secondaryColor")]
        public string SecondaryColor { get; set; }

        [JsonProperty("shorthand")]
        public string Shorthand { get; set; }

        [JsonProperty("emoji")]
        public string Emoji { get; set; }

        [JsonProperty("slogan")]
        public string Slogan { get; set; }

        [JsonProperty("shameRuns")]
        public decimal ShameRuns { get; set; }

        [JsonProperty("totalShames")]
        public int TotalShames { get; set; }

        [JsonProperty("totalShamings")]
        public int TotalShamings { get; set; }

        [JsonProperty("seasonShames")]
        public int SeasonShames { get; set; }

        [JsonProperty("seasonShamings")]
        public int SeasonShamings { get; set; }

        [JsonProperty("championships")]
        public int Championships { get; set; }

        [JsonProperty("weekAttr")]
        public List<string> WeekAttr { get; set; }

        [JsonProperty("gameAttr")]
        public List<string> GameAttr { get; set; }

        [JsonProperty("rotationSlot")]
        public int RotationSlot { get; set; }

        [JsonProperty("teamSpirit")]
        public int TeamSpirit { get; set; }

        [JsonProperty("card")]
        public int Card { get; set; }

        [JsonProperty("tournamentWins")]
        public int TournamentWins { get; set; }

        [JsonProperty("stadium")]
        public Guid? StadiumId { get; set; }

        [JsonIgnore]
        public Stadium Stadium { get; set; }

        [JsonProperty("eDensity")]
        public double EDensity { get; set; }

        [JsonProperty("state")]
        public TeamState State { get; set; }

        [JsonProperty("evolution")]
        public int Evolution { get; set; }

        [JsonProperty("winStreak")]
        public int WinStreak { get; set; }

        [JsonProperty("level")]
        public int? Level { get; set; }

        [JsonIgnore]
        public List<Player> Lineup { get; set; }

        [JsonIgnore]
        public List<Player> Rotation { get; set; }

        [JsonIgnore]
        public List<Player> Bench { get; set; }

        [JsonIgnore]
        public List<Player> Bullpen { get; set; }

        [JsonIgnore]
        public IEnumerable<Player> Players => Lineup?.Concat(Rotation).Concat(Bench).Concat(Bullpen);

        [JsonIgnore]
        public TeamElectionStats TeamElectionStats { get; set; }
    }

    public class TeamState
    {
        [JsonProperty("gameModSources")]
        public Dictionary<string, List<string>> GameModSources { get; set; }

        [JsonProperty("permModSources")]
        public Dictionary<string, List<string>> PermModSources { get; set; }
    }
}
