using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StarkBank;
using StarkBankTest.Api.Configs;

namespace StarkBankTest.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WebhookController : ControllerBase
{
    private readonly WebhookOptions _options;
    public WebhookController(IOptions<WebhookOptions> options)
    {
        _options= options.Value;
    }

    [HttpPost("CreateWebook")]
    public void CreateWebhook(string webhookUrl)
    {
        StarkBank.Webhook webhook = StarkBank.Webhook.Create(
            url: webhookUrl,
            subscriptions: new List<string> { "transfer", "boleto", "boleto-payment", "utility-payment" }
        );

    }

    [HttpPost("ReceiveEvent")]
    public void ReceiveEvent(StarkEvent starkEvent)
    {
        List<StarkBank.Transfer> transfers = StarkBank.Transfer.Create(
            new List<StarkBank.Transfer> {
        new StarkBank.Transfer(
            amount: starkEvent.Log.Transfer.Amount,
            bankCode: "20018183",
            branchCode: "0001",
            accountNumber: "6341320293482496",
            taxID: "20.018.183/0001-80",
            name: "Stark Bank S.A.",
            externalID: "my-external-id"
            
             )
            }
        );

        foreach (StarkBank.Transfer transfer in transfers)
        {
            Console.WriteLine(transfer);
        }
    }
}
