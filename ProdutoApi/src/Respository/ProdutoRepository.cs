using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Produto;
using MongoDB.Driver;
using Respository.Models;
using Respository.Parametros;

namespace Respository
{
  public class ProdutoRepository : IProdutoRepository
  {
    private readonly IMongoCollection<ProdutoModel> _produtos;
    private readonly IMapper _mapper;

    public ProdutoRepository(IMapper mapper, DataBaseConnectionParams parametros)
    {
      _mapper = mapper;
      var client = new MongoClient(parametros.ConnectionUrl);
      var database = client.GetDatabase(parametros.DataBaseName);
      _produtos = database.GetCollection<ProdutoModel>(parametros.ProdutoCollection);
    }
    public async Task<IList<Produto>> GetAll()
    {
      var produtos = await _produtos.FindAsync(produto => true);
      return _mapper.Map<IList<Produto>>(produtos.ToList());
    }

    public async Task<Produto> GetById(int codigo)
    {
      var produtos = await _produtos.FindAsync(produto => produto.Codigo ==  codigo);
      var produtoList = _mapper.Map<IList<Produto>>(produtos.ToList());
      if (produtoList.Count == 0)
        return null;

      return _mapper.Map<Produto>(produtoList.First());
    }

    public async Task<Produto> Insert(Produto produto)
    {
      var produtoModel = _mapper.Map<ProdutoModel>(produto);
      await _produtos.InsertOneAsync(produtoModel);

      return produto;
    }
  }
}
