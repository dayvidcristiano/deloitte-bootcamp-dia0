using MinhaApi.Models;
using Xunit;

namespace MinhaApi.Test.Models
{
    public class LoteMinerioModelTests
    {
        [Fact]
        public void Deve_Criar_LoteMinerio_Com_Dados_Validos()
        {
            var lote = new LoteMinerio
            {
                CodigoLote = "L001",
                MinaOrigem = "Mina Central",
                TeorFe = 65,
                Umidade = 12,
                SiO2 = 2.5m,
                P = 0.04m,
                Toneladas = 1000,
                Status = StatusLote.EmProducao,
                LocalizacaoAtual = "Pátio A"
            };

            Assert.Equal("L001", lote.CodigoLote);
            Assert.Equal("Mina Central", lote.MinaOrigem);
            Assert.Equal(65, lote.TeorFe);
            Assert.Equal(12, lote.Umidade);
            Assert.Equal(2.5m, lote.SiO2);
            Assert.Equal(0.04m, lote.P);
            Assert.Equal(1000, lote.Toneladas);
            Assert.Equal(StatusLote.EmProducao, lote.Status);
            Assert.Equal("Pátio A", lote.LocalizacaoAtual);
        }

        [Fact]
        public void Deve_Permitir_DataProducao_Preenchida()
        {
            var data = new DateTime(2025, 1, 1);

            var lote = new LoteMinerio
            {
                DataProducao = data
            };

            Assert.Equal(data, lote.DataProducao);
        }

        [Fact]
        public void Status_Deve_Ser_Do_Tipo_StatusLote()
        {
            var lote = new LoteMinerio
            {
                Status = StatusLote.Entregue
            };

            Assert.IsType<StatusLote>(lote.Status);
            Assert.Equal(StatusLote.Entregue, lote.Status);
        }
    }
}