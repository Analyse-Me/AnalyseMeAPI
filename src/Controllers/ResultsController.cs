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
            return ResultsHelper.CreateID(12);
        }
        
        [HttpPost("political_compass")]
        public string PushPoliticalCompass([FromBody] ResultRequest<_Compass> body) {
            Console.WriteLine(body);
            Console.WriteLine(body.quiz);
            Console.WriteLine(body.results);
            Console.WriteLine(body.results.econ);
            return ResultsService.PushPoliticalCompass(body);
        }
    }
}