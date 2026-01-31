using System;
using System.Collections.Generic;

public class Dados
{
    public string Nome { get; set; } = "";
    public int Idade { get; set; }
}

public class Cadastro
{
    static void Main()
    {
        List<Dados> listaDados = new List<Dados>();

        Console.WriteLine("Digite nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite idade:");
        int idade = int.Parse(Console.ReadLine());

        if (!String.IsNullOrWhiteSpace(nome) && idade > 0)
        {
            Dados novo = new Dados();
            novo.Nome = nome;
            novo.Idade = idade;

            listaDados.Add(novo);

            Console.WriteLine("Pessoa cadastrada.");
            Console.WriteLine($"Nome: {novo.Nome}");
            Console.WriteLine($"Idade: {novo.Idade}");
        }
        else
        {
            Console.WriteLine("Erro ao cadastrar.");
        }
    }
}
