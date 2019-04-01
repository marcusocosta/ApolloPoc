using System.Collections.Generic;
using Entity.Produto;
using GraphQL;
using GraphQL.Types;
using WebApi.Models.Graphql;

namespace WebApi.Queries
{
  [GraphQLMetadata("produto")]
  public class ProdutoQuery : ObjectGraphType
  {
    public ProdutoQuery(IProdutoService service)
    {
      Field<ListGraphType<ProdutoType>>(
          "produtos",
          resolve: context =>
          {
            return service.GetAll();
          });

      Field<ProdutoType>(
      "produto",
      arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "codigo" }),
      resolve: context =>
      {
        var produto = service.GetId(context.GetArgument<int>("codigo"));
        return produto;
      });
    }
  }
}