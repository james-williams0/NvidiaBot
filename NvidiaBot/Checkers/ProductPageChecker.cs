using System.Text.Json;
using Microsoft.Extensions.Options;
using NvidiaBot.Clients;
using NvidiaBot.Responses;

namespace NvidiaBot.Checkers;

public interface IProductPageChecker : IChecker;

public class ProductPageChecker : IProductPageChecker
{
    private readonly IStoreSearchClient _storeSearchClient;
    private readonly ProductPageOptions _productPageOptions;

    public ProductPageChecker(IStoreSearchClient storeSearchClient, IOptions<ConfigurationOptions> options)
    {
        _storeSearchClient = storeSearchClient;
        _productPageOptions = options.Value.Nvidia.First().ProductPage;
    }
    
    public async Task<string?> CheckAsync()
    {
        var productPageStringResponse = await _storeSearchClient.GetProductPageAsync(_productPageOptions.Sku, _productPageOptions.Locale);
        productPageStringResponse = productPageStringResponse.Replace("\\", string.Empty);
        var productPageResponse = JsonSerializer.Deserialize<List<ProductPageResponse>>(productPageStringResponse[1..^1]);
        if (productPageResponse is null or { Count: 0 })
        {
            return null;
        }
        
        var productPageIndicatesStock = productPageResponse.Any(product =>
            product.Stock > 0 || (!product.PurchaseLink.Contains("store.nvidia.com") &&
                                  !product.PurchaseLink.Contains("marketplace.nvidia.com")));
        if (!productPageIndicatesStock)
        {
            return null;
        }
        
        var purchaseLink = productPageResponse
            .FirstOrDefault(product => 
                (!product.PurchaseLink.Contains("store.nvidia.com") && 
                 !product.PurchaseLink.Contains("marketplace.nvidia.com")))?
            .PurchaseLink ?? productPageResponse.First().PurchaseLink;
        return purchaseLink;
    }
}
