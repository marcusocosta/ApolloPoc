using GraphQL;
using GraphQL.Types;
using WebApi.Queries;

namespace WebApi
{
  public class ProdutoSchema : Schema
  {
    public ProdutoSchema(IDependencyResolver resolver)
        : base(resolver)
    {
      Query = resolver.Resolve<ProdutoQuery>();
      Mutation = resolver.Resolve<ProdutoMutation>();
    }
  }
}