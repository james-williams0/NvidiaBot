using System.Text.Json.Serialization;

namespace NvidiaBot;

public record StoreSearchResponse
{
    [JsonPropertyName("categories")]
    public object? Categories { get; init; }

    [JsonPropertyName("filters")]
    public required Filters[] Filters { get; init; }

    [JsonPropertyName("filterGroups")]
    public object? FilterGroups { get; init; }

    [JsonPropertyName("search")]
    public object? Search { get; init; }

    [JsonPropertyName("version")]
    public required string Version { get; init; }

    [JsonPropertyName("sort")]
    public required Sort[] Sort { get; init; }
    
    [JsonPropertyName("pagination")]
    public required Pagination Pagination { get; init; }
    
    [JsonPropertyName("searchedProducts")]
    public required SearchedProducts SearchedProducts { get; init; }
    
    [JsonPropertyName("disclaimer")]
    public required Disclaimer Disclaimer { get; init; }
}

public record Filters
{
    [JsonPropertyName("displayName")]
    public required string DisplayName { get; init; }
    
    [JsonPropertyName("filterField")]
    public required string FilterField { get; init; }
    
    [JsonPropertyName("displayMaxValues")]
    public required string DisplayMaxValues { get; init; }
    
    [JsonPropertyName("fieldType")]
    public required string FieldType { get; init; }
    
    [JsonPropertyName("selectedMinRangeVal")]
    public object? SelectedMinRangeVal { get; init; }
    
    [JsonPropertyName("selectedMaxRangeVal")]
    public object? SelectedMaxRangeVal { get; init; }
    
    [JsonPropertyName("defaultMinRangeVal")]
    public object? DefaultMinRangeVal { get; init; }
    
    [JsonPropertyName("defaultMaxRangeVal")]
    public object? DefaultMaxRangeVal { get; init; }
    
    [JsonPropertyName("unitsOfMeasure")]
    public object? UnitsOfMeasure { get; init; }
    
    [JsonPropertyName("checked")]
    public required bool Checked { get; init; }
        
    [JsonPropertyName("units")]
    public object? Units { get; init; }
    
    [JsonPropertyName("filterValues")]
    public required FilterValues[] FilterValues { get; init; }
    
    [JsonPropertyName("dataType")]
    public required string DataType { get; init; }
    
    [JsonPropertyName("showCount")]
    public required bool ShowCount { get; init; }
    
    [JsonPropertyName("filterDisplayOrder")]
    public required int FilterDisplayOrder { get; init; }
}

public record FilterValues
{
    [JsonPropertyName("dispValue")]
    public required string DispValue { get; init; }
    
    [JsonPropertyName("dispValueDesription")]
    public object? DispValueDesription { get; init; }
    
    [JsonPropertyName("groupType")]
    public object? GroupType { get; init; }
    
    [JsonPropertyName("units")]
    public required int Units { get; init; }
    
    [JsonPropertyName("checked")]
    public required bool Checked { get; init; }

    [JsonPropertyName("imageURL")]
    public object? ImageUrl { get; init; }
    
    [JsonPropertyName("isValidate")]
    public required bool IsValidate { get; init; }
}

public record Sort
{
    [JsonPropertyName("displayName")]
    public required string DisplayName { get; init; }
    
    [JsonPropertyName("value")]
    public required string Value { get; init; }
    
    [JsonPropertyName("selected")]
    public required bool Selected { get; init; }
}

public record Pagination
{
    [JsonPropertyName("page")]
    public required int Page { get; init; }
    
    [JsonPropertyName("limit")]
    public required int Limit { get; init; }
    
    [JsonPropertyName("totalRecords")]
    public required int TotalRecords { get; init; }
    
    [JsonPropertyName("featuredProductIncludedInCount")]
    public required bool FeaturedProductIncludedInCount { get; init; }
}

public record SearchedProducts
{
    [JsonPropertyName("totalProducts")]
    public required int TotalProducts { get; init; }
    
    [JsonPropertyName("featuredProductIncludedInCount")]
    public required bool FeaturedProductIncludedInCount { get; init; }
    
    [JsonPropertyName("featuredProductsFlag")]
    public required bool FeaturedProductsFlag { get; init; }
    
    [JsonPropertyName("featuredProduct")]
    public object? FeaturedProduct { get; init; }
    
    [JsonPropertyName("productDetails")]
    public required ProductDetails[] ProductDetails { get; init; }
    
    [JsonPropertyName("suggestedProductDetails")]
    public object[] SuggestedProductDetails { get; init; }
}

public record ProductDetails
{
    [JsonPropertyName("displayName")]
    public required string DisplayName { get; init; }
    
    [JsonPropertyName("totalCount")]
    public required int TotalCount { get; init; }
    
    [JsonPropertyName("productID")]
    public required int ProductId { get; init; }
    
    [JsonPropertyName("imageURL")]
    public required string ImageUrl { get; init; }
    
    [JsonPropertyName("productTitle")]
    public required string ProductTitle { get; init; }
    
    [JsonPropertyName("digitialRiverID")]
    public required string DigitialRiverId { get; init; }
    
    [JsonPropertyName("productSKU")]
    public required string ProductSku { get; init; }
    
    [JsonPropertyName("productUPC")]
    public required string ProductUpc { get; init; }
    
    [JsonPropertyName("productUPCOriginal")]
    public required string ProductUpcOriginal { get; init; }
    
    [JsonPropertyName("productPrice")]
    public required string ProductPrice { get; init; }
    
    [JsonPropertyName("mrp")]
    public required string Mrp { get; init; }
    
    [JsonPropertyName("productAvailable")]
    public required bool ProductAvailable { get; init; }
    
    [JsonPropertyName("productRating")]
    public object? ProductRating { get; init; }
    
    [JsonPropertyName("customerReviewCount")]
    public object? CustomerReviewCount { get; init; }
    
    [JsonPropertyName("isFounderEdition")]
    public required bool IsFounderEdition { get; init; }
    
    [JsonPropertyName("isFeaturedProduct")]
    public required bool IsFeaturedProduct { get; init; }
    
    [JsonPropertyName("certified")]
    public required bool Certified { get; init; }
    
    [JsonPropertyName("bcPID")]
    public required int BcPid { get; init; }
    
    [JsonPropertyName("manufacturer")]
    public required string Manufacturer { get; init; }
    
    [JsonPropertyName("locale")]
    public required string Locale { get; init; }
    
    [JsonPropertyName("bestSeller")]
    public required bool BestSeller { get; init; }
    
    [JsonPropertyName("isFeaturedProdcutFoundInSecondSearch")]
    public required bool IsFeaturedProdcutFoundInSecondSearch { get; init; }
    
    [JsonPropertyName("category")]
    public required string Category { get; init; }
    
    [JsonPropertyName("gpu")]
    public required string Gpu { get; init; }
    
    [JsonPropertyName("purchaseOption")]
    public required string PurchaseOption { get; init; }
    
    [JsonPropertyName("prdStatus")]
    public required string PrdStatus { get; init; }
    
    [JsonPropertyName("minShipDays")]
    public object? MinShipDays { get; init; }
    
    [JsonPropertyName("maxShipDays")]
    public object? MaxShipDays { get; init; }
    
    [JsonPropertyName("shipInfo")]
    public object? ShipInfo { get; init; }
    
    [JsonPropertyName("isOffer")]
    public required bool IsOffer { get; init; }
    
    [JsonPropertyName("offerText")]
    public required string OfferText { get; init; }
    
    [JsonPropertyName("internalLink")]
    public required string InternalLink { get; init; }
    
    [JsonPropertyName("retailers")]
    public required Retailers[] Retailers { get; init; }
    
    [JsonPropertyName("productInfo")]
    public required ProductInfo[] ProductInfo { get; init; }
    
    [JsonPropertyName("compareProductInfo")]
    public required ProductInfo[] CompareProductInfo { get; init; }
}

public record Retailers
{
    [JsonPropertyName("productId")]
    public required int ProductId { get; init; }
    
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
    public required string Upc { get; init; }
    
    [JsonPropertyName("sku")]
    public required string Sku { get; init; }
    
    [JsonPropertyName("stock")]
    public required int Stock { get; init; }
    
    [JsonPropertyName("retailerName")]
    public required string RetailerName { get; init; }
    
    [JsonPropertyName("type")]
    public required int Type { get; init; }
    
    [JsonPropertyName("mrp")]
    public required string Mrp { get; init; }
    
    [JsonPropertyName("bestSeller")]
    public required bool BestSeller { get; init; }
}

public record ProductInfo
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    
    [JsonPropertyName("value")]
    public required string Value { get; init; }
}

public record Disclaimer
{
    [JsonPropertyName("text")]
    public required string Text { get; init; }
}
