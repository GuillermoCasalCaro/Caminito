using Caminito.Atalaya;
using System.Text.Json;

namespace Caminito.Services
{
    public class AtalayaService : IAtalayaService
    {
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;
        private static readonly JsonSerializerOptions _camelCaseOptions = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        public readonly string _atalayaHotelsAPI = "http://www.mocky.io/v2/5e4a7e4f2f00005d0097d253";
        public readonly string _atalayaRoomsAPI = "https://run.mocky.io/v3/132af02e-8beb-438f-ac6e-a9902bc67036";
        public readonly string _atalayaRegimesAPI = "http://www.mocky.io/v2/5e4a7e282f0000490097d252";

        public AtalayaService(HttpClient httpClient, ILogger<AtalayaService> logger)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<AtalayaHotelsDto> GetAtalayaHotelsAsync()
        {
            _logger.LogInformation($"Getting Atalaya Hotels");
            var request = new HttpRequestMessage(HttpMethod.Get, _atalayaHotelsAPI);
            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Error executing GetAtalayaHotelsAsync method. Service response: {response.ReasonPhrase}. Status code: {response.StatusCode}");
                return null;
            }

            _logger.LogInformation($"Atalaya Hotels getted successfully");
            return DeserializeContent<AtalayaHotelsDto>(response);
        }

        public async Task<AtalayaRoomsDto> GetAtalayaRoomsAsync()
        {
            _logger.LogInformation($"Getting Atalaya Rooms");
            var request = new HttpRequestMessage(HttpMethod.Get, _atalayaRoomsAPI);
            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Error executing GetAtalayaRoomssAsync method. Service response: {response.ReasonPhrase}. Status code: {response.StatusCode}");
                return null;
            }

            _logger.LogInformation($"Atalaya Rooms getted successfully");
            return DeserializeContent<AtalayaRoomsDto>(response);
        }

        public async Task<AtalayaMealPlansDto> GetAtalayaRegimesAsync()
        {
            _logger.LogInformation($"Getting Atalaya Regimes");
            var request = new HttpRequestMessage(HttpMethod.Get, _atalayaRegimesAPI);
            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Error executing GetAtalayaRegimesAsync method. Service response: {response.ReasonPhrase}. Status code: {response.StatusCode}");
                return null;
            }

            _logger.LogInformation($"Atalaya Regimes getted successfully");
            return DeserializeContent<AtalayaMealPlansDto>(response);
        }

        private static T DeserializeContent<T>(HttpResponseMessage response)
        {
            return JsonSerializer.Deserialize<T>(response.Content.ReadAsStream(), _camelCaseOptions);
        }
    }
}
