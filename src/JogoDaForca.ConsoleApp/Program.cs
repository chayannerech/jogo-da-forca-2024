using System;
namespace JogoDaForca.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string palavraAleatoria; char tentativa; int numErro; char[] caracteres, mostraTentativa;
                IniciaVariaveis(out palavraAleatoria, out tentativa, out numErro, out caracteres, out mostraTentativa);
                while (true)
                {
                    Console.Clear();
                    int errou = 1;
                    MostrarForca(numErro, mostraTentativa, ref tentativa, palavraAleatoria);

                    if (numErro == 5) break;

                    MostraAtual(mostraTentativa);
                    RecebeChute(caracteres, mostraTentativa, ref errou, ref numErro);

                    Venceu(palavraAleatoria, tentativa, numErro, mostraTentativa);
                    if (Array.TrueForAll(mostraTentativa, valor => valor != '_')) break;
                }
                if (DeveContinuar()) break;
            }
        }
        static void IniciaVariaveis(out string palavraAleatoria, out char tentativa, out int numErro, out char[] caracteres, out char[] mostraTentativa)
        {
            Random random = new Random();

            string[] palavra = { "ABACATE", "ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA", "ABACATE", "BACABA", "BACURI", "BANANA", "CAJÁ", "CAJÚ", "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO", "MAÇÃ", "MANGABA", "MANGA", "MARACUJÁ", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA" };
            palavraAleatoria = palavra[random.Next(palavra.Length)];
            tentativa = ' ';
            numErro = 0;
            caracteres = palavraAleatoria.ToCharArray();
            mostraTentativa = new char[caracteres.Length * 2];

            for (int i = 0; i < mostraTentativa.Length; i++)
            {
                if (i % 2 == 0) mostraTentativa[i] = '_';
                else mostraTentativa[i] = ' ';
            }
        }
        static void MostrarForca(int numErro, char[] mostraTentativa, ref char tentativa, string palavraAleatoria)
        {
            switch (numErro)
            {
                case 0:
                    Console.Write("  ___________\n  |/\n  |\n  |\n  |\n  |\n  |\n  |\n _|____\n\n   ");
                    break;

                case 1:
                    Console.WriteLine("  ___________");
                    Console.WriteLine("  |/       |");
                    Console.Write("  |        O\n  |\n  |\n  |\n  |\n  |\n _|____\n\n   ");
                    break;

                case 2:
                    Console.WriteLine("  ___________");
                    Console.WriteLine("  |/       |");
                    Console.WriteLine("  |        O");
                    Console.Write("  |        X\n  |\n  |\n  |\n  |\n _|____\n\n   ");
                    break;

                case 3:
                    Console.WriteLine("  ___________");
                    Console.WriteLine("  |/       |");
                    Console.WriteLine("  |        O");
                    Console.Write("  |       /X\n  |\n  |\n  |\n  |\n _|____\n\n   ");
                    break;

                case 4:
                    Console.WriteLine("  ___________");
                    Console.WriteLine("  |/       |");
                    Console.WriteLine("  |        O");
                    Console.Write("  |       /X\\\n  |\n  |\n  |\n  |\n _|____\n\n   ");
                    break;

                case 5:
                    Console.WriteLine("  ___________");
                    Console.WriteLine("  |/       |");
                    Console.WriteLine("  |        O");
                    Console.WriteLine("  |       /X\\");
                    Console.Write($"  |        X\n  |\n  |\n  |\n _|____\n\n\nFIM DE JOGO :(\nA palavra era: {palavraAleatoria}\n\n");
                    break;
            }
        }
        static void MostraAtual(char[] mostraTentativa)
        {
            for (int i = 0; i < mostraTentativa.Length; i++) Console.Write(mostraTentativa[i]);
        }
        static void RecebeChute(char[] caracteres, char[] mostraTentativa, ref int errou, ref int numErro)
        {
            char tentativa;
            Console.Write("\n\n\nQual o seu chute? ");
            tentativa = char.ToUpper(Convert.ToChar(Console.ReadLine()));

            for (int i = 0; i < caracteres.Length; i++)
            {
                if (tentativa == caracteres[i])
                {
                    mostraTentativa[i * 2] = tentativa;
                    errou = 0;
                }
            }
            if (errou == 1) numErro++;
        }
        static void Venceu(string palavraAleatoria, char tentativa, int numErro, char[] mostraTentativa)
        {
            if (Array.TrueForAll(mostraTentativa, valor => valor != '_'))
            {
                Console.Clear();
                MostrarForca(numErro, mostraTentativa, ref tentativa, palavraAleatoria);
                for (int i = 0; i < mostraTentativa.Length; i++) Console.Write(mostraTentativa[i]);
                Console.WriteLine("\n\nUAU!!! Você venceu!\n");
            }
        }
        static bool DeveContinuar()
        {
            Console.WriteLine("Deseja repetir? [S,N]");
            string continuar = Console.ReadLine();
            return continuar == "n" || continuar == "N";
        }
    }
}
