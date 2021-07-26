using System.Text.Json.Serialization;

namespace PokemonExcercise.Models
{
    public class PokemonSpeciesResult
    {
        public string Name { get; set; }

        [JsonPropertyName("is_legendary")]
        public bool IsLegendary { get; set; }

        public string Habitat { get; set; }
    }
}
