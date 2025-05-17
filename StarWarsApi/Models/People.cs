using System.Text.Json.Serialization;

namespace StarWarsApi.Models
{
    public class People
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}
