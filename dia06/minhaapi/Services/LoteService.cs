using MinhaApi.Models;
using MinhaApi.Data;

namespace MinhaApi.Services
{
    public class LoteService
    {
        private readonly AppDbContext _context;

        public LoteService(AppDbContext context)
        {
            _context = context;
        }

        public string ClassificarQualidade(int id)
        {
            var lote = _context.LotesMinerio.FirstOrDefault(l => l.Id == id);
            if (lote == null) return "Lote não encontrado";

            if (lote.TeorFe >= 65 && lote.Umidade <= 3 && lote.SiO2 <= 4)
                return "Premium";

            if (lote.TeorFe >= 60)
                return "Padrão";

            return "Baixa";
        }

        public object CalcularPreco(int id)
        {
            var lote = _context.LotesMinerio.FirstOrDefault(l => l.Id == id);
            if (lote == null) return "Lote não encontrado";

            var qualidade = ClassificarQualidade(id);

            decimal precoTonelada = qualidade switch
            {
                "Premium" => 500,
                "Padrão" => 400,
                _ => 300
            };

            var valorTotal = precoTonelada * lote.Toneladas;

            return new
            {
                Qualidade = qualidade,
                PrecoPorTonelada = precoTonelada,
                ValorTotal = valorTotal
            };
        }

        public string RegistrarMovimentacao(int id)
        {
            var lote = _context.LotesMinerio.FirstOrDefault(l => l.Id == id);
            if (lote == null) return "Lote não encontrado";

            lote.LocalizacaoAtual = "Atualizado em " + DateTime.Now;
            _context.SaveChanges();

            return "Movimentação registrada";
        }

        public string AvancarStatus(int id)
        {
            var lote = _context.LotesMinerio.FirstOrDefault(l => l.Id == id);
            if (lote == null) return "Lote não encontrado";

            lote.Status = lote.Status switch
            {
                StatusLote.EmProducao => StatusLote.EmTransporte,
                StatusLote.EmTransporte => StatusLote.Entregue,
                _ => lote.Status
            };

            _context.SaveChanges();
            return "Status atualizado para " + lote.Status;
        }

        public object CalcularPenalidade(int id)
        {
            var lote = _context.LotesMinerio.FirstOrDefault(l => l.Id == id);
            if (lote == null) return "Lote não encontrado";

            decimal excesso = lote.Umidade > 3 ? lote.Umidade - 3 : 0;
            decimal penalidade = excesso * 50 * lote.Toneladas;

            return new
            {
                ExcessoUmidade = excesso,
                PenalidadeFinanceira = penalidade
            };
        }
    }
}
