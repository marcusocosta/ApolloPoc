using System.Collections.Generic;
using GraphQL;
using GraphQL.Types;
using WebApi.Models.Graphql;

namespace WebApi.Queries
{
  [GraphQLMetadata("preco")]
  public class PrecoQuery : ObjectGraphType
  {
    public PrecoQuery(IPrecoService service)
    {
      Field<ListGraphType<PrecoType>>(
          "precos",
          resolve: context =>
          {
            return service.GetAll();
          });

      Field<PrecoType>(
      "preco",
      arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "codigoProduto" }),
      resolve: context =>
      {
        var preco = service.GetId(context.GetArgument<int>("codigoProduto"));
        return preco;
      });
    }
  }
}