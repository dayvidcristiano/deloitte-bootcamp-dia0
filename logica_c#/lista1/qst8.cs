using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Iremos calcular quanto voce irá ganhar no final do mes:");

        Console.WriteLine("Quanto voce ganha por hora?");
        double din = double.Parse(Console.ReadLine());

        Console.WriteLine("Voce trabalha quantas horas por mes?");
        int hr = int.Parse(Console.ReadLine());

        double salarioFinal = din * hr;

        Console.WriteLine($"Voce irá receber R${salarioFinal} esse mes.");
    }
}