using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using MongoDB.Driver;

using AnalyseMeAPI.Models;

namespace AnalyseMeAPI.Services {
    public class QuestionsService {
        private IMongoCollection<Question<_8Values>> DB_8Values;

        public QuestionsService(IMongoClient client) {
            var database = client.GetDatabase("mo1394_analyseme");
            DB_8Values = database.GetCollection<Question<_8Values>>("questions_8values_en");
        }

        public IEnumerable<Question<_8Values>> Get8Values() {
            var client = new MongoClient("mongodb://mo1394_analyseme:LuMUFbL2YX7IO4aYehDr@mongo51.mydevil.net:27017/mo1394_analyseme");
            

            return DB_8Values.Find(_ => true).ToList();

            // return new Question<_8Values>[] {new Question<_8Values>() {
            //     question = "",
            //     effect = {
            //         econ = 4,
            //         dipl = 4,
            //         govt = -3,
            //         scty = 2,
            //     }
            // }};
        }
    }
}