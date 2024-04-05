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
                string palavraAleatoria, hora; char tentativa; int numErro, numTentativas; char[] caracteres, mostraTentativa, historico;
                IniciaVariaveis(out palavraAleatoria, out hora, out tentativa, out numErro, out numTentativas, out historico, out caracteres, out mostraTentativa, ref pontuacao);
                while (true)
                {
                    Console.Clear();
                    MostraForca(numErro, mostraTentativa, ref tentativa, palavraAleatoria);

                    if (numErro == 5) break;

                    MostraAtual(mostraTentativa, numTentativas, historico);
                    RecebeChute(caracteres, mostraTentativa, ref historico, ref numErro, ref numTentativas, ref pontuacao, ref pontos, jogadas, hora);
                    Venceu(palavraAleatoria, tentativa, numErro, mostraTentativa, pontos);

                    if (Array.TrueForAll(mostraTentativa, valor => valor != '_')) break;
                }
                if (DeveContinuar(ref jogadas, pontos)) break;
            }
        }
        static void IniciaVariaveis(out string palavraAleatoria, out string hora, out char tentativa, out int numErro, out int numTentativas, out char[] historico, out char[] caracteres, out char[] mostraTentativa, ref int pontuacao)
        {
            Random random = new Random();
            string[] palavra = { "ABACATE", "ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA", "ABACATE", "BACABA", "BACURI", "BANANA", "CAJÁ", "CAJÚ", "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO", "MAÇÃ", "MANGABA", "MANGA", "MARACUJÁ", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA" };
            palavraAleatoria = palavra[random.Next(palavra.Length)];
            caracteres = palavraAleatoria.ToCharArray();
            mostraTentativa = new char[caracteres.Length * 2];
            hora = DateTime.Now.ToString("t");
            tentativa = ' ';
            numErro = 0;
            numTentativas = 0;
            historico = new char[20];
            pontuacao += caracteres.Length;

            for (int i = 0; i < mostraTentativa.Length; i++)
            {
                if (i % 2 == 0) mostraTentativa[i] = '_';
                else mostraTentativa[i] = ' ';
            }
        }
        static void MostraForca(int numErro, char[] mostraTentativa, ref char tentativa, string palavraAleatoria)
        {
            Console.WriteLine($"Dica: {Dica(palavraAleatoria)}");
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
        static void MostraAtual(char[] mostraTentativa, int numTentativas, char[] historico)
        {
            for (int i = 0; i < mostraTentativa.Length; i++) Console.Write(mostraTentativa[i]);
            if (numTentativas > 0) Console.Write("\t\tHistórico: ");
            for (int i = 0; i < numTentativas; i++) Console.Write(historico[i] + " ");
        }
        static void RecebeChute(char[] caracteres, char[] mostraTentativa, ref char[] historico, ref int numErro, ref int numTentativas, ref int pontuacao, ref string[] pontos, int jogadas, string hora)
        {
            int errou = 1;
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

            if (numErro == 5)
            {
                if (pontuacao < caracteres.Length) pontuacao = 0;
                else pontuacao -= caracteres.Length;
            }

            pontos[jogadas] = $"{pontuacao} ({hora})";
        }
        static void Venceu(string palavraAleatoria, char tentativa, int numErro, char[] mostraTentativa, string[] pontos)
        {
            if (Array.TrueForAll(mostraTentativa, valor => valor != '_'))
            {
                Console.Clear();
                MostraForca(numErro, mostraTentativa, ref tentativa, palavraAleatoria);
                for (int i = 0; i < mostraTentativa.Length; i++) Console.Write(mostraTentativa[i]);
                Console.WriteLine($"\n\nUAU!!! Você venceu!\n");
            }
        }
        static string Dica(string palavraAleatoria)
        {
            if (palavraAleatoria == "ABACATE") return "Tem caroço";
            if (palavraAleatoria == "ABACAXI") return "É tropical";
            if (palavraAleatoria == "ACEROLA") return "Tem muita vitamina C";
            if (palavraAleatoria == "AÇAÍ") return "É popular";
            if (palavraAleatoria == "ARAÇA") return "Primo da goiaba";
            if (palavraAleatoria == "BACABA") return "Nativa da Amazônia";
            if (palavraAleatoria == "BACURI") return "Muito popular no Norte";
            if (palavraAleatoria == "BANANA") return "Seu pé só dá fruto uma vez";
            if (palavraAleatoria == "CAJÁ") return "Não é comum no Sul";
            if (palavraAleatoria == "CAJÚ") return "Quando crua, sua semente é venenosa";
            if (palavraAleatoria == "CARAMBOLA") return "Possui um formato bonito";
            if (palavraAleatoria == "CUPUAÇU") return "Gera doces azedinhos";
            if (palavraAleatoria == "GRAVIOLA") return "Ótimo para sucos suaves";
            if (palavraAleatoria == "GOIABA") return "Tem muitas sementes comestíveis";
            if (palavraAleatoria == "JABUTICABA") return "Cresce de forma peculiar";
            if (palavraAleatoria == "JENIPAPO") return "Casca mole e parda";
            if (palavraAleatoria == "MAÇÃ") return "Fruta mais cultivada no mundo";
            if (palavraAleatoria == "MANGABA") return "Nativa do Brasil";
            if (palavraAleatoria == "MANGA") return "No Pará, ninguém precisa comprar";
            if (palavraAleatoria == "MARACUJÁ") return "Ótima para drinks tropicais";
            if (palavraAleatoria == "MURICI") return "Dá em cachos frondosos";
            if (palavraAleatoria == "PEQUI") return "Tem espinho";
            if (palavraAleatoria == "PITANGA") return "Pequena fruta bonita";
            if (palavraAleatoria == "PITAYA") return "Seu sabor divide opiniões";
            if (palavraAleatoria == "SAPOTI") return "Nativa do México";
            if (palavraAleatoria == "TANGERINA") return "Possui muitas primas";
            if (palavraAleatoria == "UMBU") return "A polpa é grudada na semente";
            if (palavraAleatoria == "UVA") return "Um milhão de utilizades";
            else return "Intenso sabor azedo";
        }
        static void MostraPontuacao(string[] pontos)
        {
            Console.WriteLine("....................\nPONTUAÇÃO:");
            for (int i = 0; i < pontos.Length; i++) if (pontos[i] != null) Console.WriteLine(pontos[i]);
        }
        static bool DeveContinuar(ref int jogadas, string[] pontos)
        {
            MostraPontuacao(pontos);
            Console.WriteLine("....................\n\nDeseja repetir? [S,N]");
            string continuar = Console.ReadLine();
            jogadas++;
            return continuar == "n" || continuar == "N";
        }
    }
}
