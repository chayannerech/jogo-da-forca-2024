﻿using System;
namespace JogoDaForca.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pontuacao = 0;
            string hora = "";
            DateTime thisDay = DateTime.Now;

            while (true)
            {
                hora = thisDay.ToString("t");
                string palavraAleatoria; char tentativa; int numErro, numTentativas; char[] caracteres, mostraTentativa, historico;
                IniciaVariaveis(out palavraAleatoria, out tentativa, out numErro, out numTentativas, out historico, out caracteres, out mostraTentativa, ref pontuacao);
                while (true)
                {
                    Console.Clear();
                    int errou = 1;
                    MostrarForca(numErro, mostraTentativa, ref tentativa, palavraAleatoria, ref pontuacao, hora);

                    if (numErro == 5) break;

                    MostraAtual(mostraTentativa, numTentativas, historico);
                    RecebeChute(caracteres, mostraTentativa, ref historico, ref errou, ref numErro, ref numTentativas, ref pontuacao) ;

                    Venceu(palavraAleatoria, tentativa, numErro, mostraTentativa, pontuacao, hora);
                    if (Array.TrueForAll(mostraTentativa, valor => valor != '_')) break;
                }
                if (DeveContinuar()) break;
            }
        }
        static void IniciaVariaveis(out string palavraAleatoria, out char tentativa, out int numErro, out int numTentativas, out char[] historico, out char[] caracteres, out char[] mostraTentativa, ref int pontuacao)
        {
            Random random = new Random();

            string[] palavra = { "ABACATE", "ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA", "ABACATE", "BACABA", "BACURI", "BANANA", "CAJÁ", "CAJÚ", "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO", "MAÇÃ", "MANGABA", "MANGA", "MARACUJÁ", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA" };
            palavraAleatoria = palavra[random.Next(palavra.Length)];
            tentativa = ' ';
            numErro = 0;
            numTentativas = 0;
            caracteres = palavraAleatoria.ToCharArray();
            mostraTentativa = new char[caracteres.Length * 2];
            historico = new char[10];
            pontuacao += palavraAleatoria.Length;

            for (int i = 0; i < mostraTentativa.Length; i++)
            {
                if (i % 2 == 0) mostraTentativa[i] = '_';
                else mostraTentativa[i] = ' ';
            }
        }
        static void MostrarForca(int numErro, char[] mostraTentativa, ref char tentativa, string palavraAleatoria, ref int pontuacao, string hora)
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
                    if (pontuacao < palavraAleatoria.Length) pontuacao = 0;
                    else pontuacao -= palavraAleatoria.Length;
                    Console.WriteLine("  ___________");
                    Console.WriteLine("  |/       |");
                    Console.WriteLine("  |        O");
                    Console.WriteLine("  |       /X\\");
                    Console.Write($"  |        X\n  |\n  |\n  |\n _|____\n\n\nFIM DE JOGO :(\nA palavra era: {palavraAleatoria}\n\nPONTUAÇÃO: {pontuacao} ({hora})\n\n");
                    break;
            }
        }
        static void MostraAtual(char[] mostraTentativa, int numTentativas, char[] historico)
        {
            for (int i = 0; i < mostraTentativa.Length; i++) Console.Write(mostraTentativa[i]);
            if (numTentativas > 0) Console.Write("\n\nHistórico: ");
            for (int i = 0; i < numTentativas; i++) Console.Write(historico[i]); 
        }
        static void RecebeChute(char[] caracteres, char[] mostraTentativa, ref char[] historico, ref int errou, ref int numErro, ref int numTentativas, ref int pontuacao)
        {
            char tentativa;
            Console.Write("\n\nQual o seu chute? ");
            tentativa = char.ToUpper(Convert.ToChar(Console.ReadLine()));
            historico[numTentativas] = tentativa;
            numTentativas++;

            for (int i = 0; i < caracteres.Length; i++)
            {
                if (tentativa == caracteres[i])
                {
                    mostraTentativa[i * 2] = tentativa;
                    errou = 0;
                }
            }
            if (errou == 1)
            {
                numErro++;
                pontuacao--;
            }
        }
        static void Venceu(string palavraAleatoria, char tentativa, int numErro, char[] mostraTentativa, int pontuacao, string hora)
        {
            if (Array.TrueForAll(mostraTentativa, valor => valor != '_'))
            {
                Console.Clear();
                MostrarForca(numErro, mostraTentativa, ref tentativa, palavraAleatoria, ref pontuacao, hora);
                for (int i = 0; i < mostraTentativa.Length; i++) Console.Write(mostraTentativa[i]);
                Console.WriteLine($"\n\nUAU!!! Você venceu!\n\nPONTUAÇÃO: {pontuacao} ({hora})\n");
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
