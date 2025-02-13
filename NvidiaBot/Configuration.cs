namespace NvidiaBot;

public record ConfigurationOptions
{
    public const string Configuration = "Configuration";
    
    public TwilioOptions Twilio { get; init; } = new();
    
    public List<NvidiaOptions> Nvidia { get; init; } = [];
}

public record NvidiaOptions
{
    public const string Nvidia = "Nvidia";
    
    public StoreSearchOptions StoreSearch { get; init; } = new();
    
    public ProductPageOptions ProductPage { get; init; } = new();
    
    public FeInventoryOptions FeInventory { get; init; } = new();
}

public record StoreSearchOptions
{
    public const string StoreSearch = "StoreSearch";
    
    public string Locale { get; init; } = "en-gb";
    
    public string GpuFilter { get; init; } = "RTX 5090~1,RTX 5080~14,RTX 4090~3,RTX 4080 SUPER~18,RTX 4070 Ti SUPER~13,RTX 4070 Ti~3,RTX 4060 Ti~14,RTX 4070 SUPER~20,RTX 4070~10,RTX 4060~14,RTX 3060~5,RTX 3050~10";
}

public record ProductPageOptions
{
    public const string ProductPage = "ProductPage";

    public string Sku { get; init; } = "1145381";
    
    public string Locale { get; init; } = "gb";
}

public record FeInventoryOptions
{
    public const string FeInventory = "FeInventory";
    
    public string Skus { get; init; } = "NVGFT590";
    
    public string Locale { get; init; } = "en-gb";
}

public record TwilioOptions
{
    public const string Twilio = "Twilio";
    
    public List<string> ToPhoneNumbers { get; init; } = [];
    
    public string FromPhoneNumber { get; init; } = string.Empty;
    
    public string AccountSid { get; init; } = string.Empty;
    
    public string AuthToken { get; init; } = string.Empty;
}
