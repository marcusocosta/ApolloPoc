using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Produto;
public interface IProdutoService
{
    Task<Produto> GetId(int codigo);
    Task<IList<Produto>> GetAll();
    Task<Produto> Save(Produto produto);


}