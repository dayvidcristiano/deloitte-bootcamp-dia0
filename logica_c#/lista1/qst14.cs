using System;
using System.Net.Quic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Quantos quilos voce conseguiu pescar hoje?");
        double ps = double.Parse(Console.ReadLine());

        if (ps <= 50)
        {
            Console.WriteLine("Voce não irá pagar multa.");
        }
        else if (ps > 50)
        {
            double pse = ps - 50;
            double mlt = pse * 4;

            Console.Write($"Voce terá que pagar uma multa de R$ {mlt}");
        }

    }
}