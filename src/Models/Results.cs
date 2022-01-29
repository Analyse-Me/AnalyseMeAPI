using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AnalyseMeAPI.Models {
    public class ResultRequest<T> {
        public string quiz { get; set; }
        public T results { get; set; }
    }

    public class ResultList {

        public ResultList(string name, string id) {
            this.quiz = name;
            this.ID = id;
        }
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("quiz")]
        public string quiz { get; set; }

        [BsonElement("ID")]
        public string ID { get; set; }
    }

    public class Result<T> {
        public Result(T results, string ID) {
            this.results = results;
            this.ID = ID;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("ID")]
        public string ID { get; set; }

        // [BsonElement("user")]
        // public string question { get; set; }

        [BsonElement("results")]
        public T results { get; set; }
    }
}