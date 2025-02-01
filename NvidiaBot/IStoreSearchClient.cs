using Refit;

namespace NvidiaBot;

public interface IStoreSearchClient
{
    [Get("/edge/product/search")]
    Task<StoreSearchResponse> GetStoreSearchAsync(
        string locale = "en-gb",
        int page = 1,
        int limit = 12,
        string gpu = "RTX 5090",
        // ReSharper disable once InconsistentNaming
        string gpu_filter = "RTX 5090~1,RTX 5080~14,RTX 4090~3,RTX 4080 SUPER~18,RTX 4070 Ti SUPER~13,RTX 4070 Ti~3,RTX 4060 Ti~14,RTX 4070 SUPER~20,RTX 4070~10,RTX 4060~14,RTX 3060~5,RTX 3050~10",
        string category = "GPU");

    [Get("/products/v1/buy-now")]
    Task<string> GetProductPageAsync(string sku = "1145381", string locale = "gb");
}
