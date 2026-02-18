using Microsoft.Extensions.Options;
using StarkBank;
using StarkBankTest.Api.Client;
using StarkBankTest.Api.Client.Interface;
using StarkBankTest.Api.Configs;
using StarkBankTest.Api.Services;
using StarkBankTest.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<StarkBankOptions>(
    builder.Configuration.GetSection("StarkBankClient"));

builder.Services.Configure<WebhookOptions>(
    builder.Configuration.GetSection("StarkBankClient"));

builder.Services.AddScoped<ITransferService, TransferService>();

builder.Services.AddHttpClient<IStarkBankClient, StarkBankClient>((sp, client) =>
{
    var options = sp
        .GetRequiredService<IOptions<StarkBankOptions>>()
        .Value;

    client.BaseAddress = new Uri(options.BaseUrl);
});

builder.Services.AddScoped<IPublicKeyValidator, PublicKeyValidator>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
