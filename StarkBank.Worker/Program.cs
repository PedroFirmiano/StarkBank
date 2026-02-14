using Microsoft.Extensions.Options;
using StarkBank;
using StarkBankTest.Api.Configs;
using StarkBankTest.Worker;

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

    var privateKey = Environment
    .GetEnvironmentVariable("STARKBANK_PRIVATE_KEY")
    ?.Replace("-----BEGIN EC PRIVATE KEY-----", "-----BEGIN EC PRIVATE KEY-----\n")
    .Replace("-----END EC PRIVATE KEY-----", "\n-----END EC PRIVATE KEY-----");

    Project user = new Project(
        environment: options.Enviroment,
        id: options.ProjectId,
        privateKey: privateKey
    );

    Settings.User = user;
}

host.Run();
