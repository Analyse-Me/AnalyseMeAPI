using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using MongoDB.Driver;

using AnalyseMeAPI.Models;

namespace AnalyseMeAPI.Services {

  public class ResultsService {
    private IMongoCollection < ResultList > DB_ResultsList;
    private IMongoCollection < Result < _Compass >> DB_Compass;
    private IMongoCollection < Result < _8Values >> DB_8Values;
    private IMongoCollection < Result < _9Axes >> DB_9Axes;
    private IMongoCollection < Result < _Soulgraphy_PI >> DB_PoliticalIdeas;
    private IMongoCollection < Result < _Soulgraphy_EFA >> DB_EconomicFreedomAnalysis;
    private IMongoCollection < Result < _Soulgraphy_PFA >> DB_PersonalFreedomAnalysis;
    private IMongoCollection < Result < _MyPolitics >> DB_MyPolitics;

    private static Random random = new Random();

    public ResultsService(IMongoClient client) {
      var database = client.GetDatabase("mo1394_analyseme");

      DB_ResultsList = database.GetCollection < ResultList > ("results_list");
      DB_Compass = database.GetCollection < Result < _Compass >> ("results_political_compass");
      DB_8Values = database.GetCollection < Result < _8Values >> ("results_8values");
      DB_9Axes = database.GetCollection < Result < _9Axes >> ("results_9axes");
      DB_PoliticalIdeas = database.GetCollection < Result < _Soulgraphy_PI >> ("results_political_ideas");
      DB_EconomicFreedomAnalysis = database.GetCollection < Result < _Soulgraphy_EFA >> ("results_economic_freedom_analysis");
      DB_PersonalFreedomAnalysis = database.GetCollection < Result < _Soulgraphy_PFA >> ("results_personal_freedom_analysis");
      DB_MyPolitics = database.GetCollection < Result < _MyPolitics >> ("results_mypolitics");
    }
    
    private string CreateID(int length) {
      const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
      string ID;

      while (true) {
        ID = ID = new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());

        var res = DB_ResultsList.Find(e => e.ResultID == ID).ToList();
        if (res.Count == 0) break;
      }

      return ID;
    }

    public dynamic GetResults(string ID) {
      List < ResultList > headers = DB_ResultsList.Find(item => item.ResultID == ID).ToList();

      if (headers.Count == 0) return null;

      switch (headers[0].quiz) {
        case ("political_compass"):           return DB_Compass.Find(res => res.ResultID == ID).ToList()[0];
        case ("8values"):                     return DB_8Values.Find(res => res.ResultID == ID).ToList()[0];
        case ("9axes"):                       return DB_9Axes.Find(res => res.ResultID == ID).ToList()[0];
        case ("political_ideas"):             return DB_PoliticalIdeas.Find(res => res.ResultID == ID).ToList()[0];
        case ("economic_freedom_analysis"):   return DB_EconomicFreedomAnalysis.Find(res => res.ResultID == ID).ToList()[0];
        case ("personal_freedom_analysis"):   return DB_PersonalFreedomAnalysis.Find(res => res.ResultID == ID).ToList()[0];
        case ("mypolitics"):                  return DB_MyPolitics.Find(res => res.ResultID == ID).ToList()[0];

        default:                              return null;
      }
    }

    public string PushPoliticalCompass(ResultRequest < _Compass > body) {
      string ID = this.CreateID(12);
      DB_ResultsList.InsertOne(new ResultList("political_compass", ID));
      DB_Compass.InsertOne(new Result < _Compass > (body.results, ID, "political_compass"));
      return ID;
    }

    public string Push8Values(ResultRequest < _8Values > body) {
      string ID = this.CreateID(12);
      DB_ResultsList.InsertOne(new ResultList("8values", ID));
      DB_8Values.InsertOne(new Result < _8Values > (body.results, ID, "8values"));
      return ID;
    }

    public string Push9Axes(ResultRequest < _9Axes > body) {
      string ID = this.CreateID(12);
      DB_ResultsList.InsertOne(new ResultList("9axes", ID));
      DB_9Axes.InsertOne(new Result < _9Axes > (body.results, ID, "9axes"));
      return ID;
    }
    public string PushPoliticalIdeas(ResultRequest < _Soulgraphy_PI > body) {
      string ID = this.CreateID(12);
      DB_ResultsList.InsertOne(new ResultList("political_ideas", ID));
      DB_PoliticalIdeas.InsertOne(new Result < _Soulgraphy_PI > (body.results, ID, "political_ideas"));
      return ID;
    }

    public string PushEconomicFreedomAnalysis(ResultRequest < _Soulgraphy_EFA > body) {
      string ID = this.CreateID(12);
      DB_ResultsList.InsertOne(new ResultList("economic_freedom_analysis", ID));
      DB_EconomicFreedomAnalysis.InsertOne(new Result < _Soulgraphy_EFA > (body.results, ID, "economic_freedom_analysis"));
      return ID;
    }

    public string PushPersonalFreedomAnalysis(ResultRequest < _Soulgraphy_PFA > body) {
      string ID = this.CreateID(12);
      DB_ResultsList.InsertOne(new ResultList("personal_freedom_analysis", ID));
      DB_PersonalFreedomAnalysis.InsertOne(new Result < _Soulgraphy_PFA > (body.results, ID, "personal_freedom_analysis"));
      return ID;
    }

    public string PushMyPolitics(ResultRequest < _MyPolitics > body) {
      string ID = this.CreateID(12);
      DB_ResultsList.InsertOne(new ResultList("mypolitics", ID));
      DB_MyPolitics.InsertOne(new Result < _MyPolitics > (body.results, ID, "mypolitics"));
      return ID;
    }
  }
}