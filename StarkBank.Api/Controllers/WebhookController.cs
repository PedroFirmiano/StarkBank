using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StarkBank;
using StarkBankTest.Api.Configs;
using StarkBankTest.Api.Services.Interfaces;
using System.Text.Json;

namespace StarkBankTest.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WebhookController : ControllerBase
{
    private readonly WebhookOptions _options;
    private readonly ITransferService _transferService;
    private readonly IPublicKeyValidator _validator;

    public WebhookController(IPublicKeyValidator validator, IOptions<WebhookOptions> options, ITransferService transferService)
    {
        _options = options.Value;
        _transferService = transferService;
        _validator = validator;
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
    public async Task<IActionResult> ReceiveEvent(
    [FromBody] StarkWebhookDto eventObject)
    {
        var expected = Request.Headers["Digital-Signature"].FirstOrDefault();

        var valid = await _validator.ValidateAsync(expected);

        if (!valid)
            return Unauthorized();

        var transfers = _transferService.CreateTransferFromInvoiceEvent(eventObject);

        return Ok(transfers);
    }
}