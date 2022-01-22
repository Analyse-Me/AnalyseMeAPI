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
    public class QuestionsController : ControllerBase {
        private readonly ILogger<QuestionsController> _logger;
        private readonly QuestionsService QuestionsService;

        public QuestionsController(ILogger<QuestionsController> logger, IMongoClient client) {
            _logger = logger;
            QuestionsService = new QuestionsService(client);
        }

        [HttpGet("compass/en")]
        public IEnumerable<Question<_Compass>> GetCompassEN() {
            return QuestionsService.GetCompassEN();
        }

        [HttpGet("compass/pl")]
        public IEnumerable<Question<_Compass>> GetCompassPL() {
            return QuestionsService.GetCompassPL();
        }

        [HttpGet("8values/en")]
        public IEnumerable<Question<_8Values>> Get8ValuesEN() {
            return QuestionsService.Get8ValuesEN();
        }

        [HttpGet("8values/pl")]
        public IEnumerable<Question<_8Values>> Get8ValuesPL() {
            return QuestionsService.Get8ValuesPL();
        }

        [HttpGet("politicalideas/pl")]
        public IEnumerable<Question<_Soulgraphy_PI>> GetPoliticalIdeasPL() {
            return QuestionsService.GetPoliticalIdeasPL();
        }
    }
}
