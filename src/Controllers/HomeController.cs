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
    [Route("/")]
    public class HomeController : ControllerBase {
        [HttpGet]
        public string GetHome() {
            return "Api is working";
        }
    }
}