using System;

namespace Entity.Preco
{
    public class Preco
    {
        public Preco()
        {
            Data = DateTime.Now;
        }
        public Preco(int codigoProduto, decimal valor)
        {
            CodigoProduto = codigoProduto;
            Valor = valor;
            Data = DateTime.Now;
        }
        public int CodigoProduto { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
