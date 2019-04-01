using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Produto;

namespace Respository
{
    public interface IProdutoRepository
    {
        Task<IList<Produto>> GetAll();

        Task<Produto> GetById(int codigo);

        Task<Produto> Insert(Produto produto);
    }
}