using System.Text.Json;
using Microsoft.Extensions.Hosting;

namespace NvidiaBot;

public class Worker : BackgroundService
{
    private readonly IFeInventoryClient _feInventoryClient;
    private readonly IStoreSearchClient _storeSearchClient;

    public Worker(IFeInventoryClient feInventoryClient, IStoreSearchClient storeSearchClient)
    {
        _feInventoryClient = feInventoryClient;
        _storeSearchClient = storeSearchClient;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var storeSearchResponse = await _storeSearchClient.GetStoreSearchAsync();
            var fiftyNintety = storeSearchResponse.SearchedProducts.ProductDetails.First();
            var storeSearchIndicatesStock =
                fiftyNintety.ProductAvailable ||
                fiftyNintety.Retailers.Any(retailer => retailer.Stock > 0) ||
                fiftyNintety.PrdStatus != "out_of_stock";
            
            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            
            // var feInventoryResponse = await _feInventoryClient.GetFeInventoryAsync();
            // var feInventoryIndicatesStock =
            //     feInventoryResponse.ListMap.Any(x =>
            //         x.IsActive != "false" || !string.IsNullOrWhiteSpace(x.ProductUrl)) ||
            //     feInventoryResponse.Map is not null;
            //
            // await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);

            var productPageStringResponse = await _storeSearchClient.GetProductPageAsync();
            productPageStringResponse = productPageStringResponse.Replace("\\", string.Empty);
            var productPageResponse = JsonSerializer.Deserialize<List<ProductPageResponse>>(productPageStringResponse[1..^1]);
            var productPageIndicatesStock = productPageResponse.Any(product => product.Stock > 0) || productPageResponse.Any(product => !product.PurchaseLink.Contains("store.nvidia.com") && !product.PurchaseLink.Contains("marketplace.nvidia.com"));
            
            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);

            if (storeSearchIndicatesStock || /* feInventoryIndicatesStock ||*/ productPageIndicatesStock)
            {
                Console.WriteLine("There might be stock available or coming soon");
            }
            else
            {
                Console.WriteLine("There is no stock");
            }

            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }
    }
}
