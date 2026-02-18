using System.Security.Cryptography.X509Certificates;

namespace StarkBankTest.Api.Dto;

public class StarkPublicKeyDto
{
    public StarkPublicKey[] PublicKeys { get; set; }
}

public class StarkPublicKey
{
    public string content { get; set; }
    public DateTime Created { get; set; }
}