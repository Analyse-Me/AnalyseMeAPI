using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AnalyseMeAPI.Models {
  public class Ideology < T > {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("name")]
    public string name { get; set; }

    [BsonElement("stats")]
    public T stats { get; set; }
  }
}