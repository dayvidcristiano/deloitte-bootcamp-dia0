using System;
public class Estoque
{
    static void Main()
    {
       Console.WriteLine("Informe o nome do produto:");
       string produto = Console.ReadLine();

       Console.WriteLine("Informe o valor do produto:");
       double valor = double.Parse(Console.ReadLine);

       Console.WriteLine("Informe a quantidade do produto:");
       int quantidade = int.Parse(Console.ReadLine);

    }
}




