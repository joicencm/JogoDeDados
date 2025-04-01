namespace JogoDeDadosConsoleApp
{

    internal class Program
    {
        /*
         Versão 1 - Estrutura básica e simulação de dados 
            Requisitos:

            Exibir um banner para o jogo de dados
            Implementar a geração de números aleatórios para simular um dado (1-6)
            Exibir o resultado do lançamento do dado
            Permitir que o usuário pressione Enter para lançar o dado
         */
        static void Main(string[] args)
        {
            while (true)
            {
                ExibirCabecalho();

                int resultado = LacarDados();

                ExibirResultadoSorteio(resultado);

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
