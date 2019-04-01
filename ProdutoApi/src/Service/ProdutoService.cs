using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Produto;
using Respository;

namespace Service
{
  public class ProdutoService : IProdutoService
  {
    private readonly IProdutoRepository _repository;
    public ProdutoService(IProdutoRepository repository)
    {
        _repository = repository;
    }
    public async Task<Produto> GetId(int codigo)
    {
      return await _repository.GetById(codigo);
    }

    public async Task<IList<Produto>> GetAll()
    {
      return await _repository.GetAll();
    }

    public async Task<Produto> Save(Produto produto)
    {
      var hasProduct = await _repository.GetById(produto.Codigo);
      if(hasProduct != null)
      {
        throw new Exception("Codigo de produto já exitente");
      }
      return await _repository.Insert(produto);
    }
  }
}
