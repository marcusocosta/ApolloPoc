using Entity.Preco;
using GraphQL.Types;

namespace WebApi.Models.Graphql
{
  public class PrecoType : ObjectGraphType<Preco>
  {
    public PrecoType()
    {
      Name = "preco";
      Field(x => x.CodigoProduto).Description("Código do produto");
      Field(x => x.Valor).Description("Valor");
      Field(x => x.Data).Description("Data");
    }
  }
}