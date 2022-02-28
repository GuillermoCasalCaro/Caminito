using Caminito.Models;
using Caminito.Services;
using Caminito.Transformers;
using Microsoft.AspNetCore.Mvc;

namespace Caminito.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItineraryCancunController : ControllerBase
    {
        private readonly ILogger<ItineraryCancunController> _logger;
        private readonly IAtalayaService _atalayaService;
        private readonly IResortService _resortService;

        public ItineraryCancunController(IAtalayaService atalayaService, IResortService resortService, ILogger<ItineraryCancunController> logger)
        {
            _atalayaService = atalayaService;
            _resortService = resortService;
            _logger = logger;
        }

        [HttpGet(Name = "GetItineraryCancun")]
        public async Task<CaminitoHotels> ItineraryCancun()
        {
            CaminitoHotels result = new(new List<CaminitoHotel>());

            return result;
        }
    }
}