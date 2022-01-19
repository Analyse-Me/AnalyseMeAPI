﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using AnalyseMeAPI.Models;
using AnalyseMeAPI.Services;

namespace AnalyseMeAPI.Controllers
{
    [ApiController]
    [Route("questions")]
    public class QuestionsController : ControllerBase {
        private readonly ILogger<QuestionsController> _logger;
        private readonly QuestionsService QuestionsService;

        public QuestionsController(ILogger<QuestionsController> logger) {
            _logger = logger;
            QuestionsService = new QuestionsService();
        }

        [HttpGet("8values")]
        public IEnumerable<Question<_8Values>> Get8Values() {
            return QuestionsService.Get8Values();
        }
    }
}
