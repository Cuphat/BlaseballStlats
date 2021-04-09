using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlaseballStlats.Models
{
    public class Player : IBlaseballData
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("validFrom")]
        public DateTimeOffset ValidFrom { get; set; }

        [JsonProperty("validTo")]
        public DateTimeOffset? ValidTo { get; set; }

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

        [JsonIgnore]
        public double CombinedStars
            => BattingStars + PitchingStars + BaserunningStars + DefenseStars;

        [JsonIgnore]
        public double BattingStars 
            => Math.Pow(1 - Tragicness, 0.01)
               * Math.Pow(Buoyancy, 0)
               * Math.Pow(Thwackability, 0.35)
               * Math.Pow(Moxie, 0.075)
               * Math.Pow(Divinity, 0.35)
               * Math.Pow(Musclitude, 0.075)
               * Math.Pow(1 - Patheticism, 0.05)
               * Math.Pow(Martyrdom, 0.02)
               * 5;

        [JsonIgnore]
        public double PitchingStars
            => Math.Pow(Shakespearianism, 0.1)
               * Math.Pow(Suppression, 0)
               * Math.Pow(Unthwackability, 0.5)
               * Math.Pow(Coldness, 0.025)
               * Math.Pow(Overpowerment, 0.15)
               * Math.Pow(Ruthlessness, 0.4)
               * 5;

        [JsonIgnore]
        public double BaserunningStars
            => Math.Pow(Laserlikeness, 0.5)
               * Math.Pow(Continuation, 0.1)
               * Math.Pow(BaseThirst, 0.1)
               * Math.Pow(Indulgence, 0.1)
               * Math.Pow(GroundFriction, 0.1)
               * 5;

        [JsonIgnore]
        public double DefenseStars
            => Math.Pow(Omniscience, 0.2)
               * Math.Pow(Tenaciousness, 0.2)
               * Math.Pow(Watchfulness, 0.1)
               * Math.Pow(Anticapitalism, 0.1)
               * Math.Pow(Chasiness, 0.1)
               * 5;

        [JsonIgnore]
        public string SoulScream {
            get
            {
                var scream = "";
                var chars = new[] { 'A', 'E', 'I', 'O', 'U', 'X', 'H', 'A', 'E', 'I' };
                var soulStats = new[] { Pressurization, Divinity, Tragicness, Shakespearianism, Ruthlessness };

                for (var digitPosition = 0; digitPosition < Math.Min(Soul, 300); digitPosition++)
                {
                    for (var statIndex = 0; statIndex < 11; statIndex++)
                    {
                        var digitMask = 1 / Math.Pow(10, digitPosition);
                        var statDigit = soulStats[statIndex % soulStats.Length] % digitMask;
                        var digitValue = (int) Math.Floor((statDigit / digitMask) * 10);
                        scream += chars[digitValue];
                    }
                }

                if (Soul > 300)
                    scream += $"... (CONT. FOR {Soul - 300} SOUL)";

                return scream;
            }
        }
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
