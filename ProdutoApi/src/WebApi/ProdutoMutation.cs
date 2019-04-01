using Entity.Produto;
using GraphQL.Types;
using WebApi.Models.Graphql;

namespace WebApi
{
  public class ProdutoMutation : ObjectGraphType
  {
    public ProdutoMutation(IProdutoService service)
    {
      Name = "Mutation";
      Field<ProdutoType>(
         "createProduto",
         arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<ProdutoInputType>> { Name = "produto" }
            ),
         resolve: context =>
         {
             var item = context.GetArgument<Produto>("produto");
             return service.Save(item);
         });
    }
  }
}