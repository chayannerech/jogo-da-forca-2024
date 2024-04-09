using System;
namespace JogoDaForca.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pontuacao = 0, jogadas = 0;
            string[] pontos = new string[100];

            while (true)
            {
                Forca jogo = new Forca();
                jogo.IniciaVariaveis(ref pontuacao);
                while (true)
                {
                    Console.Clear();
                    jogo.MostraForca();

                    if (jogo.numErro == 5) break;

                    jogo.MostraAtual();
                    jogo.RecebeChute(ref pontuacao, ref pontos, ref jogadas);
                    jogo.Venceu();

                    if (Array.TrueForAll(jogo.mostraTentativa, valor => valor != '_')) break;
                }
                if (DeveContinuar(ref jogadas, pontos)) break;
            }
        }
        static bool DeveContinuar(ref int jogadas, string[] pontos)
        {
            MostraPontuacao(pontos);
            Console.WriteLine("....................\n\nDeseja repetir? [S,N]");
            string continuar = Console.ReadLine();
            jogadas++;
            return continuar == "n" || continuar == "N";
        }
        static void MostraPontuacao(string[] pontos)
        {
            Console.WriteLine("....................\nPONTUAÇÃO:");
            for (int i = 0; i < pontos.Length; i++) if (pontos[i] != null) Console.WriteLine(pontos[i]);
        }
    }
}
