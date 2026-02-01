using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite um valor Farenheit:");
        double f = double.Parse(Console.ReadLine());

        double c = (f - 32) * 5 / 9;

        Console.WriteLine($"Farenheit convertido em Celcius: {c} ºC");
    }
}