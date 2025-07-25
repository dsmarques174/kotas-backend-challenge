using System.Text.Json.Serialization;

namespace PokemonChallenge.DTOs
{
    public class PokemonDto
    {
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        public int BaseExperience { get; set; }
        public int Height { get; set; }
        public bool Default { get; set; }
        public int Order { get; set; }
        public int Weight { get; set; }
    }
}
