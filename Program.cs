using DUNGEON_UMLTIARRAY;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;

class Monstro
{
    public string Nome;
    public int Vida;
    public int Defesa;

    public Dictionary<string, int> Ataques;


    public Monstro(string nome, int vida, int defesa, Dictionary<string, int> ataques)
    {
        Nome = nome;
        Vida = vida;
        Defesa = defesa;
        Ataques = ataques;
    }

    public void Status()
    {
        Console.WriteLine("\n========================================================================");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Nome: {Nome}");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Vida: {Vida}HP");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Defesa: {Defesa}");

        Console.ForegroundColor = ConsoleColor.Blue;
        foreach (var atq in Ataques)
        {
            Console.WriteLine($"- [{atq.Key}: {atq.Value}] -");
        }
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("-------------------------------------------------------");
    }
}

class Program
{
    public static Random random = new Random();
    private static List<Monstro> Monstros = new List<Monstro>();
    static void Main(string[] args)
    {
        IniciarMonstros(12);
        Lutar();
    }

    static void IniciarMonstros(int quantidade = 1)
    {
        for (int i = 1; i <= quantidade; i++)
        {
            var ataques = new Dictionary<string, int>();

            for (int j = 1; j < random.Next(2, 11); j++)
            {
                ataques.Add($"ataque{j}", random.Next(10, 1001));
            }

            Monstro monstro = new Monstro(GerarNomes.GerarNome(random.Next(4, 10)), random.Next(50, 1001), random.Next(10, 1001), ataques);
            Monstros.Add(monstro);

            monstro.Status();
        }
    }

    static void Lutar()
    {
        Console.WriteLine("==================================================================================");

        Monstro SEU_monstro = Monstros[random.Next(0, Monstros.Count-1)];
        Monstro monstro_RIVAL = Monstros[random.Next(0, Monstros.Count - 1)];

        Console.WriteLine("SEU MONSTRO AÌ:");
        SEU_monstro.Status();

        // como eu AINDA estou fazendo, é muito provavel que o RIVAL seja o SEU
        Console.WriteLine("SEU MONSTRO RIVAL AÌ:");
        monstro_RIVAL.Status();

        Console.WriteLine("-------------------------------------------------------");
    }
}