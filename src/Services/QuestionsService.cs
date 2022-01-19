using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using AnalyseMeAPI.Models;

namespace AnalyseMeAPI.Services {
    public class QuestionsService {
        public IEnumerable<Question<_8Values>> Get8Values() {
            return new Question<_8Values>[] {new Question<_8Values>() {
                question = "",
                effect = {
                    econ = 4,
                    dipl = 4,
                    govt = -3,
                    scty = 2,
                }
            }};
        }
    }
}