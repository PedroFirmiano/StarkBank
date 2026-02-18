namespace StarkBankTest.Api.Services.Interfaces
{
    public interface IPublicKeyValidator
    {
        Task<bool> ValidateAsync(string expectedPublicKey);
    }
}
