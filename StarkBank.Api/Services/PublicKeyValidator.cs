using StarkBankTest.Api.Client.Interface;
using StarkBankTest.Api.Services.Interfaces;

namespace StarkBankTest.Api.Services
{
    public class PublicKeyValidator : IPublicKeyValidator
    {
        private readonly IStarkBankClient _client;

        public PublicKeyValidator(IStarkBankClient client)
        {
            _client = client;
        }

        public async Task<bool> ValidateAsync(string expectedPublicKey)
        {
            var starkPublicKey = await _client.GetPublicKeyAsync();

            return starkPublicKey.PublicKeys.Any(p => Normalize(p.content) == expectedPublicKey);
        }

        private string Normalize(string key)
        {
            return key?
                .Replace("\r", "")
                .Replace("\n", "")
                .Trim();
        }
    }
}
