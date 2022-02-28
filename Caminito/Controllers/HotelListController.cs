using Caminito.Models;
using Caminito.Services;
using Caminito.Transformers;
using Microsoft.AspNetCore.Mvc;

namespace Caminito.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelListController : ControllerBase
    {
        private readonly ILogger<HotelListController> _logger;
        private readonly IAtalayaService _atalayaService;
        private readonly IResortService _resortService;

        public HotelListController(IAtalayaService atalayaService, IResortService resortService, ILogger<HotelListController> logger)
        {
            _atalayaService = atalayaService;
            _resortService = resortService;
            _logger = logger;
        }

        [HttpGet(Name = "GetHotelList")]
        public async Task<CaminitoHotels> HotelList()
        {
            CaminitoHotels result = new(new List<CaminitoHotel>());

            var atalayaHotelsDto = await _atalayaService.GetAtalayaHotelsAsync();
            var atalayaRoomsDto = await _atalayaService.GetAtalayaRoomsAsync();
            var atalayaRegimesDto = await _atalayaService.GetAtalayaRegimesAsync();
            result.Hotels!.AddRange(AtalayaTransformer.TransformToCaminito(atalayaHotelsDto, atalayaRoomsDto, atalayaRegimesDto).Hotels!);

            var resortHotelsDto = await _resortService.GetResortHotelsAsync();
            var resortRegimesDto = await _resortService.GetResortRegimesAsync();
            result.Hotels!.AddRange(ResortTransformer.TransformToCaminito(resortHotelsDto, resortRegimesDto).Hotels!);

            return result;
        }
    }
}