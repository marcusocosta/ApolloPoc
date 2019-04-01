using Entity.Produto;
using GraphQL.Types;

namespace WebApi.Models.Graphql
{
  public class ProdutoType : ObjectGraphType<Produto>
  {
    public ProdutoType()
    {
      Name = "produto";
      Field(x => x.CodigoBarras).Description("Código de Barras");
      Field(x => x.Nome).Description("Nome do produto");
      Field(x => x.Codigo).Description("Codigo");
    }
  }
}