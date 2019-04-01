using System;

namespace Entity.Produto
{
    public class Produto
    {
        public Produto()
        {
            
        }
        public Produto(int codigo, string nome, string codigoBarras)
        {
            Codigo = codigo;
            Nome = nome;
            CodigoBarras = codigoBarras;
        }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string CodigoBarras { get; set; }
    }
}
