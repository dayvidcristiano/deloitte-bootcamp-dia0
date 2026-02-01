using System;
using System.IO.Pipelines;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite sua altura:");
        double alt = double.Parse(Console.ReadLine());

        double ps = (72.7 * alt) - 58;

        Console.WriteLine($"Peso ideal: {ps}");
    }
}