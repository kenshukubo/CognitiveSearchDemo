using System.Text.Json;
using System.Text.Json.Serialization;

namespace CognitiveSearchDemo.Model
{
    public class SearchModel
    {
        [JsonPropertyName("value")]
        public JsonDocument? Value { get; set; }
    }
}
