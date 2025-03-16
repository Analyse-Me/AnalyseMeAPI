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

  public class QuestionsService {
    private string DB_Compass;
    private string DB_8Values;
    private string DB_9Axes;
    private string DB_PoliticalIdeas;
    private string DB_EconomicFreedomAnalysis;
    private string DB_PersonalFreedomAnalysis;
    // private IMongoCollection < Question < _MyPolitics >> DB_MyPolitics;

    public QuestionsService() {

      DB_Compass = File.ReadAllText("./src/Static/Questions/compass.txt"); //  < Question < _Compass >>
      DB_8Values = File.ReadAllText("./src/Static/Questions/8values.txt");
      DB_9Axes = File.ReadAllText("./src/Static/Questions/9axes.txt");
      DB_PoliticalIdeas = File.ReadAllText("./src/Static/Questions/political_ideas.txt");
      DB_EconomicFreedomAnalysis = File.ReadAllText("./src/Static/Questions/economic_freedom_analysis.txt");
      DB_PersonalFreedomAnalysis = File.ReadAllText("./src/Static/Questions/personal_freedom_analysis.txt");
      // DB_MyPolitics = database.GetCollection < Question < _MyPolitics >> ("questions_mypolitics");
    }

    public string GetCompass() {
      return DB_Compass;
    }


    public string Get8Values() {
      return DB_8Values;
    }


    public string Get9Axes() {
      return DB_9Axes;
    }


    public string GetPoliticalIdeas() {
      return DB_PoliticalIdeas;
    }


    public string GetEconomicFreedomAnalysis() {
      return DB_EconomicFreedomAnalysis;
    }


    public string GetPersonalFreedomAnalysis() {
      return DB_PersonalFreedomAnalysis;
    }
  }
}