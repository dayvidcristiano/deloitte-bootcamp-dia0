using System;
using System.Collections.Generic;

public class Produto
{
    public string Nome { get; set; }
    public double Preco { get; set; }
    public int Quantidade { get; set; }
}

public class Estoque
{
    static List<Produto> estoque = new List<Produto>();

    static void Main()
    {
        bool rodando = true;
        while (rodando)
        {
            Console.WriteLine("ESCOLHA UM NÚMERO:");
            Console.WriteLine("1. Adicionar um item aos estoque");
            Console.WriteLine("2. Listar itens do estoque");
            Console.WriteLine("3. Editar item do estoque");
            Console.WriteLine("4. Excluir item do estoque");
            Console.WriteLine("0. Para sair do menu de seleção");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": AdicionarProduto(); break;
                case "2": ListarProduto(); break;
                case "3": EditarProduto(); break;
                case "4": DeletarProduto(); break;
                case "0": rodando = false; break;
                default: Console.WriteLine("Opção incorreta."); break;
            }
        }
    }
    static void AdicionarProduto()
    {
        Console.WriteLine("Nome do produto:");
        string nome = Console.ReadLine();

        Console.Write("Preço do produto:");
        double preco = double.Parse(Console.ReadLine());

        Console.WriteLine("Quantidade:");
        int quantidade = int.Parse(Console.ReadLine());

        estoque.Add(new Produto { Nome = nome, Preco = preco, Quantidade = quantidade });
        Console.WriteLine("Produto cadastrado com sucesso!");
    }
    static void ListarProduto()
    {
        Console.WriteLine("PRODUTOS CADASTRADOS:");
        if (estoque.Count == 0) Console.WriteLine("Nada cadastrado.");

        for (int i = 0; i < estoque.Count; i++)
        {
            Console.WriteLine($"{i} - Nome: {estoque[i].Nome} | Preço: {estoque[i].Preco} | Quantidade: {estoque[i].Quantidade}");
        }
    }
    static void DeletarProduto()
    {
        ListarProduto();
        if (estoque.Count > 0)
        {
            Console.WriteLine("DIGITE O INDICE DO PRODUTO QUE VOCÊ DESEJA EXCLUIR:");
            int indice = int.Parse(Console.ReadLine());

            if (indice >= 0 && indice < estoque.Count)
            {
                estoque.RemoveAt(indice);
                Console.WriteLine("Produto removido.");
            }
            else
            {
                Console.WriteLine("Indice incorreto.");
            }
        }
    }
    static void EditarProduto()
    {
        ListarProduto();
        if (estoque.Count > 0)
        {
            Console.WriteLine("DIGITE O INDICE DO PRODUTO QUE VOCÊ DESEJA EDITAR:");
            int indice = int.Parse(Console.ReadLine());

            if (indice >= 0 && indice < estoque.Count)
            {
                Console.WriteLine("Novo nome:");
                estoque[indice].Nome = Console.ReadLine();

                Console.WriteLine("Novo preço:");
                estoque[indice].Preco = double.Parse(Console.ReadLine());

                Console.WriteLine("Nova quantidade:");
                estoque[indice].Quantidade = int.Parse(Console.ReadLine());

                Console.WriteLine("Produto atualizado.");
            }
            else
            {
                Console.WriteLine("Indice invalido");
            }
        }
    }
}
