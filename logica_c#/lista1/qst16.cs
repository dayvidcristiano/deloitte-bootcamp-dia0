using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite quantos metros voce pretende pintar:");
        int m = int.Parse(Console.ReadLine());

        double l = m / 3.0;
        int lt = (int)Math.Ceiling(l / 18);
        double t = lt * 80;

        Console.WriteLine($"Voce irá precisar comprar {lt} latas, o valor total será de R${t}");
    }
}