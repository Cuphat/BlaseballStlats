using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlaseballStlats.Models
{
    public class Team
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("lineup")]
        public List<Guid> Lineup { get; set; }

        [JsonPropertyName("rotation")]
        public List<Guid> Rotation { get; set; }

        [JsonPropertyName("bullpen")]
        public List<Guid> Bullpen { get; set; }

        [JsonPropertyName("bench")]
        public List<Guid> Bench { get; set; }

        [JsonPropertyName("seasAttr")]
        public List<string> SeasAttr { get; set; }

        [JsonPropertyName("permAttr")]
        public List<string> PermAttr { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("mainColor")]
        public string MainColor { get; set; }

        [JsonPropertyName("nickname")]
        public string Nickname { get; set; }

        [JsonPropertyName("secondaryColor")]
        public string SecondaryColor { get; set; }

        [JsonPropertyName("shorthand")]
        public string Shorthand { get; set; }

        [JsonPropertyName("emoji")]
        public string Emoji { get; set; }

        [JsonPropertyName("slogan")]
        public string Slogan { get; set; }

        [JsonPropertyName("shameRuns")]
        public decimal ShameRuns { get; set; }

        [JsonPropertyName("totalShames")]
        public int TotalShames { get; set; }

        [JsonPropertyName("totalShamings")]
        public int TotalShamings { get; set; }

        [JsonPropertyName("seasonShames")]
        public int SeasonShames { get; set; }

        [JsonPropertyName("seasonShamings")]
        public int SeasonShamings { get; set; }

        [JsonPropertyName("championships")]
        public int Championships { get; set; }

        [JsonPropertyName("weekAttr")]
        public List<string> WeekAttr { get; set; }

        [JsonPropertyName("gameAttr")]
        public List<string> GameAttr { get; set; }

        [JsonPropertyName("rotationSlot")]
        public int RotationSlot { get; set; }

        [JsonPropertyName("teamSpirit")]
        public int TeamSpirit { get; set; }

        [JsonPropertyName("card")]
        public int Card { get; set; }

        [JsonPropertyName("tournamentWins")]
        public int TournamentWins { get; set; }

        [JsonPropertyName("stadium")]
        public Guid? Stadium { get; set; }

        [JsonPropertyName("eDensity")]
        public double EDensity { get; set; }

        [JsonPropertyName("state")]
        public State State { get; set; }

        [JsonPropertyName("evolution")]
        public int Evolution { get; set; }

        [JsonPropertyName("winStreak")]
        public int WinStreak { get; set; }

        [JsonPropertyName("level")]
        public int? Level { get; set; }
    }
}
