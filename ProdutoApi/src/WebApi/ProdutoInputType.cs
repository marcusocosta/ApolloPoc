using Entity.Produto;
using GraphQL.Types;

namespace WebApi
{
  public class ProdutoInputType : InputObjectGraphType<Produto>
  {
    public ProdutoInputType()
    {
      Field(x => x.CodigoBarras).Description("Código de Barras");

      Field(x => x.Nome).Description("Nome do produto");

      Field(x => x.Codigo).Description("Codigo");

    }
  }
}