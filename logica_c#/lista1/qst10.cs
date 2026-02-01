using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite um valor Celcius:");
        double c = double.Parse(Console.ReadLine());

        double f = (c * 9 / 5) + 32;

        Console.WriteLine($"Celcius convertido em Farenheit: {f} ºF");
    }
}