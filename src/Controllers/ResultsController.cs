using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.Json;


using MongoDB.Driver;

using AnalyseMeAPI.Models;
using AnalyseMeAPI.Services;
using AnalyseMeAPI.Helpers;

namespace AnalyseMeAPI.Controllers {
    [ApiController]
    [Route("results")]
    public class ResultsController : ControllerBase {

        private readonly ILogger<ResultsController> _logger;
        private readonly ResultsService ResultsService;

        public ResultsController(ILogger<ResultsController> logger, IMongoClient client) {
            _logger = logger;
            ResultsService = new ResultsService(client);
        }

        [HttpGet]
        public string GetResults() {
            return "AAA";
        }
        
        [HttpPost("political_compass")]
        public string PushPoliticalCompass([FromBody] ResultRequest<_Compass> body) {
            return ResultsService.PushPoliticalCompass(body);
        }

        [HttpPost("8values")]
        public string Push8Values([FromBody] ResultRequest<_8Values> body) {
            return ResultsService.Push8Values(body);
        }

        [HttpPost("9axes")]
        public string Push9Axes([FromBody] ResultRequest<_9Axes> body) {
            return ResultsService.Push9Axes(body);
        }

        [HttpPost("political_ideas")]
        public string PushPoliticalIdeas([FromBody] ResultRequest<_Soulgraphy_PI> body) {
            return ResultsService.PushPoliticalIdeas(body);
        }

        [HttpPost("economic_freedom_analysis")]
        public string PushEconomicFreedomAnalysis([FromBody] ResultRequest<_Soulgraphy_EFA> body) {
            return ResultsService.PushEconomicFreedomAnalysis(body);
        }
        [HttpPost("personal_freedom_analysis")]
        public string PushPersonalFreedomAnalysis([FromBody] ResultRequest<_Soulgraphy_PFA> body) {
            return ResultsService.PushPersonalFreedomAnalysis(body);
        }
        [HttpPost("mypolitics")]
        public string PushMyPolitics([FromBody] ResultRequest<_MyPolitics> body) {
            return ResultsService.PushMyPolitics(body);
        }
    }
}