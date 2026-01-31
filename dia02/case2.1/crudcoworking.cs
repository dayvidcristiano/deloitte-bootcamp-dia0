using System;
using System.Collections.Generic;

public class Visitante
{
    public string Nome { get; set; }
    public string Documento { get; set; }
    public bool PrimeiraVez { get; set; }
    public DateTime HorarioChegada { get; set; }
}

public class Coworking
{
    static List<Visitante> listarVisitantes = new List<Visitante>();

    static void Main()
    {
        bool continuar = true;
        while (continuar)
        {
            try
            {
                Console.WriteLine("COWORKING // ESCOLHA UM NUMERO:");
                Console.WriteLine("1. Cadastrar visitante");
                Console.WriteLine("2. Listar visitantes");
                Console.WriteLine("3. Buscar visitante por nome");
                Console.WriteLine("4. Registrar saída");
                Console.WriteLine("0. Para sair do menu de seleção");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": CadastrarVisitante(); break;
                    case "2": ListarVisitantes(); break;
                    case "3": BuscarVisitantes(); break;
                    case "4": RegistarSaida(); break;
                    case "0": continuar = false; break;
                    default: Console.WriteLine("Opção Incorreta."); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }

    static void CadastrarVisitante()
    {
        try
        {
            Visitante v = new Visitante();

            Console.WriteLine("Nome do visitante:");
            v.Nome = Console.ReadLine();

            Console.WriteLine("Documento:");
            v.Documento = Console.ReadLine();

            Console.WriteLine("Primeira vez? (S/N):");
            string resposta = Console.ReadLine().ToUpper();
            v.PrimeiraVez = (resposta == "S");

            v.HorarioChegada = DateTime.Now;

            listarVisitantes.Add(v);
            Console.WriteLine("Registrado com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao enviar. {ex.Message}");
        }
    }

    static void ListarVisitantes()
    {
        Console.WriteLine("LISTA DE VISITANTES:");
        if (listarVisitantes.Count == 0)
        {
            Console.WriteLine("Nenhum visitante.");
            return;
        }
        for (int i = 0; i < listarVisitantes.Count; i++)
        {
            var v = listarVisitantes[i];
            string primeiraVezTxt = v.PrimeiraVez ? "Sim" : "Não";

            Console.WriteLine($"{i} - Nome: {v.Nome} | Chegada: {v.HorarioChegada:HH:mm} | 1 Vez: {primeiraVezTxt}");
        }
    }

    static void RegistarSaida()
    {
        ListarVisitantes();
        if (listarVisitantes.Count == 0) return;

        try
        {
            Console.WriteLine("DIGITE O INDICE DO VISITANTE QUE ESTÁ DE SAÍDA:");
            int indice = int.Parse(Console.ReadLine());

            if (indice >= 0 && indice < listarVisitantes.Count)
            {
                Console.WriteLine($"Saída confirmada: {listarVisitantes[indice].Nome}");
                listarVisitantes.RemoveAt(indice);
            }
            else
            {
                Console.WriteLine("Indice incorreto.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro. Digite um número válido.");
        }
    }

    static void BuscarVisitantes()
    {
        Console.WriteLine("DIGITE O NOME DO VISITANTE QUE VOCÊ DESEJA BUSCAR:");
        string busca = Console.ReadLine();
        bool encontrado = false;

        foreach (var v in listarVisitantes)
        {
            if (v.Nome.ToUpper().Contains(busca.ToUpper()))
            {
                Console.WriteLine($"Encontrado: {v.Nome} | Doc: {v.Documento}");
                encontrado = true;
            }
        }
        if (!encontrado) Console.WriteLine("Visitante não encontrado.");
    }
}