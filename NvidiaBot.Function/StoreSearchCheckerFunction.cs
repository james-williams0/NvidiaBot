using Microsoft.Azure.Functions.Worker;
using NvidiaBot.Checkers;
using NvidiaBot.Clients;

namespace NvidiaBot.Function;

public class StoreSearchCheckerFunction
{
    private readonly IStoreSearchChecker _storeSearchChecker;
    private readonly ITwilioClient _twilioClient;

    public StoreSearchCheckerFunction(IStoreSearchChecker storeSearchChecker, ITwilioClient twilioClient)
    {
        _storeSearchChecker = storeSearchChecker;
        _twilioClient = twilioClient;
    }
    
    [Function(nameof(StoreSearchChecker))]
    public async Task CheckFeInventory([TimerTrigger("7/21 * 6-23 * * *", RunOnStartup = true)] TimerInfo timerInfo,
        FunctionContext context)
    { 
        var checkResult = await _storeSearchChecker.CheckAsync();
        if (checkResult is not null)
        {
            await _twilioClient.SendMessageAsync(checkResult);
        }
    }
}
