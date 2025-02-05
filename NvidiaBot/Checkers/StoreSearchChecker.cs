using Microsoft.Extensions.Options;
using NvidiaBot.Clients;

namespace NvidiaBot.Checkers;

public interface IStoreSearchChecker : IChecker;

public class StoreSearchChecker : IStoreSearchChecker
{
    private readonly IStoreSearchClient _storeSearchClient;
    private readonly StoreSearchOptions _storeSearchOptions;

    public StoreSearchChecker(IStoreSearchClient storeSearchClient, IOptions<ConfigurationOptions> options)
    {
        _storeSearchClient = storeSearchClient;
        _storeSearchOptions = options.Value.Nvidia.First().StoreSearch;
    }
    
    public async Task<string?> CheckAsync()
    {
        var storeSearchResponse = await _storeSearchClient.GetStoreSearchAsync(locale: _storeSearchOptions.Locale, gpu_filter: _storeSearchOptions.GpuFilter);
        var fiftyNinety = storeSearchResponse.SearchedProducts.ProductDetails.First();
        var storeSearchIndicatesStock =
            fiftyNinety.ProductAvailable ||
            fiftyNinety.Retailers.Any(retailer =>
                retailer.Stock > 0  || (!retailer.PurchaseLink.Contains("store.nvidia.com") &&
                                        !retailer.PurchaseLink.Contains("marketplace.nvidia.com"))) ||
            fiftyNinety.PrdStatus != "out_of_stock";
        if (!storeSearchIndicatesStock)
        {
            return null;
        }
        
        var purchaseLink = fiftyNinety
            .Retailers
            .FirstOrDefault(retailer => 
                (!retailer.PurchaseLink.Contains("store.nvidia.com") && 
                 !retailer.PurchaseLink.Contains("marketplace.nvidia.com")))?
            .PurchaseLink ?? fiftyNinety.Retailers.First().PurchaseLink;
        return purchaseLink;
    }
}
