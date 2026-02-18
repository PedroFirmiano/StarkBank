using StarkBankTest.Api.Dto;

namespace StarkBankTest.Api.Client.Interface
{
    public interface IStarkBankClient
    {
        Task<StarkPublicKeyDto> GetPublicKeyAsync();
    }
}
