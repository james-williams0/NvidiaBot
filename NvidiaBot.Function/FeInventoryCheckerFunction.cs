using Microsoft.Azure.Functions.Worker;
using NvidiaBot.Checkers;
using NvidiaBot.Clients;

namespace NvidiaBot.Function;

public class FeInventoryCheckerFunction
{
    private readonly IFeInventoryChecker _feInventoryChecker;
    private readonly ITwilioClient _twilioClient;

    public FeInventoryCheckerFunction(
        IFeInventoryChecker feInventoryChecker,
        ITwilioClient twilioClient)
    {
        _feInventoryChecker = feInventoryChecker;
        _twilioClient = twilioClient;
    }
    
    [Function(nameof(FeInventoryChecker))]
    public async Task CheckFeInventory([TimerTrigger("0/21 * 6-23 * * *", RunOnStartup = true)] TimerInfo timerInfo,
        FunctionContext context)
    { 
        var checkResult = await _feInventoryChecker.CheckAsync();
        if (checkResult is not null)
        {
            await _twilioClient.SendMessageAsync(checkResult);
        }
    }
}
