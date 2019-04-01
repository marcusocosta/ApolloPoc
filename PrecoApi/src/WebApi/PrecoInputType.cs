
using Entity.Preco;
using GraphQL.Types;

namespace WebApi
{
  public class PrecoInputType : InputObjectGraphType<Preco>
  {
    public PrecoInputType()
    {
      Field(x => x.CodigoProduto).Description("Código do produto");

      Field(x => x.Valor).Description("Valor");
    }
  }
}