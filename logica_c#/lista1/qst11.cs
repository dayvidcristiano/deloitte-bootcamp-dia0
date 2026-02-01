using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite um número inteiro:");
        int num1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite outro número inteiro:");
        int num2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite um número real:");
        double num3 = double.Parse(Console.ReadLine());

        double r1 = (num1 * 2) * (num2 / 2.0);

        double r2 = (num1 * 3) + num3;

        double r3 = Math.Pow(num3, 3);

        Console.WriteLine($"N1: {num1}, N2: {num2}, N3: {num3}");

        Console.WriteLine($"Produto do dobro do primeiro com a metade do segundo: {r1}");

        Console.WriteLine($"Soma do triplo do primeiro com o terceiro: {r2}");

        Console.WriteLine($"Terceiro elevado ao cubo: {r3}");

    }
}