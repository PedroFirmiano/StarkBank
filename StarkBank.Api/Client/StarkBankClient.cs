using StarkBankTest.Api.Client.Interface;
using StarkBankTest.Api.Dto;
using System.Text.Json;

namespace StarkBankTest.Api.Client;

public class StarkBankClient : IStarkBankClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<StarkBankClient> _logger;

    public StarkBankClient(
        HttpClient httpClient,
        ILogger<StarkBankClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<StarkPublicKeyDto> GetPublicKeyAsync()
    {
        var response = await _httpClient.GetAsync("/v2/public-key");

        if (!response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            _logger.LogError("Error getting public key: {content}", content);
            throw new Exception("Error calling StarkBank public key endpoint");
        }

        var json = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<StarkPublicKeyDto>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        return result;
    }
}
