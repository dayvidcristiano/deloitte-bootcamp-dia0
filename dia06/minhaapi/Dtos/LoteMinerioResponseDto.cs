using MinhaApi.Models;

namespace MinhaApi.Dtos;

public class LoteMinerioResponseDto
{
    public int Id { get; set; }
    public string CodigoLote { get; set; } = null!;
    public string MinaOrigem { get; set; } = null!;
    public decimal TeorFe { get; set; }
    public decimal Umidade { get; set; }
    public decimal? SiO2 { get; set; }
    public decimal? P { get; set; }
    public decimal Toneladas { get; set; }
    public DateTime DataProducao { get; set; }
    public int Status { get; set; }
    public string LocalizacaoAtual { get; set; } = null!;

    public LoteMinerioResponseDto(LoteMinerio lote)
    {
        Id = lote.Id;
        CodigoLote = lote.CodigoLote;
        MinaOrigem = lote.MinaOrigem;
        TeorFe = lote.TeorFe;
        Umidade = lote.Umidade;
        SiO2 = lote.SiO2;
        P = lote.P;
        Toneladas = lote.Toneladas;
        DataProducao = lote.DataProducao;
        Status = (int)lote.Status;
        LocalizacaoAtual = lote.LocalizacaoAtual;
    }

    public LoteMinerioResponseDto() { }
}
