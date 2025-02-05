using Microsoft.Extensions.Options;
using NvidiaBot.Clients;

namespace NvidiaBot.Checkers;

public interface IFeInventoryChecker : IChecker;

public class FeInventoryChecker : IFeInventoryChecker
{
    private readonly IFeInventoryClient _feInventoryClient;
    private readonly FeInventoryOptions _feInventoryOptions;

    public FeInventoryChecker(IFeInventoryClient feInventoryClient, IOptions<ConfigurationOptions> options)
    {
        _feInventoryClient = feInventoryClient;
        _feInventoryOptions = options.Value.Nvidia.First().FeInventory;
    }
    
    public async Task<string?> CheckAsync()
    {
        var feInventoryResponse = await _feInventoryClient.GetFeInventoryAsync(_feInventoryOptions.Skus, _feInventoryOptions.Locale);
        var feInventoryListMap = feInventoryResponse.ListMap.First();
        if (feInventoryListMap.IsActive == "false" || string.IsNullOrWhiteSpace(feInventoryListMap.ProductUrl))
        {
            return null;
        }
            
        var purchaseLink = feInventoryResponse.ListMap.First().ProductUrl;
        return purchaseLink;
    }
}
