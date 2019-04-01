using Entity.Preco;
using GraphQL.Types;
using WebApi.Models.Graphql;

namespace WebApi
{
  public class PrecoMutation : ObjectGraphType
  {
    public PrecoMutation(IPrecoService service)
    {
      Name = "Mutation";
      Field<PrecoType>(
         "createPreco",
         arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<PrecoInputType>> { Name = "preco" }
            ),
         resolve: context =>
         {
             var item = context.GetArgument<Preco>("preco");
             return service.Save(item);
         });
    }
  }
}