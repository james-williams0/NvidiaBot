using System.Text.Json.Serialization;

namespace NvidiaBot.Responses;

public record FeInventoryResponse
{
    [JsonPropertyName("success")] 
    public required bool Success { get; init; }

    [JsonPropertyName("map")]
    public object? Map { get; init; }

    [JsonPropertyName("listMap")]
    public required List<Map> ListMap { get; init; }
}

public record Map
{
    [JsonPropertyName("is_active")]
    public required string IsActive { get; init; }
    
    [JsonPropertyName("product_url")]
    public required string ProductUrl { get; init; }
    
    [JsonPropertyName("price")]
    public required string Price { get; init; }
    
    [JsonPropertyName("fe_sku")]
    public required string FeSku { get; init; }
    
    [JsonPropertyName("locale")]
    public required string Locale { get; init; }
}
