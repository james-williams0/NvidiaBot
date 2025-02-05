namespace NvidiaBot.Checkers;

public interface IChecker
{
    Task<string?> CheckAsync();
}
