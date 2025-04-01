namespace JogoDeDadosConsoleApp
{

    internal class Program
    {
        /*
        Versão 3 - Incluir o computador como oponente 
            Informar que o computador está jogando
            Armazenar a posição do computador na pista e atualizar o valor após o lançamento do dado
            Atualizar a posição do computador após seu lançamento de dado            
            Exibir a nova posição
            Verificar se o computador alcançou ou ultrapassou a linha de chegada
            Informar quem venceu o jogo
            Implementar turnos alternados entre jogador e computador
         */
        static void Main(string[] args)
        {
            const int limiteLinhaChegada = 30;

            while (true)
            {
                int posicaoUsuario = 0;
                int posicaoComputador = 0;

                bool jogoEstaEmAndamento = true;

                while(jogoEstaEmAndamento)
                {
                    //Turno do Usuario
                ExibirCabecalho("Usuario");

                int resultado = LacarDados();

                ExibirResultadoSorteio(resultado);

                posicaoUsuario += resultado;

                if (posicaoUsuario >= limiteLinhaChegada)
                    {
                    Console.WriteLine("Parabéns, você alcançou a linha de chegada!");
                        Console.ReadLine();
                        jogoEstaEmAndamento = false;
                        continue;
                    }
                else
                    Console.WriteLine($"O jogador está na posição: {posicaoUsuario} de {limiteLinhaChegada}");

                    Console.Write("Pressione ENTER para continuar");
                    Console.ReadLine();

                    //Turno do Usuario
                    ExibirCabecalho("Computador");

                    int resultadoDoComputador= LacarDados();

                    ExibirResultadoSorteio(resultadoDoComputador);

                    posicaoComputador += resultadoDoComputador;

                    if (posicaoComputador >= limiteLinhaChegada)
                    {
                        Console.WriteLine("Que pena! O computador alcançou a linha de chegada!");
                        Console.ReadLine();
                        jogoEstaEmAndamento = false;
                        continue;
                    }
                    else
                        Console.WriteLine($"0 computador está na posição: {posicaoComputador} de {limiteLinhaChegada}");

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
    }
}
