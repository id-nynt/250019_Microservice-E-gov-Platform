using System.Net.Http;
using System.Text;
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
            { "vaccination", "http://vaccination_service:5002" },
            { "parcels", "http://parceltracking-service:80" }
        };

        // Rewrite relative paths in HTML (css/js/images/forms)
        private readonly Dictionary<string, string> _publicRoutes = new()
        {
            { "coursesearch", "Courses" },
            { "taxcalculation", "Tax" },
            { "vaccination", "Vaccination" },
            { "parcels", "Parcels" }
        };

        public ApiGatewayController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // FORWARDERS

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
            {
                var body = string.IsNullOrWhiteSpace(content) ? $"Request to {service} failed." : content;
                return new ContentResult
                {
                    StatusCode = (int)response.StatusCode,
                    Content = body,
                    ContentType = contentType
                };
            }

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

            HttpContent content;
            var contentType = Request.ContentType ?? "";

            // Handle JSON content for API endpoints
            if (contentType.Contains("application/json"))
            {
                using var reader = new StreamReader(Request.Body, Encoding.UTF8);
                var body = await reader.ReadToEndAsync();
                content = new StringContent(string.IsNullOrWhiteSpace(body) ? "{}" : body, Encoding.UTF8, "application/json");
            }
            else
            {
                // Handle form data for UI endpoints
                var formData = new List<KeyValuePair<string, string>>();
                foreach (var item in Request.Form)
                    formData.Add(new(item.Key, item.Value.ToString()));
                content = new FormUrlEncodedContent(formData);
            }

            var response = await client.PostAsync(targetUrl, content);
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseContentType = response.Content.Headers.ContentType?.MediaType ?? "text/plain";

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, responseContent);

            if (responseContentType.Contains("html"))
            {
                var segment = _publicRoutes.TryGetValue(service, out var seg) ? seg : service;
                responseContent = FixHtmlPaths(responseContent, $"/ApiGateway/{segment}/");
            }

            return Content(responseContent, responseContentType);
        }

        // Web UI endpoints (HTML)

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

        [HttpPost("Vaccination/{**path}")]
        public Task<IActionResult> VaccinationPost(string path) => ForwardPost("vaccination", path);

        [HttpGet("Parcels")]
        [HttpGet("Parcels/{**path}")]
        public Task<IActionResult> Parcels(string? path = "") => ForwardGet("parcels", path, true);

        [HttpPost("Parcels/{**path}")]
        public Task<IActionResult> ParcelsPost(string path) => ForwardPost("parcels", path);


        // API endpoints (JSON)

        // Course API
        [HttpGet("/api/courses")]
        public Task<IActionResult> CoursesApi() => ForwardGet("coursesearch", "api/courses");

        // Tax API
        [HttpPost("/api/tax/calculate")]
        public Task<IActionResult> TaxCalculateApi() => ForwardPost("taxcalculation", "api/tax/calculate");

        // Parcels API
        [HttpGet("/api/parcels/{trackingNumber}")]
        public Task<IActionResult> ParcelLookupApi(string trackingNumber)
        {
            var encoded = Uri.EscapeDataString(trackingNumber ?? string.Empty);
            return ForwardGet("parcels", $"api/parcels/{encoded}");
        }

        // Vaccination API
        [HttpGet("/vaccinationRecord")]
        public Task<IActionResult> VaccinationRecordRoot()
        {
            return ForwardGet("vaccination", "vaccinationRecord");
        }

        // Rewrite relative paths in HTML
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