using System;
using System.Collections.Generic;
public class Produto
{
    public string NomeProduto { get; set; }
    public double PrecoProduto { get; set; }
    public int QuantidadeProduto { get; set; }
}
public class Estoque
{
    static void Main()
    {
        List<Produto> ListaEstoque = new List<Produto>();

        Console.WriteLine("Informe o nome do produto:");
        string produto = Console.ReadLine();

        Console.WriteLine("Informe o valor do produto:");
        double preco = double.Parse(Console.ReadLine());

        Console.WriteLine("Informe a quantidade do produto:");
        int quantidade = int.Parse(Console.ReadLine());

        if (!string.IsNullOrWhiteSpace(produto) && preco > 0 && quantidade >= 0)
        {
            Produto novo = new Produto();
            novo.NomeProduto = produto;
            novo.PrecoProduto = preco;
            novo.QuantidadeProduto = quantidade;

            ListaEstoque.Add(novo);

            Console.WriteLine("Produto cadastrado.");
        }
        else
        {
            Console.WriteLine("Dados inválidos.");
        }
        Console.WriteLine($"Produto: {produto} || Valor: {preco} || Quantidade: {quantidade}");
    }
}
