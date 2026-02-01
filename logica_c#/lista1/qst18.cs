using System;
using System.Net.NetworkInformation;

class Program
{
    static void Main()
    {
        Console.WriteLine("Qual o tamanho do arquivo que voce deseja baixar?");
        int a = int.Parse(Console.ReadLine());

        Console.WriteLine("Qual a velocidade do link?");
        int v = int.Parse(Console.ReadLine());

        double vel = v / 8.0;        
        double ts = a / vel;        
        double tm = ts / 60;

        Console.WriteLine($"Velocidade: {vel} MB/s");
        Console.WriteLine($"O arquivo irá levar aproximadamente {tm} minutos para ser baixado.");

    }
}