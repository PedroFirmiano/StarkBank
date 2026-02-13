using Microsoft.Extensions.Options;
using StarkBank;
using StarkBankTest.Api.Configs;

namespace StarkBankTest.Domain.Authentication;

public class AuthenticationService
{
    private readonly StarkBankOptions _options;
    public AuthenticationService(IOptions<StarkBankOptions> options)
    {
        _options = options.Value;
    }
    public void GetBearerToken()
    {
        Project user = new Project(
            environment: _options.Enviroment,
            id: _options.ProjectId,
            privateKey: _options.PrivateKey
        );
        Settings.User = user;
    }
}
