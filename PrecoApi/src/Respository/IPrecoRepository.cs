using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Preco;

namespace Respository
{
    public interface IPrecoRepository
    {
        Task<IList<Preco>> GetAll();

        Task<Preco> GetById(int codigoProduto);

        Task<Preco> Insert(Preco preco);
    }
}