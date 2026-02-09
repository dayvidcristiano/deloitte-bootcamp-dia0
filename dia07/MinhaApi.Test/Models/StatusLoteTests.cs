using MinhaApi.Models;
using Xunit;

namespace MinhaApi.Test.Models
{
    public class StatusLoteTests
    {
        [Fact]
        public void StatusLote_Deve_Ter_Valores_Corretos()
        {
            Assert.Equal(0, (int)StatusLote.EmProducao);
            Assert.Equal(1, (int)StatusLote.EmTransporte);
            Assert.Equal(2, (int)StatusLote.Entregue);
        }

        [Fact]
        public void Deve_Converter_Int_Para_StatusLote()
        {
            var status = (StatusLote)1;

            Assert.Equal(StatusLote.EmTransporte, status);
        }

        [Fact]
        public void Deve_Converter_StatusLote_Para_Int()
        {
            var status = StatusLote.Entregue;

            Assert.Equal(2, (int)status);
        }
    }
}