using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


using AnalyseMeAPI.Models;
using AnalyseMeAPI.Services;

namespace AnalyseMeAPI.Controllers {

  [ApiController]
  [Route("questions")]
  public class QuestionsController : ControllerBase {

    private readonly QuestionsService QuestionsService;

    public QuestionsController(ILogger<QuestionsController> logger) {
      QuestionsService = new QuestionsService();
    }

    [HttpGet("political_compass")]
    public string GetCompass() {
      return QuestionsService.GetCompass();
    }

    [HttpGet("8values")]
    public string Get8Values() {
      return QuestionsService.Get8Values();
    }

    [HttpGet("9axes")]
    public string Get9Axes() {
      return QuestionsService.Get9Axes();
    }

    [HttpGet("political_ideas")]
    public string GetPoliticalIdeas() {
      return QuestionsService.GetPoliticalIdeas();
    }

    [HttpGet("economic_freedom_analysis")]
    public string GetEconomicFreedomAnalysis() {
      return QuestionsService.GetEconomicFreedomAnalysis();
    }

    [HttpGet("personal_freedom_analysis")]
    public string GetPersonalFreedomAnalysis() {
      return QuestionsService.GetPersonalFreedomAnalysis();
    }


  }
}