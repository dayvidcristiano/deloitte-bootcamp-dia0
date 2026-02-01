using System;
class Program
{
    static void Main()
    {
       double soma = 0;
       int i = 1;

       while(i <= 4)
        {
            Console.WriteLine($"Digite o {i} número:");
            soma += double.Parse(Console.ReadLine());
            i++;
        } 
        double media = soma / 4;

        Console.WriteLine($"A média é: {media}");
    }
}