using System;
class Program
{
    static void Main()
    {
        int soma = 0;
        int i = 1;

        while(i <= 2)
        {
            Console.WriteLine($"Digite o {i}° número:");
            soma += int.Parse(Console.ReadLine());
            i++;
        }
        Console.WriteLine($"Soma dos números digitados: {soma}");
    }
}