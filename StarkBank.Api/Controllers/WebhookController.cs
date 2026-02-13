using Microsoft.AspNetCore.Mvc;

namespace StarkBankTest.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WebhookController : ControllerBase
{

    [HttpPost(Name = "Invoice")]
    public void ReceiveInvoice([FromBody] string dto)
    {
        
    }
}
