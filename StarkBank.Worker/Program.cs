using Microsoft.Extensions.Options;
using StarkBank;
using StarkBankTest.Api.Configs;
using StarkBankTest.Domain.Client;
using StarkBankTest.Domain.Client.Interface;
using StarkBankTest.Worker;
using StarkCore.Utils;
using System.Net.Http.Headers;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.Configure<StarkBankOptions>(
    builder.Configuration.GetSection("StarkBankClient"));



var host = builder.Build();

using (var scope = host.Services.CreateScope())
{
    var options = scope.ServiceProvider
        .GetRequiredService<IOptions<StarkBankOptions>>()
        .Value;

    var privateKey = @" 
-----BEGIN EC PRIVATE KEY-----
MHQCAQEEIOJEQy9YiKsMPCsnDyFsCfAs29rf5D7CGL897YX8pvYpoAcGBSuBBAAK
oUQDQgAE8YhHMGL8soly8DJ5EZ2WBQ0z0Jss6pXwZNYwEhxNbnRkjdTx97E/dD3L
pG8cBinL2T6SnKF8ok0GqGcwQz+tqQ==
-----END EC PRIVATE KEY-----";

    Project user = new Project(
        environment: options.Enviroment,
        id: options.ProjectId,
        privateKey: privateKey
    );

    Settings.User = user;
}

host.Run();
