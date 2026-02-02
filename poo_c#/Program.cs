// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

//lâmpada
/*
{
    Lampada lampada = new Lampada();
    lampada.Ligar();
    Console.WriteLine("Estado da lâmpada " + (lampada.EstaLigada() ? "Ligada" : "Deligada"));
    lampada.Desligar();
    Console.WriteLine("Estado da lâmpada " + (lampada.EstaLigada() ? "Ligada" : "Deligada"));

    
}*/

/*
{
    ContaCorrente contaCorrente = new ContaCorrente();
    contaCorrente.RealizarSaque();
    contaCorrente.DepositarDinheiro();
}
*/

{
    var contaUsuario = new ContaCorrente(numero: "0202-Y", saldoInicial: 658, ehEspecial: false, limite: 0);
    Console.WriteLine("Conta do usuário.");
    Console.WriteLine(contaUsuario);

    Console.WriteLine("Tentando sacar R$ 600,00 (deve falhar)");
    bool sacou = contaUsuario.Sacar(600);
    Console.WriteLine($"Saque realizado? {(sacou ? "Sim" : "Não")}. Saldo: {contaUsuario.ConsultarSaldo():c}");

    Console.WriteLine("Depositando R$300,00...");
    contaUsuario.Depositar(300);
    Console.WriteLine($"Saldo após depósito: {contaUsuario.ConsultarSaldo():c}");
    Console.WriteLine($"Usando cheque especial? {(contaUsuario.EstaUsandoChequeEspecial() ? "Sim" : "Não")}");

    Console.WriteLine(contaUsuario);

}




