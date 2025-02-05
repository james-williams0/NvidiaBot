using Microsoft.Azure.Functions.Worker;
using NvidiaBot.Checkers;
using NvidiaBot.Clients;

namespace NvidiaBot.Function;

public class ProductPageCheckerFunction
{
    private readonly IProductPageChecker _productPageChecker;
    private readonly ITwilioClient _twilioClient;

    public ProductPageCheckerFunction(IProductPageChecker productPageChecker, ITwilioClient twilioClient)
    {
        _productPageChecker = productPageChecker;
        _twilioClient = twilioClient;
    }
    
    [Function(nameof(ProductPageChecker))]
    public async Task CheckFeInventory([TimerTrigger("7/21 * 6-23 * * *", RunOnStartup = true)] TimerInfo timerInfo,
        FunctionContext context)
    {
        var checkResult = await _productPageChecker.CheckAsync();
        if (checkResult is not null)
        {
            await _twilioClient.SendMessageAsync(checkResult);
        }
    }
}
