using Caminito.Atalaya;
using Caminito.Services;
using Microsoft.AspNetCore.Mvc;

namespace Caminito.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelListController : ControllerBase
    {
        private readonly ILogger<HotelListController> _logger;
        private readonly IAtalayaService _atalayaService;

        public HotelListController(IAtalayaService atalayaService, ILogger<HotelListController> logger)
        {
            _atalayaService = atalayaService;
            _logger = logger;
        }

        [HttpGet(Name = "GetAtalayaHotels")]
        public async Task<Hotels> HotelList()
        {
            var atalayaHotelsDto = await _atalayaService.GetAtalayaHotelsAsync();
            var atalayaRoomsDto = await _atalayaService.GetAtalayaRoomsAsync();
            var atalayaRegimesDto = await _atalayaService.GetAtalayaRegimesAsync();

            return TransformerService.AtalayaTransformer(atalayaHotelsDto, atalayaRoomsDto, atalayaRegimesDto);
        }
    }
}