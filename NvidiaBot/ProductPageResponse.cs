using System.Text.Json.Serialization;

namespace NvidiaBot;

public record ProductPageResponse
{
    [JsonPropertyName("productTitle")]
    public required string ProductTitle { get; init; }
    
    [JsonPropertyName("logoUrl")]
    public object? LogoUrl { get; init; }
    
    [JsonPropertyName("isAvailable")]
    public required bool IsAvailable { get; init; }
    
    [JsonPropertyName("salePrice")]
    public required string SalePrice { get; init; }
    
    [JsonPropertyName("directPurchaseLink")]
    public required string DirectPurchaseLink { get; init; }
    
    [JsonPropertyName("purchaseLink")]
    public required string PurchaseLink { get; init; }
    
    [JsonPropertyName("hasOffer")]
    public required bool HasOffer { get; init; }
    
    [JsonPropertyName("offerText")]
    public object? OfferText { get; init; }
    
    [JsonPropertyName("partnerId")]
    public required string PartnerId { get; init; }
    
    [JsonPropertyName("storeId")]
    public required string StoreId { get; init; }
    
    [JsonPropertyName("upc")]
    public object? Upc { get; init; }
    
    [JsonPropertyName("sku")]
    public object? Sku { get; init; }
    
    [JsonPropertyName("stock")]
    public required int Stock { get; init; }
    
    [JsonPropertyName("retailerName")]
    public required string RetailerName { get; init; }
    
    [JsonPropertyName("type")]
    public required int Type { get; init; }
}
