using System.Text.Json.Serialization;

namespace PokemonChallenge.DTOs
{
    public class PokemonDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("base_experience")]
        public int BaseExperience { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("default")]
        public bool Default { get; set; }

        [JsonPropertyName("location_area_encounters")]
        public string LocationAreaEncounters { get; set; }

        [JsonPropertyName("order")]
        public int Order { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("species")]
        public Species Species { get; set; }

        [JsonPropertyName("sprites")]
        public Sprites Sprites { get; set; }

        [JsonPropertyName("cries")]
        public Cries Cries { get; set; }

    }


    public class Species
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Sprites
    {
        [JsonPropertyName("back_default")]
        public string BackDefault { get; set; }

        [JsonPropertyName("back_default_base64")]
        public string BackDefaultBase64 { get; set; }
    }

    public class Cries
    {
        [JsonPropertyName("latest")]
        public string Latest { get; set; }

        [JsonPropertyName("legacy")]
        public string Legacy { get; set; }
    }

}
