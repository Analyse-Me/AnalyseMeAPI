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

        private IMongoCollection<Question<_Compass>> DB_Compass_EN;
        private IMongoCollection<Question<_Compass>> DB_Compass_PL;
        private IMongoCollection<Question<_8Values>> DB_8Values_EN;
        private IMongoCollection<Question<_8Values>> DB_8Values_PL;
        private IMongoCollection<Question<_Soulgraphy_PI>> DB_PoliticalIdeas_PL;

        public QuestionsService(IMongoClient client) {
            var database = client.GetDatabase("mo1394_analyseme");
            DB_Compass_EN = database.GetCollection<Question<_Compass>>("questions_compass_en");
            DB_Compass_PL = database.GetCollection<Question<_Compass>>("questions_compass_pl");
            DB_8Values_EN = database.GetCollection<Question<_8Values>>("questions_8values_en");
            DB_8Values_PL = database.GetCollection<Question<_8Values>>("questions_8values_pl");
            DB_PoliticalIdeas_PL = database.GetCollection<Question<_Soulgraphy_PI>>("questions_politicalideas_pl");
        }

        public IEnumerable<Question<_Compass>> GetCompassEN() {
            return DB_Compass_EN.Find(_ => true).ToList();
        }
        public IEnumerable<Question<_Compass>> GetCompassPL() {
            return DB_Compass_PL.Find(_ => true).ToList();
        }
        public IEnumerable<Question<_8Values>> Get8ValuesEN() {
            return DB_8Values_EN.Find(_ => true).ToList();
        }
        public IEnumerable<Question<_8Values>> Get8ValuesPL() {
            return DB_8Values_PL.Find(_ => true).ToList();
        }
        public IEnumerable<Question<_Soulgraphy_PI>> GetPoliticalIdeasPL() {
            return DB_PoliticalIdeas_PL.Find(_ => true).ToList();
        }
    }
}