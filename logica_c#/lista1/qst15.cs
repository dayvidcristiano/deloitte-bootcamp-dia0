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

        double imp = salarioFinal * 0.11;
        double inss = salarioFinal * 0.08;
        double snd = salarioFinal * 0.05;

        double sl = salarioFinal - imp - inss - snd;

        Console.WriteLine($"Salário bruto: R${salarioFinal}");
        Console.WriteLine($"IR (11%): R${imp}");
        Console.WriteLine($"INSS (8%): R${inss}");
        Console.WriteLine($"Sindicato (5%): R${snd}");
        Console.WriteLine($"Salario Liquido: R${sl}");
    }
}