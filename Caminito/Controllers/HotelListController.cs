using Microsoft.AspNetCore.Mvc;

namespace Caminito.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelListController : ControllerBase
    {
        private readonly ILogger<HotelListController> _logger;

        public HotelListController(ILogger<HotelListController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetHotelList")]
        public Hotels Get()
        {
            Room r1 = new Room();
            r1.Name = "room_name";
            r1.Price = "price_per_night_per_person";
            r1.Room_Type = "room_type";
            r1.Meals_Plan = "meal_code";

            Hotel h1 = new Hotel();
            h1.rooms = (new Room[] { r1 }).ToList();
            h1.code = "hotel_code";
            h1.name = "hotel_name";
            h1.city = "hotel_city";

            Hotels result = new Hotels();
            result.hotels = (new Hotel[] { h1 }).ToList();

            return result;
        }
    }
}