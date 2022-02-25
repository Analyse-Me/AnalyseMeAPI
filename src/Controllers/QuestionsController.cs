using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using MongoDB.Driver;

using AnalyseMeAPI.Models;
using AnalyseMeAPI.Services;

namespace AnalyseMeAPI.Controllers {
  
  [ApiController]
  [Route("questions")]
  public class QuestionsController: ControllerBase {

    private readonly ILogger < QuestionsController > Logger;
    private readonly QuestionsService QuestionsService;

    public QuestionsController(ILogger <QuestionsController> logger, IMongoClient client) {
      Logger = logger;
      QuestionsService = new QuestionsService(client);
    }

    [HttpGet("political_compass")]
    public IEnumerable < Question < _Compass >> GetCompass() {
      return QuestionsService.GetCompass();
    }

    [HttpGet("8values")]
    public IEnumerable < Question < _8Values >> Get8Values() {
      return QuestionsService.Get8Values();
    }

    [HttpGet("9axes")]
    public IEnumerable < Question < _9Axes >> Get9Axes() {
      return QuestionsService.Get9Axes();
    }

    [HttpGet("political_ideas")]
    public IEnumerable < Question < _Soulgraphy_PI >> GetPoliticalIdeas() {
      return QuestionsService.GetPoliticalIdeas();
    }

    [HttpGet("economic_freedom_analysis")]
    public IEnumerable < Question < _Soulgraphy_EFA >> GetEconomicFreedomAnalysis() {
      return QuestionsService.GetEconomicFreedomAnalysis();
    }

    [HttpGet("personal_freedom_analysis")]
    public IEnumerable < Question < _Soulgraphy_PFA >> GetPersonalFreedomAnalysis() {
      return QuestionsService.GetPersonalFreedomAnalysis();
    }

    [HttpGet("mypolitics")]
    public IEnumerable < Question < _MyPolitics >> GetMyPolitics() {
      return QuestionsService.GetMyPolitics();
    }

  }
}