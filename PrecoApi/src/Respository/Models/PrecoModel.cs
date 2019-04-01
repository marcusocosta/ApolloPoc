using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Respository.Models
{
  public class PrecoModel
  {
    public PrecoModel() => Id = ObjectId.GenerateNewId();
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    [BsonElement("CodigoProduto")]
    public int CodigoProduto { get; set; }

    [BsonElement("Valor")]
    public decimal Valor { get; set; }

    [BsonElement("Data")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public DateTime Data { get; set; }
  }
}