using System.Text.Json.Serialization;

public class FeatureCollection
{
    [JsonPropertyName("features")]
    public List<Feature> Features { get; set; } = new();
}

public class Feature
{
    [JsonPropertyName("properties")]
    public FeatureProperties Properties { get; set; } = new();
}

public class FeatureProperties
{
    [JsonPropertyName("place")]
    public string Place { get; set; } = "";

    [JsonPropertyName("mag")]
    public decimal? Mag { get; set; }
}