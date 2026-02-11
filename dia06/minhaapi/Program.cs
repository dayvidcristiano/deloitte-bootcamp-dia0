using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using StackExchange.Redis;
using MinhaApi.Models;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
var configuration = builder.Configuration.GetValue<string>("Redis:ConnectionString");
return ConnectionMultiplexer.Connect(configuration);
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
var db = redis.GetDatabase();

if (!db.KeyExists("mensagem"))
{
    db.StringSet("mensagem", "Redis inicializado com sucesso!");
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
db.StringSet($"lote:{loteExemplo.Id}", loteJson);


}

app.UseAuthorization();

app.MapControllers();

app.MapGet("/redis-test", (IConnectionMultiplexer redis) =>
{
var db = redis.GetDatabase();

if (!db.KeyExists("teste"))
{
    db.StringSet("teste", "Olá Redis do Docker!");
}

return db.StringGet("teste").ToString();


});

app.Run();