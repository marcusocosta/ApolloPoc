using GraphQL;
using GraphQL.Types;
using WebApi.Queries;

namespace WebApi
{
  public class PrecoSchema : Schema
  {
    public PrecoSchema(IDependencyResolver resolver)
        : base(resolver)
    {
      Query = resolver.Resolve<PrecoQuery>();
      Mutation = resolver.Resolve<PrecoMutation>();
    }
  }
}