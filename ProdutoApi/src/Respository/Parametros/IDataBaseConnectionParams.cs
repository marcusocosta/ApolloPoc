namespace Respository.Parametros
{
  public interface IDataBaseConnectionParams
  {
    string ConnectionUrl { get; set; }
    string DataBaseName { get; set; }

    string ProdutoCollection { get; set; }
  }
}