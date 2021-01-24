using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestWebAPI.Interfaces;
using TestWebAPI.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("[v1]")]
    public class CreditCalculatorController : ControllerBase
    {
        private readonly ILogger<CreditCalculatorController> _logger;
        private readonly ICreditCalculator _creditCalculator;
        public CreditCalculatorController(ICreditCalculator creditCalculator, ILogger<CreditCalculatorController> logger)
        {
            _creditCalculator = creditCalculator;
            _logger = logger;
        }

        [HttpGet]
        [Route("CreditCalculator")]
        public async Task<IActionResult> GetCreditScore([FromQuery] Customer customer)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await Task.FromResult(_creditCalculator.CalculateCredit(customer)));
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Exception Occured");
            }
        }
    }
}
