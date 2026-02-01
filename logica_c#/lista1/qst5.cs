using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Iremos converter metro por centimetro:");

        Console.Write("Digite o número em metro:");
        double m = double.Parse(Console.ReadLine());

        double c = m * 100;

        Console.WriteLine($"{m} m equivale a: {c} cm");
    }
}