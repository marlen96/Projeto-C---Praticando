using System;
using System.Globalization;

namespace ConsoleApp3
{
    class Tela
    {
        public static void MostrarMenu()
        {
            Console.WriteLine("1 - Listar produtos ordeadamente");
            Console.WriteLine("2 - Cadastrar Produto");
            Console.WriteLine("3 - Cadastrar pedido");
            Console.WriteLine("4 - mostrar dados de um pedido");
            Console.WriteLine("5 - sair");
            Console.WriteLine("Digite uma opção: ");
        }

        public static void MostrarProdutos()
        {
            foreach(var produto in Program.produtos)
            {
                Console.WriteLine(produto);
            }
        }

        public static void CadastrarProduto()
        {
            Console.WriteLine("digite os dados do produto: ");
            Console.Write("codigo: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("descrição: ");
            string descricao = Console.ReadLine();
            Console.Write("preço: ");
            double praco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Produto p = new Produto(codigo, descricao, praco);
            Program.produtos.Add(p);
            Program.produtos.Sort();
        }

        public static void CadastrarPedido()
        {
            Console.WriteLine("digite os dados do pedido: ");
            Console.Write("código: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("dia: ");
            int dia = int.Parse(Console.ReadLine());
            Console.Write("mes: ");
            int mes = int.Parse(Console.ReadLine());
            Console.Write("Ano: ");
            int ano = int.Parse(Console.ReadLine());

            Pedido p = new Pedido(codigo, dia, mes, ano);
            
            Console.Write("quantos itens tem o pedido? ");
            int quantidade = int.Parse(Console.ReadLine());

            for(int i = 0; i < quantidade; i++)
            {
                Console.WriteLine("Digite os dados do "+  (i+1) +"° item: ");
                Console.Write("produto (Código): ");
                int pcodigo = int.Parse(Console.ReadLine());
                int pos = Program.produtos.FindIndex(x => x.Codigo == pcodigo);

                if(pos == -1)
                {
                    throw new ModelException("código de produto não encontrado: " + pcodigo);
                }

                Console.Write("quantidade: ");
                int qte = int.Parse(Console.ReadLine());
                Console.Write("porcentagem de desconto: ");
                double desconto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                ItemPedido ip = new ItemPedido(qte, desconto, Program.produtos[pos], p);
                p.itens.Add(ip);
            }

            Program.pedidos.Add(p);
        }

        public static void mostrarPedido()
        {
            Console.WriteLine("digite o código do pedido: ");
            int codigo = int.Parse(Console.ReadLine());
            int pos = Program.pedidos.FindIndex(x => x.Codigo == codigo);
            if (pos == -1)
            {
                throw new ModelException("código de pedido não encontrado: " + codigo);
            }
            Console.WriteLine(Program.pedidos[pos]);
            Console.WriteLine();

        }
    }
}
