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

        private IMongoCollection<Question<_Compass>> DB_Compass;
        private IMongoCollection<Question<_8Values>> DB_8Values;
        private IMongoCollection<Question<_9Axes>> DB_9Axes;
        private IMongoCollection<Question<_Soulgraphy_PI>> DB_PoliticalIdeas;
        private IMongoCollection<Question<_Soulgraphy_EFA>> DB_EconomicFreedomAnalysis;
        private IMongoCollection<Question<_Soulgraphy_PFA>> DB_PersonalFreedomAnalysis;
        private IMongoCollection<Question<_MyPolitics>> DB_MyPolitics;

        public QuestionsService(IMongoClient client) {
            var database = client.GetDatabase("mo1394_analyseme");

            DB_Compass = database.GetCollection<Question<_Compass>>("questions_political_compass");
            DB_8Values = database.GetCollection<Question<_8Values>>("questions_8values");
            DB_9Axes = database.GetCollection<Question<_9Axes>>("questions_9axes");
            DB_PoliticalIdeas = database.GetCollection<Question<_Soulgraphy_PI>>("questions_political_ideas");
            DB_EconomicFreedomAnalysis = database.GetCollection<Question<_Soulgraphy_EFA>>("questions_economic_freedom_analysis");
            DB_PersonalFreedomAnalysis = database.GetCollection<Question<_Soulgraphy_PFA>>("questions_personal_freedom_analysis");
            DB_MyPolitics = database.GetCollection<Question<_MyPolitics>>("questions_mypolitics");
        }

        public IEnumerable<Question<_Compass>> GetCompass() {
            return DB_Compass.Find(_ => true).ToList();
        }
        public IEnumerable<Question<_8Values>> Get8Values() {
            return DB_8Values.Find(_ => true).ToList();
        }
        public IEnumerable<Question<_9Axes>> Get9Axes() {
            return DB_9Axes.Find(_ => true).ToList();
        }
        public IEnumerable<Question<_Soulgraphy_PI>> GetPoliticalIdeas() {
            return DB_PoliticalIdeas.Find(_ => true).ToList();
        }
        public IEnumerable<Question<_Soulgraphy_EFA>> GetEconomicFreedomAnalysis() {
            return DB_EconomicFreedomAnalysis.Find(_ => true).ToList();
        }
        public IEnumerable<Question<_Soulgraphy_PFA>> GetPersonalFreedomAnalysis() {
            return DB_PersonalFreedomAnalysis.Find(_ => true).ToList();
        }
        public IEnumerable<Question<_MyPolitics>> GetMyPolitics() {
            return DB_MyPolitics.Find(_ => true).ToList();
        }
    }
}