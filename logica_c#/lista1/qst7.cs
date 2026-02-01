using System;
using System.Formats.Asn1;
class Program
{
    static void Main()
    {
        Console.WriteLine("Iremos calcular a área do quadrado:");

        Console.WriteLine("Digite o tamanho dos lados:");
        int lado = int.Parse(Console.ReadLine());

        int area = (lado * 4) * 2;

        Console.WriteLine($"O dobro da área do quadrado digitado: {area}");
    }
}