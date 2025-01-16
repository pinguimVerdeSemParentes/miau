using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;

class Tarefa
{
    public static int Tarefas_criadas = 0;

    public string Titulo;
    public bool Completado = false;
    public readonly int Numero;

    public Tarefa(string titulo)
    {
        titulo = (!string.IsNullOrEmpty(titulo)) ? titulo : $"tarefa({Tarefas_criadas + 1})";
        Titulo = titulo;

        Tarefas_criadas++;
        Numero = Tarefas_criadas;
    }
}

class Miau
{
    static public List<Tarefa> tarefas = new List<Tarefa>();
    static public bool em_exec = true;

    static void Main(string[] args)
    {
        while (em_exec)
        {
            Console.WriteLine("ESCOLHA ALGO:");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("» 1 - Escrever");
            Console.WriteLine("» 2 - Ver tarefas criadas");
            Console.WriteLine("» 3 - Completar alguma tarefa");
            Console.WriteLine("» 4 - Criar VARIAS tarefas");
            Console.WriteLine("» 5 - Completar VARIAS tarefas");
            Console.WriteLine("» 6 - Incompletar alguma tarefa");
            Console.WriteLine("» 7 - Incompletar VARIAS tarefas");
            Console.WriteLine("» 8 - Salvar tarefsa em um arquivo txt");
            Console.WriteLine("» 9 - SAIR.");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("sua escolha -> ");
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    Criar_tarefa();
                    break;

                case "2":
                    Exibir_tarefas();
                    break;

                case "3":
                    Modificar_status_de_tarefa();
                    break;

                case "4":
                    Criar_varias_tarefas();
                    break;

                case "5":
                    Modificar_varias_tarefas();
                    break;

                case "6":
                    Modificar_status_de_tarefa(false);
                    break;

                case "7":
                    Modificar_varias_tarefas(false);
                    break;

                case "8":
                    Salvar_tarefas();
                    break;

                case "9":
                    Console.WriteLine("tabom entao!!1!w");
                    em_exec = false;
                    break;

                default:
                    Console.WriteLine("que");
                    break;
            }
        }
    }

    static void Criar_tarefa()
    {
        Console.WriteLine("\n\n\n----------> CRIAÇÃO DE UMA TAREFA");
        Console.Write("Escreva teu título aqui -> ");

        string Titulo = Console.ReadLine();

        Tarefa tarefa = new Tarefa(Titulo);
        tarefas.Add(tarefa);

        Console.WriteLine("<------------------------------------\n\n\n");
    }

    static void Exibir_tarefas()
    {
        Console.WriteLine("\n\n\n----------> T A R E F A S");

        if (tarefas.Count > 0)
        {
            for (int i = 0; i < tarefas.Count; i++)
            {
                string status = tarefas[i].Completado ? "[COMPLETADO]" : "[INCOMPLETO]";

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"»» [{tarefas[i].Numero}] ");

                if (tarefas[i].Completado)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                
                Console.Write(status);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($" {tarefas[i].Titulo}");
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("que vazio, poxa");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" *sons nao muito silenciosos de vento*");
            Console.ForegroundColor = ConsoleColor.White;
        }

        Console.WriteLine("\n<------------------------------------\n\n\n");
    }

    static void Modificar_status_de_tarefa(bool completar = true)
    {
        if (tarefas.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\n\n----------->\nseria bom ter alguma tarefa por aqui...\n<------------------------------\n\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        Exibir_tarefas();
        Console.Write("Coloque o numero da tarefa que tu quer completar -> ");

        string readline = Console.ReadLine();
        if (string.IsNullOrEmpty(readline))
        {
            return;
        }

        int numero = Convert.ToInt32(readline)-1;

        if (numero > tarefas.Count)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n\n------------>\nEssa tarefa não existe, bobao!!11w\n<-----------------------------------------\n\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        bool tarefa_existente = (tarefas.Contains(tarefas[numero])) ? true : false;

        if (tarefa_existente)
        {
            tarefas[numero].Completado = completar;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\n\n----------->\nTAREFA COMPLETADA -> {tarefas[numero].Titulo}\n<-------------------------------\n\n\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    static void Criar_varias_tarefas()
    {
        Console.Write("\n\n\nQUANTAS TAREFAS VAO SER CRIADAS --> ");
        string readline = Console.ReadLine();

        if (string.IsNullOrEmpty(readline))
        {
            return;
        }

        int quantidade = Convert.ToInt32(readline);

        if (quantidade > 0)
        {
            for(int i=1; i <= quantidade; i++)
            {
                Criar_tarefa();
            }
        }
    }

    static void Modificar_varias_tarefas(bool completar = true)
    {
        Console.Write("\n\n\nEM QUAL TAREFA DEVE COMEÇAR --> ");
        string readline_comeco = Console.ReadLine();

        Console.Write("\n\n\nATÉ ONDE A TAREFA DEVE SER MODIFICADA --> ");
        string readline_final = Console.ReadLine();

        if (string.IsNullOrEmpty(readline_comeco) || string.IsNullOrEmpty(readline_final))
        {
            return;
        }

        int comeco = Convert.ToInt32(readline_comeco);
        int final = Convert.ToInt32(readline_final);

        if (comeco >= 0 && final <= tarefas.Count)
        {
            for (int i = comeco; i <= final; i++)
            {
                Console.WriteLine($"tarefa MODIFICADA -> {tarefas[i-1].Titulo}");
                tarefas[i-1].Completado = completar;
            }
        }
    }

    static void Salvar_tarefas()
    {
        // ISSO FOI SÓ UM TESTE PARA PODER SALVAR AS TAREFAS EM UM ARQUIVO.TXT (talvez isso funcione só para o meu pc AINDA)
        
        if (tarefas.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n\n------->\nbom... pra salvar eu preciso de TAREFAS, claro\n<----------------------------\n\n\n");
            Console.ForegroundColor = ConsoleColor.Black;
            return;
        }

        Console.Write("\n»» nome do arquivo -> ");
        string Nome = Console.ReadLine();

        Console.Write("\n»» caminho do arquivo -> ");
        string Caminho = Console.ReadLine();

        if (string.IsNullOrEmpty(Nome) || string.IsNullOrEmpty(Caminho))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n\n------->\n o NOME ou o CAMINHO do arquivo tá incorreto\n<----------------------------\n\n\n");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        using (StreamWriter writer = new StreamWriter(@$"C:\Users\User\Desktop\miau.txt")) //eu adiciono essa parte pro usuario escolher mais tarde...w
        {
            for (int i = 0; i < tarefas.Count; i++)
            {
                string status = (tarefas[i].Completado) ? "[COMPLETADO]" : "[INCOMPLETO]";
                writer.WriteLine($"[{tarefas[i].Numero}] {status} {tarefas[i].Titulo}");
            }
        }
    }
}
