using Caminito.Models;
using Caminito.Models.Resort;

namespace Caminito.Transformers
{
    public class ResortTransformer
    {
        public static CaminitoHotels TransformToCaminito(ResortHotelsDto resortHotelsDto, ResortRegimesDto resortRegimesDto)
        {
            List<CaminitoHotel> hotels = new();

            var hotelPropsByCodeDictionary = resortHotelsDto.Hotels!.ToDictionary(k => k.Code!, v => new { v.Name, v.Location, v.Rooms });
            var resortRegimesGroupedByHotel = resortRegimesDto.Regimenes!.GroupBy(r => r.Hotel);
            foreach (IGrouping<string?, ResortRegime> hotelGroup in resortRegimesGroupedByHotel)
            {
                var hotel_code = hotelGroup.Key!;
                var hotel_name = hotelPropsByCodeDictionary[hotel_code].Name!;
                var hotel_city = hotelPropsByCodeDictionary[hotel_code].Location!;
                var rooms = new List<CaminitoRoom>();

                var roomPropsByCodeDictionary = hotelPropsByCodeDictionary[hotel_code].Rooms!.ToDictionary(k => k.Code!, v => new { v.Name });
                var resortRegimesFilteredByHotelAndGroupedByRoomType = hotelGroup.ToList().GroupBy(r => r.Room_type);
                foreach (IGrouping<string?, ResortRegime> roomTypeGroup in resortRegimesFilteredByHotelAndGroupedByRoomType)
                {
                    var room_type = roomTypeGroup.Key!;
                    var room_name = roomPropsByCodeDictionary[room_type].Name!;
                    foreach (ResortRegime regime in roomTypeGroup.ToList())
                    {
                        var price = regime.Price;
                        var meals_plan = regime.Code!;

                        rooms.Add(new CaminitoRoom(room_name, room_type, meals_plan, price));
                    }
                }
                hotels.Add(new CaminitoHotel(hotel_code, hotel_name, hotel_city, rooms));
            }
            return new CaminitoHotels(hotels);
        }
    }
}
