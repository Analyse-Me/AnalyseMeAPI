using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AnalyseMeAPI.Models {
    public class Question<T> {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("question")]
        public string question { get; set; }

        [BsonElement("effect")]
        public T effect { get; set; }
    }
}
