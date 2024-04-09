namespace JogoDaForca.ConsoleApp
{
    public class Forca
    {
        public string palavraAleatoria, hora;
        public char tentativa;
        public int numErro, numTentativas;
        public char[] caracteres, mostraTentativa, historico;

        public void IniciaVariaveis(ref int pontuacao)
        {
            Random random = new Random();
            string[] palavra = { "ABACATE", "ABACAXI", "ACEROLA", "A�A�", "ARA�A", "ABACATE", "BACABA", "BACURI", "BANANA", "CAJ�", "CAJ�", "CARAMBOLA", "CUPUA�U", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO", "MA��", "MANGABA", "MANGA", "MARACUJ�", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA" };
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
        public void MostraForca()
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
        public void MostraAtual()
        {
            for (int i = 0; i < mostraTentativa.Length; i++) Console.Write(mostraTentativa[i]);
            if (numTentativas > 0) Console.Write("\t\tHist�rico: ");
            for (int i = 0; i < numTentativas; i++) Console.Write(historico[i] + " ");
        }
        public void RecebeChute(ref int pontuacao, ref string[] pontos, ref int jogadas)
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
        public void Venceu()
        {
            if (Array.TrueForAll(mostraTentativa, valor => valor != '_'))
            {
                Console.Clear();
                MostraForca();
                for (int i = 0; i < mostraTentativa.Length; i++) Console.Write(mostraTentativa[i]);
                Console.WriteLine($"\n\nUAU!!! Voc� venceu!\n");
            }
        }

        static string Dica(string palavraAleatoria)
        {
            if (palavraAleatoria == "ABACATE") return "Tem caro�o";
            if (palavraAleatoria == "ABACAXI") return "� tropical";
            if (palavraAleatoria == "ACEROLA") return "Tem muita vitamina C";
            if (palavraAleatoria == "A�A�") return "� popular";
            if (palavraAleatoria == "ARA�A") return "Primo da goiaba";
            if (palavraAleatoria == "BACABA") return "Nativa da Amaz�nia";
            if (palavraAleatoria == "BACURI") return "Muito popular no Norte";
            if (palavraAleatoria == "BANANA") return "Seu p� s� d� fruto uma vez";
            if (palavraAleatoria == "CAJ�") return "N�o � comum no Sul";
            if (palavraAleatoria == "CAJ�") return "Quando crua, sua semente � venenosa";
            if (palavraAleatoria == "CARAMBOLA") return "Possui um formato bonito";
            if (palavraAleatoria == "CUPUA�U") return "Gera doces azedinhos";
            if (palavraAleatoria == "GRAVIOLA") return "�timo para sucos suaves";
            if (palavraAleatoria == "GOIABA") return "Tem muitas sementes comest�veis";
            if (palavraAleatoria == "JABUTICABA") return "Cresce de forma peculiar";
            if (palavraAleatoria == "JENIPAPO") return "Casca mole e parda";
            if (palavraAleatoria == "MA��") return "Fruta mais cultivada no mundo";
            if (palavraAleatoria == "MANGABA") return "Nativa do Brasil";
            if (palavraAleatoria == "MANGA") return "No Par�, ningu�m precisa comprar";
            if (palavraAleatoria == "MARACUJ�") return "�tima para drinks tropicais";
            if (palavraAleatoria == "MURICI") return "D� em cachos frondosos";
            if (palavraAleatoria == "PEQUI") return "Tem espinho";
            if (palavraAleatoria == "PITANGA") return "Pequena fruta bonita";
            if (palavraAleatoria == "PITAYA") return "Seu sabor divide opini�es";
            if (palavraAleatoria == "SAPOTI") return "Nativa do M�xico";
            if (palavraAleatoria == "TANGERINA") return "Possui muitas primas";
            if (palavraAleatoria == "UMBU") return "A polpa � grudada na semente";
            if (palavraAleatoria == "UVA") return "Um milh�o de utilizades";
            else return "Intenso sabor azedo";
        }
    }
}
