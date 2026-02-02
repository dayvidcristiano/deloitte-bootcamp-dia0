// using System.Data;

// public class ContaCorrente
// {
//     public decimal saldo = 525.89;

//     public void RealizarSaque()
//     {
//         Console.WriteLine("Quanto você deseja retirar da conta?");
//         decimal retirar = decimal.Parse(Console.ReadLine());

//         decimal menos = saldo - retirar;

//         if (saldo < retirar)
//         {
//             Console.WriteLine("Você não tem saldo o suficiente.");
//         }
//         else
//         {
//             Console.WriteLine($"Você retirou: R${retirar:F2}, agora você possui: R${menos:F2}");
//         }
//     }
//     public void DepositarDinheiro()
//     {
//         Console.WriteLine("Você deseja depositar quanto de dinhero?");
//         decimal depositar = decimal.Parse(Console.WriteLine());

//         decimal mais = saldo + depositar;

//         Console.WriteLine($"Você depositou: R${depositar}, agora seu saldo é: R${mais}");
//     }
// }

using System.Dynamic;

public class ContaCorrente
{
    public string Numero { get; }
    public decimal Saldo { get; private set; }
    public bool EhEspecial { get; }
    public decimal Limite { get; }
    public ContaCorrente(string numero, decimal saldoInicial, bool ehEspecial, decimal limite)
    {
        if (string.IsNullOrWhiteSpace(numero))
        {
            throw new ArgumentException("Número da conta é obrigatório.", nameof(numero));
        }
        if (limite < 0)
        {

            throw new ArgumentOutOfRangeException(nameof(limite), "Limite não pode ser negativo");
        }
        Numero = numero;
        Saldo = saldoInicial;
        EhEspecial = ehEspecial;
        Limite = limite;
    }
    public bool Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(valor), "O valor do saque deve ser positivo.");
        }
        if (!EhEspecial)
        {
            if (valor <= Saldo)
            {
                Saldo -= valor;
                return true;
            }
        }
        return false;
    }
    public void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(valor), "O valor do deposito deve ser positivo.");
        }
        Saldo += valor;
    }
    public decimal ConsultarSaldo() => Saldo;

    public bool EstaUsandoChequeEspecial() => Saldo < 0;
    public override string ToString()
    {
        return $"Conta {Numero} | Saldo: {Saldo:c} | Especial: {(EhEspecial ? "Sim" : "Não")} | Limite: {Limite:c}";
    }
}