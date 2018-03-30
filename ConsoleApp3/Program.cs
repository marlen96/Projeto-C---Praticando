using System;
using System.Collections.Generic;


namespace ConsoleApp3
{
    class Program
    {

        public static List<Produto> produtos = new List<Produto>();
        public static List<Pedido> pedidos = new List<Pedido>();

        static void Main(string[] args)
        {

            int Opcao = 0;

            produtos.Add(new Produto(1001, "Cadeira Simples", 500.00));
            produtos.Add(new Produto(1002, "Cadeira Acolchoada", 900.00));
            produtos.Add(new Produto(1003, "sofá de três lugares", 2000.00));
            produtos.Add(new Produto(1004, "Mesa Retangular", 1500.00));
            produtos.Add(new Produto(1005, "Mesa Retangular", 2000.00));
            produtos.Sort();

            while (Opcao != 5)
            {
                Console.Clear();
                Tela.MostrarMenu();

                try
                {
                    Opcao = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro Inesperado !." + e.Message);
                    Opcao = 0;
                }
                Console.WriteLine();
                switch(Opcao){
                    case 1:
                        Tela.MostrarProdutos();
                        break;

                    case 2:
                        try
                        {
                            Tela.CadastrarProduto();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Erro Inesperado !." + e.Message);
                        }
                        break;

                    case 3:
                        try
                        {
                            Tela.CadastrarPedido();
                        }
                        catch (ModelException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("erro inesperado !." + e.Message);
                        }
                        break;

                    case 4:
                        try
                        {
                            Tela.mostrarPedido();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("erro inesperado !." + e.Message);
                        }
                        break;

                    case 5:
                        Console.WriteLine("Fim da Execução do programa !");
                        break;

                    default:
                        Console.WriteLine("Opção Invalida!");
                            break;
                }
                Console.ReadLine();
            }
        }
    }
}
