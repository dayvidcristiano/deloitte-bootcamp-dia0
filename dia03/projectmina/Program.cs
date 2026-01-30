// See https://aka.ms/new-console-template for more information

//Console.WriteLine("Fala, Mina!");

using System.ComponentModel.DataAnnotations;

Mina mina = new Mina();
//Minerio minerio = mina.extrairMinerio();
Minerio minerio = mina.acessarExtarirMinerio();


Console.WriteLine(minerio.tipo); 