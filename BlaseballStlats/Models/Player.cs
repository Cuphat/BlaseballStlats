using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlaseballStlats.Models
{
    public class Player
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("anticapitalism")]
        public double Anticapitalism { get; set; }

        [JsonPropertyName("baseThirst")]
        public double BaseThirst { get; set; }

        [JsonPropertyName("buoyancy")]
        public double Buoyancy { get; set; }

        [JsonPropertyName("chasiness")]
        public double Chasiness { get; set; }

        [JsonPropertyName("coldness")]
        public double Coldness { get; set; }

        [JsonPropertyName("continuation")]
        public double Continuation { get; set; }

        [JsonPropertyName("divinity")]
        public double Divinity { get; set; }

        [JsonPropertyName("groundFriction")]
        public double GroundFriction { get; set; }

        [JsonPropertyName("indulgence")]
        public double Indulgence { get; set; }

        [JsonPropertyName("laserlikeness")]
        public double Laserlikeness { get; set; }

        [JsonPropertyName("martyrdom")]
        public double Martyrdom { get; set; }

        [JsonPropertyName("moxie")]
        public double Moxie { get; set; }

        [JsonPropertyName("musclitude")]
        public double Musclitude { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("omniscience")]
        public double Omniscience { get; set; }

        [JsonPropertyName("overpowerment")]
        public double Overpowerment { get; set; }

        [JsonPropertyName("patheticism")]
        public double Patheticism { get; set; }

        [JsonPropertyName("ruthlessness")]
        public double Ruthlessness { get; set; }

        [JsonPropertyName("shakespearianism")]
        public double Shakespearianism { get; set; }

        [JsonPropertyName("suppression")]
        public double Suppression { get; set; }

        [JsonPropertyName("tenaciousness")]
        public double Tenaciousness { get; set; }

        [JsonPropertyName("thwackability")]
        public double Thwackability { get; set; }

        [JsonPropertyName("tragicness")]
        public double Tragicness { get; set; }

        [JsonPropertyName("unthwackability")]
        public double Unthwackability { get; set; }

        [JsonPropertyName("watchfulness")]
        public double Watchfulness { get; set; }

        [JsonPropertyName("pressurization")]
        public double Pressurization { get; set; }

        [JsonPropertyName("totalFingers")]
        public int TotalFingers { get; set; }

        [JsonPropertyName("soul")]
        public int Soul { get; set; }

        [JsonPropertyName("deceased")]
        public bool Deceased { get; set; }

        [JsonPropertyName("peanutAllergy")]
        public bool PeanutAllergy { get; set; }

        [JsonPropertyName("cinnamon")]
        public double Cinnamon { get; set; }

        [JsonPropertyName("fate")]
        public int Fate { get; set; }

        [JsonPropertyName("ritual")]
        public string Ritual { get; set; }

        [JsonPropertyName("coffee")]
        public int? Coffee { get; set; }

        [JsonPropertyName("blood")]
        public int? Blood { get; set; }

        [JsonPropertyName("permAttr")]
        public List<string> PermAttr { get; set; }

        [JsonPropertyName("seasAttr")]
        public List<string> SeasAttr { get; set; }

        [JsonPropertyName("weekAttr")]
        public List<string> WeekAttr { get; set; }

        [JsonPropertyName("gameAttr")]
        public List<string> GameAttr { get; set; }

        [JsonPropertyName("hitStreak")]
        public int HitStreak { get; set; }

        [JsonPropertyName("consecutiveHits")]
        public int ConsecutiveHits { get; set; }

        [JsonPropertyName("baserunningRating")]
        public double BaserunningRating { get; set; }

        [JsonPropertyName("pitchingRating")]
        public double PitchingRating { get; set; }

        [JsonPropertyName("hittingRating")]
        public double HittingRating { get; set; }

        [JsonPropertyName("defenseRating")]
        public double DefenseRating { get; set; }

        [JsonPropertyName("leagueTeamId")]
        public string LeagueTeamId { get; set; }

        [JsonPropertyName("tournamentTeamId")]
        public string TournamentTeamId { get; set; }

        [JsonPropertyName("eDensity")]
        public double EDensity { get; set; }

        [JsonPropertyName("state")]
        public State State { get; set; }

        [JsonPropertyName("evolution")]
        public int Evolution { get; set; }

        [JsonPropertyName("items")]
        public List<object> Items { get; set; }
    }
}
