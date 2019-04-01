namespace Respository.Parametros
{
  public class DataBaseConnectionParams : IDataBaseConnectionParams
  {
    public string ConnectionUrl { get; set; }
    public string DataBaseName { get; set; }
    public string ProdutoCollection { get; set; }
  }
}