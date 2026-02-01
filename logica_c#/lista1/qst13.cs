using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite sua altura:");
        double alt = double.Parse(Console.ReadLine());

        Console.WriteLine("Com qual genero voce se identifica? (M/F)");
        string g = Console.ReadLine();

        if (g == "M")
        {
            double psM = (72.7 * alt) - 58;
            Console.Write($"Peso ideal: {psM}");
        }
        if (g == "F")
        {
            double psF = (62.1 * alt) - 44.7;
            Console.WriteLine($"Peso ideal: {psF}");
        }
    }
}