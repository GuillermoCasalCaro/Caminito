using Caminito.Models.Resort;
using System.Text.Json;

namespace Caminito.Services
{
    public class ResortService : IResortService
    {
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;
        private static readonly JsonSerializerOptions _camelCaseOptions = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        public readonly string _resortHotelsAPI = "http://www.mocky.io/v2/5e4e43272f00006c0016a52b";
        public readonly string _resortRegimesAPI = "http://www.mocky.io/v2/5e4a7dd02f0000290097d24b";

        public ResortService(HttpClient httpClient, ILogger<AtalayaService> logger)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<ResortHotelsDto> GetResortHotelsAsync()
        {
            _logger.LogInformation($"Getting Resort Hotels");
            var request = new HttpRequestMessage(HttpMethod.Get, _resortHotelsAPI);
            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Error executing GetResortHotelsAsync method. Service response: {response.ReasonPhrase}. Status code: {response.StatusCode}");
                return null;
            }

            _logger.LogInformation($"Resort Hotels getted successfully");
            return DeserializeContent<ResortHotelsDto>(response);
        }

        public async Task<ResortRegimesDto> GetResortRegimesAsync()
        {
            _logger.LogInformation($"Getting Resort Regimes");
            var request = new HttpRequestMessage(HttpMethod.Get, _resortRegimesAPI);
            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Error executing GetResortRegimesAsync method. Service response: {response.ReasonPhrase}. Status code: {response.StatusCode}");
                return null;
            }

            _logger.LogInformation($"Resort Regimes getted successfully");
            return DeserializeContent<ResortRegimesDto>(response);
        }

        private static T DeserializeContent<T>(HttpResponseMessage response)
        {
            return JsonSerializer.Deserialize<T>(response.Content.ReadAsStream(), _camelCaseOptions);
        }
    }
}
