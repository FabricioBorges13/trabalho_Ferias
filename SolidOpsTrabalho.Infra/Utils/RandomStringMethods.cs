using System;
using System.Text;

namespace SolidOpsTrabalho.Infra.Utils
{
    public static class RandomStringMethods
    {
        public static string randomWords() {
            Random random = new Random();
            int numeroDeLetras = random.Next(20);
            StringBuilder stringGerada = new StringBuilder();
            for (int i = 0; i < numeroDeLetras; i++)
            {
                char letra = (char)(random.Next(30)+30);
                stringGerada.Append(letra);
            }
            return @stringGerada.ToString();
        }
    }
}
