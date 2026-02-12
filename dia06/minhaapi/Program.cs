using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using StackExchange.Redis;
using MinhaApi.Models;
using System.Text.Json;
using MinhaApi.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<LoteService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var configuration = builder.Configuration["Redis:ConnectionString"]
                        ?? "localhost:6379,abortConnect=false";

    var options = ConfigurationOptions.Parse(configuration);
    options.AbortOnConnectFail = false;

    return ConnectionMultiplexer.Connect(options);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var redis = scope.ServiceProvider.GetRequiredService<IConnectionMultiplexer>();
    var dbRedis = redis.GetDatabase();

    if (!dbRedis.KeyExists("mensagem"))
    {
        dbRedis.StringSet("mensagem", "Redis inicializado com sucesso!");
    }

    var loteExemplo = new LoteMinerio
    {
        Id = 1,
        CodigoLote = "L001",
        MinaOrigem = "Mina Central",
        TeorFe = 65.5m,
        Umidade = 2.3m,
        SiO2 = 3.5m,
        P = 0.1m,
        Toneladas = 500,
        DataProducao = DateTime.UtcNow,
        Status = StatusLote.EmProducao,
        LocalizacaoAtual = "Armazém A"
    };

    var loteJson = JsonSerializer.Serialize(loteExemplo);
    dbRedis.StringSet($"lote:{loteExemplo.Id}", loteJson);
}

app.UseAuthorization();

app.MapControllers();

app.MapGet("/redis-test", (IConnectionMultiplexer redis) =>
{
    var dbRedis = redis.GetDatabase();

    if (!dbRedis.KeyExists("teste"))
    {
        dbRedis.StringSet("teste", "Olá Redis do Docker!");
    }

    return dbRedis.StringGet("teste").ToString();
});

app.Run();
