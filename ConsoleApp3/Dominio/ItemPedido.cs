using System.Globalization;

namespace ConsoleApp3
{
    class ItemPedido
    {
        public int Quantidade { get; set; }
        public double PorcentagemDesconto { get; set; }
        public Produto produto { get; set; }
        public Pedido pedido{ get; set; }

        public ItemPedido(int quantidade, double porcentagemDesconto, Produto produto, Pedido pedido)
        {
            Quantidade = quantidade;
            PorcentagemDesconto = porcentagemDesconto;
            this.produto = produto;
            this.pedido = pedido;
        }

        public double SubTotal()
        {
            return ((produto.Preco - (produto.Preco * (PorcentagemDesconto / 100))) * Quantidade );
        }

        public override string ToString()
        {
            return produto.Descricao
                + ", preço: "
                + produto.Preco.ToString("F2", CultureInfo.InvariantCulture)
                + ", Qte: "
                + Quantidade
                + ", Desconto: "
                + PorcentagemDesconto.ToString("F1", CultureInfo.InvariantCulture)
                + "%, Subtotal: "
                + SubTotal().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
