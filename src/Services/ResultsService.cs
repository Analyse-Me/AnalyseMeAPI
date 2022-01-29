using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using MongoDB.Driver;

using AnalyseMeAPI.Models;
using AnalyseMeAPI.Helpers;


namespace AnalyseMeAPI.Services {

    public class ResultsService {
        private readonly ResultsHelper ResultsHelper;

        private IMongoCollection<ResultList> DB_ResultsList;
        private IMongoCollection<Result<_Compass>> DB_Compass;
        private IMongoCollection<Result<_8Values>> DB_8Values;
        private IMongoCollection<Result<_9Axes>> DB_9Axes;
        private IMongoCollection<Result<_Soulgraphy_PI>> DB_PoliticalIdeas;
        private IMongoCollection<Result<_Soulgraphy_EFA>> DB_EconomicFreedomAnalysis;
        private IMongoCollection<Result<_Soulgraphy_PFA>> DB_PersonalFreedomAnalysis;
        private IMongoCollection<Result<_MyPolitics>> DB_MyPolitics;

        public ResultsService(IMongoClient client) {
            var database = client.GetDatabase("mo1394_analyseme");

            ResultsHelper = new ResultsHelper(client);

            DB_ResultsList = database.GetCollection<ResultList>("results_list");
            DB_Compass = database.GetCollection<Result<_Compass>>("results_compass");
            DB_8Values = database.GetCollection<Result<_8Values>>("results_8values");
            DB_9Axes = database.GetCollection<Result<_9Axes>>("results_9axes");
            DB_PoliticalIdeas = database.GetCollection<Result<_Soulgraphy_PI>>("results_political_ideas");
            DB_EconomicFreedomAnalysis = database.GetCollection<Result<_Soulgraphy_EFA>>("results_economic_freedom_analysis");
            DB_PersonalFreedomAnalysis = database.GetCollection<Result<_Soulgraphy_PFA>>("results_personal_freedom_analysis");
            DB_MyPolitics = database.GetCollection<Result<_MyPolitics>>("results_mypolitics");
        }

        public string PushPoliticalCompass(ResultRequest<_Compass> body) {
            string ID = ResultsHelper.CreateID(12);
            DB_ResultsList.InsertOne(new ResultList("political_compass", ID));
            DB_Compass.InsertOne(new Result<_Compass>(body.results, ID));
            return ID;
        }

        public string Push8Values(ResultRequest<_8Values> body) {
            string ID = ResultsHelper.CreateID(12);
            DB_ResultsList.InsertOne(new ResultList("8values", ID));
            DB_8Values.InsertOne(new Result<_8Values>(body.results, ID));
            return ID;
        }

        public string Push9Axes(ResultRequest<_9Axes> body) {
            string ID = ResultsHelper.CreateID(12);
            DB_ResultsList.InsertOne(new ResultList("9axes", ID));
            DB_9Axes.InsertOne(new Result<_9Axes>(body.results, ID));
            return ID;
        }
        public string PushPoliticalIdeas(ResultRequest<_Soulgraphy_PI> body) {
            string ID = ResultsHelper.CreateID(12);
            DB_ResultsList.InsertOne(new ResultList("political_ideas", ID));
            DB_PoliticalIdeas.InsertOne(new Result<_Soulgraphy_PI>(body.results, ID));
            return ID;
        }

        public string PushEconomicFreedomAnalysis(ResultRequest<_Soulgraphy_EFA> body) {
            string ID = ResultsHelper.CreateID(12);
            DB_ResultsList.InsertOne(new ResultList("economic_freedom_analysis", ID));
            DB_EconomicFreedomAnalysis.InsertOne(new Result<_Soulgraphy_EFA>(body.results, ID));
            return ID;
        }

        public string PushPersonalFreedomAnalysis(ResultRequest<_Soulgraphy_PFA> body) {
            string ID = ResultsHelper.CreateID(12);
            DB_ResultsList.InsertOne(new ResultList("personal_freedom_analysis", ID));
            DB_PersonalFreedomAnalysis.InsertOne(new Result<_Soulgraphy_PFA>(body.results, ID));
            return ID;
        }

        public string PushMyPolitics(ResultRequest<_MyPolitics> body) {
            string ID = ResultsHelper.CreateID(12);
            DB_ResultsList.InsertOne(new ResultList("mypolitics", ID));
            DB_MyPolitics.InsertOne(new Result<_MyPolitics>(body.results, ID));
            return ID;
        }

    }
}