using StarkBankTest.Domain.Client.Interface;
using StarkBankTest.Domain.Request;
using System.Net.Http.Json;

namespace StarkBankTest.Domain.Client;

public class StarkBankClient : IStarkBankClient
{
    private readonly HttpClient _httpClient;

    public StarkBankClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SendInvoice(List<Invoice> invoices)
    {
        var request = new SendInvoiceRequest
        {
            Invoices = invoices
        };
        

        response.EnsureSuccessStatusCode();
    }
}
