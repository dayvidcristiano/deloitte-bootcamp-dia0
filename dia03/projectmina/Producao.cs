class Producao
{
    private int id;
    private string codigoMina;
    private DataTime data;
    private decimal volume;
    
    decimal getVolume()
    {
        return this.volume;
    }
    decimal setVolume()
    {
        return this.volume;
    }

    //getters e setters

    public void refinarMinerio(Minerio pMinerio, Refinamento refinamento)
    {
      switch (refinamento)
        {
            case Refinamento.Granularidade:
                return 0;
        }

      return this.quantidadeFinaldeRefinamento(pMinerio);
    }

    private int quantidadeFinaldeRefinamento(Minerio pMinerio)
    {
        return 1;
    }
}
