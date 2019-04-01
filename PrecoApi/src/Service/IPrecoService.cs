using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Preco;

public interface IPrecoService
{
    Task<Preco> GetId(int codigoProduto);
    Task<IList<Preco>> GetAll();
    Task<Preco> Save(Preco preco);


}