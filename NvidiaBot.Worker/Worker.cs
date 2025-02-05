using Microsoft.Extensions.Hosting;
using NvidiaBot.Checkers;
using NvidiaBot.Clients;
using Task = System.Threading.Tasks.Task;

namespace NvidiaBot.Worker;

public class Worker : BackgroundService
{
    private readonly IEnumerable<IChecker> _checkers;
    private readonly ITwilioClient _twilioClient;
    private readonly Random _random; 

    public Worker(
        IEnumerable<IChecker> checkers,
        ITwilioClient twilioClient)
    {
        _checkers = checkers;
        _twilioClient = twilioClient;
        _random = new Random(DateTime.Now.Nanosecond);
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            foreach (var checker in _checkers)
            {
                var checkResult = await checker.CheckAsync();
                if (checkResult is not null)
                {
                    await _twilioClient.SendMessageAsync(checkResult);
                }
                
                await DelayRandomTime(_random, 7, 8, stoppingToken);
            }
        }
    }
    
    private static double GetRandomNumberInRange(Random random, double minNumber, double maxNumber)
    {
        return random.NextDouble() * (maxNumber - minNumber) + minNumber;
    }
    
    private static Task DelayRandomTime(Random random, double minSeconds, double maxSeconds, CancellationToken stoppingToken)
    {
        return Task.Delay(TimeSpan.FromSeconds(GetRandomNumberInRange(random, minSeconds, maxSeconds)), stoppingToken);
    }
}
