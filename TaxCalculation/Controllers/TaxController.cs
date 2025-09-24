using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TaxCalculation.Models;

namespace TaxCalculation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxController : ControllerBase
    {
        private readonly IConfiguration _config;

        // optional simple in-memory history for demo
        private static readonly List<TaxResult> _history = new();

        public TaxController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody] TaxRequest req)
        {
            if (req == null) return BadRequest(new { message = "Invalid request body." });
            if (req.Income < 0) return BadRequest(new { message = "Income must be >= 0." });

            var brackets = _config.GetSection("TaxBrackets").Get<List<TaxBracket>>() ?? new List<TaxBracket>();
            var tax = CalculateTax(req.Income, brackets);

            var result = new TaxResult
            {
                Income = req.Income,
                Tax = Math.Round(tax, 2),
                EffectiveRate = req.Income == 0 ? 0 : Math.Round(tax / req.Income, 4) // fraction
            };

            // add to in-memory history
            _history.Add(result);

            return Ok(result);
        }

        [HttpGet("history")]
        public IActionResult History()
        {
            return Ok(_history);
        }

        // Helper: progressive tax calculation
        private static decimal CalculateTax(decimal income, List<TaxBracket> brackets)
        {
            if (!brackets.Any()) return 0m;

            var ordered = brackets.OrderBy(b => b.Min).ToList();

            foreach (var b in ordered)
            {
                decimal lower = b.Min;
                decimal upper = b.Max ?? decimal.MaxValue;

                if (income <= upper)
                {
                    // Apply formula: BaseTax + (income - lower) * Rate
                    return b.BaseTax + (income - lower) * b.Rate;
                }
            }

            return 0m;
        }
    }
}
