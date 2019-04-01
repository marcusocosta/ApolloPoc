using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Preco;
using MongoDB.Driver;
using Respository.Models;
using Respository.Parametros;

namespace Respository
{
  public class PrecoRepository : IPrecoRepository
  {
    private readonly IMongoCollection<PrecoModel> _precos;
    private readonly IMapper _mapper;

    public PrecoRepository(IMapper mapper, DataBaseConnectionParams parametros)
    {
      _mapper = mapper;
      var client = new MongoClient(parametros.ConnectionUrl);
      var database = client.GetDatabase(parametros.DataBaseName);
      _precos = database.GetCollection<PrecoModel>(parametros.PrecoCollection);
    }
    public async Task<IList<Preco>> GetAll()
    {
      var precos = await _precos.FindAsync(produto => true);
      return _mapper.Map<IList<Preco>>(precos.ToList());
    }

    public async Task<Preco> GetById(int codigoProduto)
    {
      var precos = await _precos.FindAsync(produto => produto.CodigoProduto ==  codigoProduto);
      var precoList = _mapper.Map<IList<Preco>>(precos.ToList());
      if (precoList.Count == 0)
        return null;

      return _mapper.Map<Preco>(precoList.First());
    }

    public async Task<Preco> Insert(Preco preco)
    {
      var precoModel = _mapper.Map<PrecoModel>(preco);
      await _precos.InsertOneAsync(precoModel);

      return preco;
    }
  }
}
