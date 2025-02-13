using System.Text;
using Microsoft.Extensions.Options;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace NvidiaBot.Clients;

public interface ITwilioClient
{
    Task SendMessageAsync(string purchaseLink);
}

public class TwilioClient : ITwilioClient
{
    private readonly TwilioOptions _twilioOptions;

    public TwilioClient(IOptions<ConfigurationOptions> configuration)
    {
        _twilioOptions = configuration.Value.Twilio;
        Twilio.TwilioClient.Init(
            _twilioOptions.AccountSid,
            _twilioOptions.AuthToken);
    }
    
    public async Task SendMessageAsync(string purchaseLink)
    {
        var body = GetNotificationMessage(purchaseLink);
        
        foreach (var recipient in _twilioOptions.ToPhoneNumbers)
        {
            await MessageResource.CreateAsync(
                body: body,
                from: new PhoneNumber(_twilioOptions.FromPhoneNumber),
                to: new PhoneNumber(recipient));    
        }
    }

    private string GetNotificationMessage(string purchaseLink)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("Hello subscriber,");
        stringBuilder.AppendLine("There might be stock available or coming soon at:");
        stringBuilder.AppendLine(purchaseLink);
        return stringBuilder.ToString();
    }
}
