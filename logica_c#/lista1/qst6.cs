using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Iremos calcular o Raio de circulo:");

        Console.WriteLine("Digite o valor do raio:");
        double raio = double.Parse(Console.ReadLine());

        double area = Math.PI * raio * raio;

        Console.WriteLine($"Calculo: {area}");
    }
}