using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("ApiGateway")]
    public class ApiGatewayController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        // Container names and internal ports used by Docker networking
        private readonly Dictionary<string, string> _serviceUrls = new()
        {
            { "coursesearch", "http://coursesearch:80" },
            { "taxcalculation", "http://taxcalculation:80" },
            { "vaccination", "http://vaccination:80" },
            { "tracking", "http://tracking:80" }
        };

        // Used to rewrite relative paths in HTML (css/js/images/forms)
        private readonly Dictionary<string, string> _publicRoutes = new()
        {
            { "coursesearch", "Courses" },
            { "taxcalculation", "Tax" },
            { "vaccination", "Vaccination" },
            { "tracking", "Tracking" }
        };

        public ApiGatewayController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // =======================
        // FORWARDERS
        // =======================

        private async Task<IActionResult> ForwardGet(string service, string? path = "", bool fixHtml = false)
        {
            if (!_serviceUrls.ContainsKey(service))
                return NotFound($"Service '{service}' not registered.");

            var client = _httpClientFactory.CreateClient();
            var targetUrl = string.IsNullOrEmpty(path)
                ? _serviceUrls[service] + "/"
                : $"{_serviceUrls[service]}/{path}";

            if (Request.QueryString.HasValue)
                targetUrl += Request.QueryString.Value; //query params

            var response = await client.GetAsync(targetUrl);
            var content = await response.Content.ReadAsStringAsync();
            var contentType = response.Content.Headers.ContentType?.MediaType ?? "text/plain";

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, $"Request to {service} failed.");

            if (fixHtml && contentType.Contains("html"))
            {
                var segment = _publicRoutes.TryGetValue(service, out var seg) ? seg : service;
                content = FixHtmlPaths(content, $"/ApiGateway/{segment}/");
            }

            return Content(content, contentType);
        }

        private async Task<IActionResult> ForwardPost(string service, string path)
        {
            if (!_serviceUrls.ContainsKey(service))
                return NotFound($"Service '{service}' not registered.");

            var client = _httpClientFactory.CreateClient();
            var targetUrl = $"{_serviceUrls[service]}/{path}";

            var formData = new List<KeyValuePair<string, string>>();
            foreach (var item in Request.Form)
                formData.Add(new(item.Key, item.Value.ToString()));

            var content = new FormUrlEncodedContent(formData);
            var response = await client.PostAsync(targetUrl, content);

            var responseContent = await response.Content.ReadAsStringAsync();
            var contentType = response.Content.Headers.ContentType?.MediaType ?? "text/plain";

            if (contentType.Contains("html"))
            {
                var segment = _publicRoutes.TryGetValue(service, out var seg) ? seg : service;
                responseContent = FixHtmlPaths(responseContent, $"/ApiGateway/{segment}/");
            }

            return Content(responseContent, contentType);
        }

        // =======================
        // Web UI endpoints (HTML)
        // =======================

        [HttpGet("Courses")]
        [HttpGet("Courses/{**path}")]
        public Task<IActionResult> Courses(string? path = "") => ForwardGet("coursesearch", path, true);

        [HttpPost("Courses/{**path}")]
        public Task<IActionResult> CoursesPost(string path) => ForwardPost("coursesearch", path);

        [HttpGet("Tax")]
        [HttpGet("Tax/{**path}")]
        public Task<IActionResult> Tax(string? path = "") => ForwardGet("taxcalculation", path, true);

        [HttpPost("Tax/{**path}")]
        public Task<IActionResult> TaxPost(string path) => ForwardPost("taxcalculation", path);

        [HttpGet("Vaccination")]
        [HttpGet("Vaccination/{**path}")]
        public Task<IActionResult> Vaccination(string? path = "") => ForwardGet("vaccination", path, true);

        [HttpGet("Tracking")]
        [HttpGet("Tracking/{**path}")]
        public Task<IActionResult> Tracking(string? path = "") => ForwardGet("tracking", path, true);

        // =======================
        // API passthroughs required by UI JS
        // =======================

        [HttpGet("/api/courses")]
        public Task<IActionResult> CoursesApi() => ForwardGet("coursesearch", "api/courses");

        [HttpGet("/api/courses/all")]
        public Task<IActionResult> CoursesAllApi() => ForwardGet("coursesearch", "api/courses/all");

        [HttpGet("/api/tax")]
        public async Task<IActionResult> TaxApi([FromQuery] decimal income)
        {
            // Note: some UIs call GET; the service expects POST with JSON
            var client = _httpClientFactory.CreateClient();
            var json = JsonSerializer.Serialize(new { income });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var resp = await client.PostAsync($"{_serviceUrls["taxcalculation"]}/api/tax/calculate", content);
            var body = await resp.Content.ReadAsStringAsync();
            if (!resp.IsSuccessStatusCode) return StatusCode((int)resp.StatusCode, body);
            return Content(body, "application/json");
        }

        [HttpPost("/api/tax/calculate")]
        public async Task<IActionResult> TaxCalculateApi()
        {
            using var reader = new StreamReader(Request.Body, Encoding.UTF8);
            var body = await reader.ReadToEndAsync();
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(string.IsNullOrWhiteSpace(body) ? "{}" : body, Encoding.UTF8, "application/json");
            var resp = await client.PostAsync($"{_serviceUrls["taxcalculation"]}/api/tax/calculate", content);
            var respBody = await resp.Content.ReadAsStringAsync();
            if (!resp.IsSuccessStatusCode) return StatusCode((int)resp.StatusCode, respBody);
            return Content(respBody, "application/json");
        }

        // =======================
        // Helper: rewrite relative asset/form paths in HTML
        // =======================
        private string FixHtmlPaths(string htmlContent, string basePath)
        {
            var fixedContent = htmlContent;

            fixedContent = System.Text.RegularExpressions.Regex.Replace(
                fixedContent,
                @"(href|src|action)\s*=\s*[""']([^""'/][^""']*)[""']",
                match =>
                {
                    var attr = match.Groups[1].Value;
                    var val = match.Groups[2].Value;
                    if (!val.StartsWith("http") && !val.StartsWith("/"))
                        val = basePath + val;
                    return $"{attr}=\"{val}\"";
                },
                System.Text.RegularExpressions.RegexOptions.IgnoreCase
            );

            return fixedContent;
        }
    }
}
