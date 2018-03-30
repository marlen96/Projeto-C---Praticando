using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleApp3
{
    class Pedido
    {
        public int Codigo { get; set; }
        public DateTime data { get; set; }
        public List<ItemPedido> itens { get; set; }

        public Pedido(int codigo,int dia, int mes , int ano)
        {
            Codigo = codigo;
            data = new DateTime(ano, mes, dia);
            itens = new List<ItemPedido>();
        }

        public double ValorTotal() {
            double soma = 0.0;
            foreach(var item in itens)
            {
                soma = soma + item.SubTotal();
            }
            return soma;
        }

        public override string ToString()
        {
            string s = "pedido: " + Codigo
                + " Data: " + data.Day + "/" + data.Month + "/" + data.Year + "\n"
                + "Itens: \n";

            foreach(var item in itens)
            {
                s = s + item + "\n"; 
            }

            s = s + "Total do pedido: " + ValorTotal().ToString("F2", CultureInfo.InvariantCulture);

            return s;
        }
    }
}
