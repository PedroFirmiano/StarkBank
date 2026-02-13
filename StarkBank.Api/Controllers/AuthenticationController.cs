using EllipticCurve;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StarkBank;
using StarkBankTest.Api.Configs;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Cryptography;

namespace StarkBankTest.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly StarkBankOptions _options;
    public AuthenticationController(IOptions<StarkBankOptions> options)
    {
        _options = options.Value;
    }

    //[HttpPost(Name = "GeneratePairKey")]
    //public object GeneratePairKey()
    //{
    //    (string privateKey, string publicKey) = Key.Create("sample/destination/path");

    //    var keys = new { PrivateKey = privateKey, PublicKey = publicKey };

    //    return keys;
    //}

    [HttpGet(Name = "get")]
    public async Task GetVal() {
        try{

            StarkBank.Invoice invoice = StarkBank.Invoice.Get("5673312441073664");

            Console.WriteLine(invoice);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        



    }



    [HttpPost(Name = "Authentication")]
    public void Authentication()
    {

            var invoices = StarkBank.Invoice.Create(
                new List<StarkBank.Invoice>
                {
                new StarkBank.Invoice(
                    amount: 1000,
                    name: "Tony Stark",
                    taxID: "01234567890"
                )
                }
            );

            foreach (var invoice in invoices)
            {
                Console.WriteLine(invoice.ID);
            }
        

    }


}
