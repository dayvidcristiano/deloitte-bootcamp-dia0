using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using MinhaApi.Controllers;
using MinhaApi.Data;
using MinhaApi.Dtos;

namespace MinhaApi.Test.Controllers
{
    public class LotesMinerioControllerTests
    {
        private AppDbContext CriarContextoInMemory()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task Create_DeveRetornarBadRequest_QuandoCodigoLoteVazio()
        {
            var context = CriarContextoInMemory();
            var controller = new LotesMinerioController(context);

            var dto = new CreateLoteMinerioDto
            {
                CodigoLote = "",
                MinaOrigem = "Mina A",
                LocalizacaoAtual = "Pátio",
                TeorFe = 60,
                Umidade = 5,
                Toneladas = 100,
                Status = 0
            };

            var result = await controller.Create(dto);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("CodigoLote é obrigatório.", badRequest.Value);
        }

        [Fact]
        public async Task Create_DeveRetornarCreated_QuandoDadosValidos()
        {
            var context = CriarContextoInMemory();
            var controller = new LotesMinerioController(context);

            var dto = new CreateLoteMinerioDto
            {
                CodigoLote = "LT-001",
                MinaOrigem = "Mina A",
                LocalizacaoAtual = "Pátio",
                TeorFe = 65,
                Umidade = 4,
                Toneladas = 200,
                Status = 1
            };

            var result = await controller.Create(dto);

            var created = Assert.IsType<CreatedAtActionResult>(result);
            Assert.NotNull(created.Value);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFound_QuandoNaoExiste()
        {
            var context = CriarContextoInMemory();
            var controller = new LotesMinerioController(context);

            var result = await controller.GetById(999);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetById_DeveRetornarOk_QuandoExiste()
        {
            var context = CriarContextoInMemory();

            context.LotesMinerio.Add(new MinhaApi.Models.LoteMinerio
            {
                CodigoLote = "LT-002",
                MinaOrigem = "Mina B",
                LocalizacaoAtual = "Porto",
                TeorFe = 62,
                Umidade = 6,
                Toneladas = 150,
                Status = MinhaApi.Models.StatusLote.EmTransporte
            });

            await context.SaveChangesAsync();

            var controller = new LotesMinerioController(context);

            var result = await controller.GetById(1);

            var ok = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(ok.Value);
        }
    }
}
