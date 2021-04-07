using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlaseballStlats.Models
{
    public class Player : IChroniclerApiData
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("lastUpdate")]
        public DateTimeOffset LastUpdate { get; set; }

        [JsonProperty("anticapitalism")]
        public double Anticapitalism { get; set; }

        [JsonProperty("baseThirst")]
        public double BaseThirst { get; set; }

        [JsonProperty("buoyancy")]
        public double Buoyancy { get; set; }

        [JsonProperty("chasiness")]
        public double Chasiness { get; set; }

        [JsonProperty("coldness")]
        public double Coldness { get; set; }

        [JsonProperty("continuation")]
        public double Continuation { get; set; }

        [JsonProperty("divinity")]
        public double Divinity { get; set; }

        [JsonProperty("groundFriction")]
        public double GroundFriction { get; set; }

        [JsonProperty("indulgence")]
        public double Indulgence { get; set; }

        [JsonProperty("laserlikeness")]
        public double Laserlikeness { get; set; }

        [JsonProperty("martyrdom")]
        public double Martyrdom { get; set; }

        [JsonProperty("moxie")]
        public double Moxie { get; set; }

        [JsonProperty("musclitude")]
        public double Musclitude { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("omniscience")]
        public double Omniscience { get; set; }

        [JsonProperty("overpowerment")]
        public double Overpowerment { get; set; }

        [JsonProperty("patheticism")]
        public double Patheticism { get; set; }

        [JsonProperty("ruthlessness")]
        public double Ruthlessness { get; set; }

        [JsonProperty("shakespearianism")]
        public double Shakespearianism { get; set; }

        [JsonProperty("suppression")]
        public double Suppression { get; set; }

        [JsonProperty("tenaciousness")]
        public double Tenaciousness { get; set; }

        [JsonProperty("thwackability")]
        public double Thwackability { get; set; }

        [JsonProperty("tragicness")]
        public double Tragicness { get; set; }

        [JsonProperty("unthwackability")]
        public double Unthwackability { get; set; }

        [JsonProperty("watchfulness")]
        public double Watchfulness { get; set; }

        [JsonProperty("pressurization")]
        public double Pressurization { get; set; }

        [JsonProperty("totalFingers")]
        public int TotalFingers { get; set; }

        [JsonProperty("soul")]
        public int Soul { get; set; }

        [JsonProperty("deceased")]
        public bool Deceased { get; set; }

        [JsonProperty("peanutAllergy")]
        public bool? PeanutAllergy { get; set; }

        [JsonProperty("cinnamon")]
        public double Cinnamon { get; set; }

        [JsonProperty("fate")]
        public int Fate { get; set; }

        [JsonProperty("ritual")]
        public string Ritual { get; set; }

        [JsonProperty("coffee")]
        public int? Coffee { get; set; }

        [JsonProperty("blood")]
        public int? Blood { get; set; }

        [JsonProperty("permAttr")]
        public List<string> PermAttr { get; set; }

        [JsonProperty("seasAttr")]
        public List<string> SeasAttr { get; set; }

        [JsonProperty("weekAttr")]
        public List<string> WeekAttr { get; set; }

        [JsonProperty("gameAttr")]
        public List<string> GameAttr { get; set; }

        [JsonProperty("hitStreak")]
        public int HitStreak { get; set; }

        [JsonProperty("consecutiveHits")]
        public int ConsecutiveHits { get; set; }

        [JsonProperty("baserunningRating")]
        public double BaserunningRating { get; set; }

        [JsonProperty("pitchingRating")]
        public double PitchingRating { get; set; }

        [JsonProperty("hittingRating")]
        public double HittingRating { get; set; }

        [JsonProperty("defenseRating")]
        public double DefenseRating { get; set; }

        [JsonProperty("leagueTeamId")]
        public Guid? LeagueTeamId { get; set; }

        [JsonIgnore]
        public Team LeagueTeam { get; set; }

        [JsonProperty("tournamentTeamId")]
        public Guid? TournamentTeamId { get; set; }

        [JsonIgnore]
        public Team TournamentTeam { get; set; }

        [JsonProperty("eDensity")]
        public double EDensity { get; set; }

        [JsonProperty("state")]
        public PlayerState State { get; set; }

        [JsonProperty("evolution")]
        public int Evolution { get; set; }

        [JsonProperty("items")]
        public List<object> Items { get; set; }
    }

    public class PlayerState
    {
        [JsonProperty("gameModSources")]
        public Dictionary<string, List<string>> GameModSources { get; set; }

        [JsonProperty("permModSources")]
        public Dictionary<string, List<string>> PermModSources { get; set; }

        [JsonProperty("unscatteredName")]
        public string UnscatteredName { get; set; }
    }
}
