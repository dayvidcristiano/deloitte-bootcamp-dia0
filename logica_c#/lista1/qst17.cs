using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite quantos metros voce pretende pintar:");
        int m = int.Parse(Console.ReadLine());

        double l = m / 6.0;
        double lt = l * 1.10;
        double ltotal = Math.Ceiling(lt / 18);
        double prl = ltotal * 80;
        double g = Math.Ceiling(lt / 3.6);
        double prg = g * 25;

        Console.WriteLine($"Área a ser pintada: {m} m");
        Console.WriteLine($"Litros necessários (com 10%): {lt} L");

        Console.WriteLine("Apenas latas de 18L:");
        Console.WriteLine($"Quantidade de latas: {ltotal}");
        Console.WriteLine($"Preço total: R$ {prl}");

        Console.WriteLine("Apenas galões de 3,6L:");
        Console.WriteLine($"Quantidade de galões: {g}");
        Console.WriteLine($"Preço total: R$ {prg}");

    }
}