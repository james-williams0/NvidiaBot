using Microsoft.Extensions.Options;
using NvidiaBot.Checkers;
using NvidiaBot.Clients;

namespace NvidiaBot;

public interface ICheckerRunner
{
    Task RunAllAsync();
}

public class CheckerRunner : ICheckerRunner
{
    private readonly List<IChecker> _checkers;

    // You could also accept an IEnumerable<NvidiaOptions> here and 
    // an AbstractCheckerFactory, for example.
    public CheckerRunner(
        IOptions<ConfigurationOptions> options,
        Func<NvidiaOptions, IFeInventoryChecker> feInventoryCheckerFactory,
        Func<NvidiaOptions, IProductPageChecker> productPageCheckerFactory,
        Func<NvidiaOptions, IStoreSearchChecker> storeSearchCheckerFactory)
    {
        _checkers = new List<IChecker>();
        foreach (var nvidiaCfg in options.Value.Nvidia)
        {
            if (nvidiaCfg.ProductPage is not null)
            {
                _checkers.Add(productPageCheckerFactory(nvidiaCfg.ProductPage));
            }
            
            if (nvidiaCfg.FeInventory is not null)
            {
                _checkers.Add(feInventoryCheckerFactory(nvidiaCfg.FeInventory));
            }
            
            if (nvidiaCfg.StoreSearch is not null)
            {
                _checkers.Add(storeSearchCheckerFactory(nvidiaCfg.StoreSearch));
            }
        }
    }

    public async Task RunAllAsync()
    {
        foreach (var checker in _checkers)
        {
            var purchaseLink = await checker.CheckAsync();
            // do something with the purchaseLink or null
        }
    }
}