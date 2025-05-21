using System.Text.Json.Serialization;

namespace StarWarsApi.Models
{
    public class People
    {
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("height")]
        public string Height { get; set; } = string.Empty;

        [JsonPropertyName("mass")]
        public string Mass { get; set; } = string.Empty;

        [JsonPropertyName("skin_color")]
        public string SkinColour { get; set; } = string.Empty;

        [JsonPropertyName("birth_year")]
        public string BirthYear { get; set; } = string.Empty;

        [JsonPropertyName("gender")]
        public string Gender { get; set; } = string.Empty;

        [JsonPropertyName("likes")]
        public int Likes { get; set; } = 0;

    }
}
