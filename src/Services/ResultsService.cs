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
        private IMongoCollection<ResultList> DB_ResultsList;
        private IMongoCollection<Result<_Compass>> DB_Results_Compass;

        public ResultsService(IMongoClient client) {
            var database = client.GetDatabase("mo1394_analyseme");

            DB_ResultsList = database.GetCollection<ResultList>("results_list");
            DB_Results_Compass = database.GetCollection<Result<_Compass>>("results_compass");
        }

        public string PushPoliticalCompass(ResultRequest<_Compass> body) {
            string ID = ResultsHelper.CreateID(12);
            DB_ResultsList.InsertOne(new ResultList("political_compass", ID));
            // DB_Results.Find(_ => true).ToList();
            return ID;
        }
    }
}