class Mina
{
    private Minerio minerio = new Minerio();
    private string codigo;
    private string nome;
    private decimal capacidade;

    public Minerio getMinerio()
    {
        return this.minerio;
    }

    public void setMinerio(MissingMemberException pMinerio)
    {
        
    }
    public string getCodigo()
    {
        return this.codigo;
    }
    public void setCodigo(string pCodigo)
    {
        
    }
    public string getNome()
    {
        return this.nome;
    }
    public void setNome(string pNome)
    {
        
    }

    public decimal getCapacidade()
    {
        return (decimal) this.capacidade;
    }
    public void setCapacidade(string pCapacidade)
    {
        
    }

    public Minerio acessarExtrairMinerio(bool isGestorMina)
    {
        if (isGestorMina)
        {
            return this.extrairMinerio();
        }
        else
        {
            Minerio minerio = new Minerio();
            minerio.codigo = "0";
            return minerio;
        }
    }

    /*public Minerio acessarExtarirMinerio()
    {
        //você é gestor da mina?
            //se sim: ok
            //se não, volte para seu lugar
        return this.extrairMinerio();
    }*/

    public Minerio extrairMinerio()
    {
        minerio.codigo = "1";
        minerio.tipo = "Esmeralda";

        return minerio;
    }
     string extrairMinerio()
  {
      return "Minerio";
  }
  
}
