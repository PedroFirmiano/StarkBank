using Microsoft.Extensions.Options;
using StarkBank;
using StarkBankTest.Api.Configs;

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


var app = builder.Build();

using (var scope = app.Services.CreateScope())
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
