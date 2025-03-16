using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

using MongoDB.Driver;

using AnalyseMeAPI.Models;

namespace AnalyseMeAPI.Services {

  public class IdeologiesService {
    private string DB_8Values;

    public IdeologiesService() {
      DB_8Values = File.ReadAllText("./src/Static/Ideologies/8values.txt");

      // DB_9Axes = database.GetCollection<Ideology<_9Axes>>("ideologies_9axes");
      // DB_PoliticalIdeas = database.GetCollection<Ideology<_Soulgraphy_PI>>("ideologies_political_ideas");
      // DB_EconomicFreedomAnalysis = database.GetCollection<Ideology<_Soulgraphy_EFA>>("ideologies_economic_freedom_analysis");
      // DB_MyPolitics = database.GetCollection<Ideology<_MyPolitics>>("ideologies_mypolitics");
    }

    public string Get8Values() {
      return DB_8Values;
    }
    // public IEnumerable<Ideology<_9Axes>> Get9Axes()
    // {
    //   return DB_9Axes.Find(_ => true).ToList();
    // }
    // public IEnumerable<Ideology<_Soulgraphy_PI>> GetPoliticalIdeas()
    // {
    //   return DB_PoliticalIdeas.Find(_ => true).ToList();
    // }
    // public IEnumerable<Ideology<_Soulgraphy_EFA>> GetEconomicFreedomAnalysis()
    // {
    //   return DB_EconomicFreedomAnalysis.Find(_ => true).ToList();
    // }
    // public IEnumerable<Ideology<_MyPolitics>> GetMyPolitics()
    // {
    //   return DB_MyPolitics.Find(_ => true).ToList();
    // }
  }
}