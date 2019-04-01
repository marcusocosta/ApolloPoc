using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Respository.Models
{
  public class ProdutoModel
  {
    public ProdutoModel() => Id = ObjectId.GenerateNewId();
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    [BsonElement("Codigo")]
    public int Codigo { get; set; }

    [BsonElement("Nome")]
    public string Nome { get; set; }

    [BsonElement("CodigoBarras")]
    public string CodigoBarras { get; set; }
  }
}