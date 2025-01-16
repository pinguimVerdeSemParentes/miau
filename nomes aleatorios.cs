using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUNGEON_UMLTIARRAY
{
    class GerarNomes
    {
        private static Random random = new Random();
        public static char[] Alfabeto = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        public static string GerarNome(int Tamanho = 4)
        {
            string nome = "";

            for (int i=1; i <= Tamanho; i++)
            {
                string caractere = Alfabeto[random.Next(0, Alfabeto.Length-1)].ToString();

                if (random.Next(0, 3) == 1)
                {
                    caractere = caractere.ToUpper();
                }

                nome += caractere;
            }

            return nome;
        }
    }
}
