using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlaseballStlats.Models
{
    public class Stadium : IChroniclerApiData
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("lastUpdate")]
        public DateTimeOffset LastUpdate { get; set; }

        [JsonProperty("hype")]
        public int Hype { get; set; }

        [JsonProperty("mods")]
        public List<string> Mods { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("birds")]
        public int Birds { get; set; }

        [JsonProperty("model")]
        public int Model { get; set; }

        [JsonProperty("state")]
        public StadiumState State { get; set; }

        [JsonProperty("teamId")]
        public string TeamId { get; set; }

        [JsonProperty("renoLog")]
        public Dictionary<string, int> RenoLog { get; set; }

        [JsonProperty("weather")]
        public Dictionary<string, int> Weather { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("renoCost")]
        public int RenoCost { get; set; }

        [JsonProperty("renoHand")]
        public List<string> RenoHand { get; set; }

        [JsonProperty("mainColor")]
        public string MainColor { get; set; }

        [JsonProperty("mysticism")]
        public double Mysticism { get; set; }

        [JsonProperty("viscosity")]
        public double Viscosity { get; set; }

        [JsonProperty("elongation")]
        public double Elongation { get; set; }

        [JsonProperty("filthiness")]
        public double Filthiness { get; set; }

        [JsonProperty("obtuseness")]
        public double Obtuseness { get; set; }

        [JsonProperty("forwardness")]
        public double Forwardness { get; set; }

        [JsonProperty("grandiosity")]
        public double Grandiosity { get; set; }

        [JsonProperty("ominousness")]
        public double Ominousness { get; set; }

        [JsonProperty("renoDiscard")]
        public List<string> RenoDiscard { get; set; }

        [JsonProperty("fortification")]
        public double Fortification { get; set; }

        [JsonProperty("inconvenience")]
        public double Inconvenience { get; set; }

        [JsonProperty("luxuriousness")]
        public int Luxuriousness { get; set; }

        [JsonProperty("tertiaryColor")]
        public string TertiaryColor { get; set; }

        [JsonProperty("secondaryColor")]
        public string SecondaryColor { get; set; }
    }

    public class StadiumState
    {
        [JsonProperty("solarPanels")]
        public bool? SolarPanels { get; set; }
    }
}
