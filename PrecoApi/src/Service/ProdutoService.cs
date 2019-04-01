using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Preco;
using Respository;

namespace Service
{
  public class PrecoService : IPrecoService
  {
    private readonly IPrecoRepository _repository;
    public PrecoService(IPrecoRepository repository)
    {
        _repository = repository;
    }
    public async Task<Preco> GetId(int codigo)
    {
      return await _repository.GetById(codigo);
    }

    public async Task<IList<Preco>> GetAll()
    {
      return await _repository.GetAll();
    }

    public async Task<Preco> Save(Preco Preco)
    {
      return await _repository.Insert(Preco);
    }
  }
}
