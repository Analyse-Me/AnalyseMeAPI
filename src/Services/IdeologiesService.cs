using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

using MongoDB.Driver;

using AnalyseMeAPI.Models;

namespace AnalyseMeAPI.Services {

  public class IdeologiesService {
    private IMongoCollection < Ideology < _8Values >> DB_8Values;
    private IMongoCollection < Ideology < _9Axes >> DB_9Axes;
    private IMongoCollection < Ideology < _Soulgraphy_PI >> DB_PoliticalIdeas;
    private IMongoCollection < Ideology < _Soulgraphy_EFA >> DB_EconomicFreedomAnalysis;
    private IMongoCollection < Ideology < _MyPolitics >> DB_MyPolitics;

    public IdeologiesService(IMongoClient client) {
      var database = client.GetDatabase("mo1394_analyseme");

      DB_8Values = database.GetCollection < Ideology < _8Values >> ("ideologies_8values");
      DB_9Axes = database.GetCollection < Ideology < _9Axes >> ("ideologies_9axes");
      DB_PoliticalIdeas = database.GetCollection < Ideology < _Soulgraphy_PI >> ("ideologies_political_ideas");
      DB_EconomicFreedomAnalysis = database.GetCollection < Ideology < _Soulgraphy_EFA >> ("ideologies_economic_freedom_analysis");
      DB_MyPolitics = database.GetCollection < Ideology < _MyPolitics >> ("ideologies_mypolitics");
    }

    public IEnumerable < Ideology < _8Values >> Get8Values() {
      return DB_8Values.Find(_ => true).ToList();
    }
    public IEnumerable < Ideology < _9Axes >> Get9Axes() {
      return DB_9Axes.Find(_ => true).ToList();
    }
    public IEnumerable < Ideology < _Soulgraphy_PI >> GetPoliticalIdeas() {
      return DB_PoliticalIdeas.Find(_ => true).ToList();
    }
    public IEnumerable < Ideology < _Soulgraphy_EFA >> GetEconomicFreedomAnalysis() {
      return DB_EconomicFreedomAnalysis.Find(_ => true).ToList();
    }
    public IEnumerable < Ideology < _MyPolitics >> GetMyPolitics() {
      return DB_MyPolitics.Find(_ => true).ToList();
    }
  }
}