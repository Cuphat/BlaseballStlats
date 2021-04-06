using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BlaseballStlats.Models
{
    public class State
    {
        [JsonPropertyName("gameModSources")]
        public Dictionary<string, List<string>> GameModSources { get; set; }

        [JsonPropertyName("permModSources")]
        public Dictionary<string, List<string>> PermModSources { get; set; }
    }
}