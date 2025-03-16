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
  public class IdeologiesController : ControllerBase {
    private readonly ILogger<QuestionsController> Logger;
    private readonly IdeologiesService IdeologiesService;

    public IdeologiesController(ILogger<QuestionsController> logger) {
      Logger = logger;
      IdeologiesService = new IdeologiesService();
    }

    [HttpGet("8values")]
    public string Get8Values() {
      return IdeologiesService.Get8Values();
    }


  }
}