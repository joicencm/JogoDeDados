namespace JogoDeDadosConsoleApp
{

    internal class Program
    {
        /*
         Versão 2 - Controle da posição do jogador 
            Armazenar a posição do jogador na pista e atualizar o valor após o lançamento do dado
            Exibir a posição atual do jogador na pista
            Definir a linha de chegada em 30 verificar se o jogador alcançou ou ultrapassou a linha de chegada
            Permitir o jogador realizar várias jogadas
         */
        static void Main(string[] args)
        {
            const int limiteLinhaChegada = 30;

            while (true)
            {
                int posicaoUsuario = 0;
                bool jogoEstaEmAndamento = true;

                while(jogoEstaEmAndamento)
                {

                ExibirCabecalho();

                int resultado = LacarDados();

                ExibirResultadoSorteio(resultado);

                posicaoUsuario += resultado;

                if (posicaoUsuario >= limiteLinhaChegada)
                    {
                    Console.WriteLine("Parabéns, você alcançou a linha de chegada!");
                        jogoEstaEmAndamento = false;
                    }
                else
                    Console.WriteLine($"Ojogador está na posição: {posicaoUsuario} de {limiteLinhaChegada}");

                    Console.Write("Pressione ENTER para continuar");
                    Console.ReadLine();
                }

                string opcaoContinuar = ExibirMenuContinuar();

                if (opcaoContinuar != "S")
                    break;
            }
        }

        static void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Jogo dos Dados");
            Console.WriteLine("-----------------------------------------------");

            Console.Write("Precione ENTER para lançar o dado...");
            Console.ReadLine();
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
