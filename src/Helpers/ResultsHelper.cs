using System;
using System.Linq;
using MongoDB.Driver;
using AnalyseMeAPI.Models;

namespace AnalyseMeAPI.Helpers {
    public class ResultsHelper {

        private IMongoCollection<ResultList> DB_ResultsList;
        private static Random random = new Random();

        public ResultsHelper(IMongoClient client) {
            var database = client.GetDatabase("mo1394_analyseme");
            DB_ResultsList = database.GetCollection<ResultList>("results_list");
        }

        public string CreateID(int length) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string ID;
            while (true) {
                ID = ID = new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

                var res = DB_ResultsList.Find(e => e.ID == ID).ToList();
                if (res.Count == 0) break;
            }
            
            return ID;
        }
    }
}