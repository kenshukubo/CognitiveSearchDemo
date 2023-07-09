using System.Text.Json.Serialization;

namespace CognitiveSearchDemo.Model
{
    public class SearchValueModel
    {
        [JsonPropertyName("@search.score")]
        public float Score { get; set; }

        [JsonPropertyName("content")]
        public string? Content { get; set; }

        [JsonPropertyName("metadata_storage_name")]
        public string? FileName { get; set; }
    }
}
