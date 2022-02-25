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
  [Route("ideologies")]
  public class IdeologiesController: ControllerBase {
    private readonly ILogger < QuestionsController > Logger;
    private readonly IdeologiesService IdeologiesService;

    public IdeologiesController(ILogger <QuestionsController> logger, IMongoClient client) {
      Logger = logger;
      IdeologiesService = new IdeologiesService(client);
    }

    [HttpGet("8values")]
    public IEnumerable < Ideology < _8Values >> Get8Values() {
      return IdeologiesService.Get8Values();
    }

    [HttpGet("9axes")]
    public IEnumerable < Ideology < _9Axes >> Get9Axes() {
      return IdeologiesService.Get9Axes();
    }

    [HttpGet("political_ideas")]
    public IEnumerable < Ideology < _Soulgraphy_PI >> GetPoliticalIdeas() {
      return IdeologiesService.GetPoliticalIdeas();
    }

    [HttpGet("economic_freedom_analysis")]
    public IEnumerable < Ideology < _Soulgraphy_EFA >> GetEconomicFreedomAnalysis() {
      return IdeologiesService.GetEconomicFreedomAnalysis();
    }

    [HttpGet("mypolitics")]
    public IEnumerable < Ideology < _MyPolitics >> GetMyPolitics() {
      return IdeologiesService.GetMyPolitics();
    }
  }
}