namespace JogoDeDadosConsoleApp
{

    internal class Program
    {
        static void Main(string[] args)
        {
            const int limiteLinhaChegada = 30;

            while (true)
            {
                int posicaoUsuario = 0;
                int posicaoComputador = 0;

                bool jogoEstaEmAndamento = true;

                while (jogoEstaEmAndamento)
                {
                    //Turno do Usuario
                    ExibirCabecalho("Usuario");

                    int resultado = LacarDados();

                    ExibirResultadoSorteio(resultado);

                    int posicaoAnteriorUsuario = posicaoUsuario;

                    posicaoUsuario += resultado;

                    posicaoUsuario = VerificarEventosEspeciais(ref posicaoUsuario, resultado, "Usuario");

                    if (posicaoUsuario >= limiteLinhaChegada)
                    {
                        Console.WriteLine("Parabéns, você alcançou a linha de chegada!");
                        Console.ReadLine();

                        jogoEstaEmAndamento = false;
                        continue;
                    }
                    else
                        Console.WriteLine($"O jogador estava na posição: {posicaoAnteriorUsuario} e foi para a: {posicaoUsuario} de {limiteLinhaChegada}");

                    Console.Write("Pressione ENTER para continuar");
                    Console.ReadLine();

                    //Turno do Computador
                    ExibirCabecalho("Computador");

                    int resultadoDoComputador = LacarDados();

                    ExibirResultadoSorteio(resultadoDoComputador);

                    int posicaoAnteriorComputador = posicaoComputador;

                    posicaoComputador += resultadoDoComputador;

                    posicaoComputador = VerificarEventosEspeciais(ref posicaoComputador, resultadoDoComputador, "Computador");

                    if (posicaoComputador >= limiteLinhaChegada)
                    {
                        Console.WriteLine("Que pena! O computador alcançou a linha de chegada!");
                        Console.ReadLine();

                        jogoEstaEmAndamento = false;
                        continue;
                    }
                    else
                        Console.WriteLine($"O computador estava na posição: {posicaoAnteriorComputador} e foi para a posição: {posicaoComputador} de {limiteLinhaChegada}");

                    Console.Write("Pressione ENTER para continuar");
                    Console.ReadLine();
                }

                string opcaoContinuar = ExibirMenuContinuar();

                if (opcaoContinuar != "S")
                    break;
            }
        }

        static void ExibirCabecalho(string nomeJogador)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Jogo dos Dados");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"Turno do jodador(a): {nomeJogador}");
            Console.WriteLine("-----------------------------------------------");

            if (nomeJogador != "Computador")
            {
                Console.Write("Precione ENTER para lançar o dado...");
                Console.ReadLine();
            }
        }

        static int LacarDados()
        {
            Random geradorDeNumeros = new Random();

            int resultado = geradorDeNumeros.Next(1, 7);

            return resultado;
        }

        static void ExibirResultadoSorteio(int resultado)
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"O valor sorteado foi: {resultado}");
            Console.WriteLine("-----------------------------------------------");
        }

        static string ExibirMenuContinuar()
        {
            Console.Write("Deseja continuar? (s/N)");
            string opcaoContinuar = Console.ReadLine()!.ToUpper();

            return opcaoContinuar;
        }

        static int VerificarEventosEspeciais(ref int posicao, int resultado, string jogador)
        {
            // Avanço extra
            if (posicao == 5 || posicao == 10 || posicao == 15)
            {
                Console.WriteLine($"{jogador} avançou 3 casas!");
                posicao += 3;
            }

            // Recuo
            if (posicao == 7 || posicao == 13 || posicao == 20)
            {
                Console.WriteLine($"{jogador} recuou 2 casas!");
                posicao -= 2;
            }

            // Rodada extra
            if (resultado == 6)
            {
                Console.WriteLine($"O {jogador} tirou 6! Ganha uma rodada extra!");

                Console.Write("Pressione ENTER para lançar o dado novamente...");
                Console.ReadLine();

                int novoResultado = LacarDados();
                ExibirResultadoSorteio(novoResultado);

                posicao += novoResultado;

                posicao = VerificarEventosEspeciais(ref posicao, novoResultado, jogador);
            }

            return posicao;
        }
    }
}
