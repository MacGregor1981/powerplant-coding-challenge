using ProductionPlan.Data.Converter;
using ProductionPlan.Data.Enums;
using System.Text.Json.Serialization;

namespace ProductionPlan.Data
{
    public class PowerPlant
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("efficiency")]
        public double Efficiency { get; set; }

        [JsonPropertyName("pmin")]
        public int PMin { get; set; }
        [JsonPropertyName("pmax")]
        public int PMax { get; set; }

    }
}
