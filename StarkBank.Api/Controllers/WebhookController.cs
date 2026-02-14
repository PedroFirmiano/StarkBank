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
    private readonly ITransferService _transferService;

    public WebhookController(IOptions<WebhookOptions> options, ITransferService transferService)
    {
        _options = options.Value;
        _transferService = transferService;
    }

    [HttpGet("GetWebhooks")]
    public IEnumerable<StarkBank.Webhook> GetWebhooks()
    {
        IEnumerable<StarkBank.Webhook> webhooks = StarkBank.Webhook.Query();
        return webhooks;


    }

    [HttpPost("CreateWebook")]
    public void CreateWebhook(string webhookUrl)
    {
        Webhook webhook = StarkBank.Webhook.Create(
            url: webhookUrl,
            subscriptions: new List<string> { "invoice", "boleto", "boleto-payment", "utility-payment" }
        );

    }

    [HttpDelete("DeleteWebhook")]
    public void DeleteWebhook(string webhookId)
    {
        StarkBank.Webhook webhook = StarkBank.Webhook.Delete(webhookId);

    }

    [HttpPost("ReceiveEvent")]
    public IActionResult ReceiveEvent([FromBody] StarkWebhookDto starkEvent)
    {
        var transfers = _transferService.CreateTransferFromInvoiceEvent(starkEvent);

        return Ok(transfers);
    }
}
