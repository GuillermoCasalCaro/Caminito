using Caminito.Atalaya;

namespace Caminito.Services
{
    public class TransformerService
    {
        public static Hotels AtalayaTransformer(AtalayaHotelsDto AtalayaHotelsDto, AtalayaRoomsDto atalayaRoomsDto, AtalayaMealPlansDto atalayaMealPlansDto)
        {
            var hotelPropsByCodeDictionary = AtalayaHotelsDto.hotels.ToDictionary(k => k.code, v => new Tuple<string, string>(v.name, v.city));
            var roomNameByCodeDictionary = atalayaRoomsDto.rooms_type.ToDictionary(k => k.code, v => v.name);

            Hotels res = new Hotels();
            res.hotels = new List<Hotel>();

            var meal_plans = atalayaMealPlansDto.meal_plans;
            for (int i = 0; i < meal_plans.Count; i++)
            {
                var meal_plan = meal_plans[i];
                var meal_plan_code = meal_plan.code;
                var meal_plan_name = meal_plan.name;
                var hotel_codes = new List<string>(meal_plan.hotel.Keys);
                var hotels = meal_plan.hotel;
                for (int j = 0; j < hotel_codes.Count; j++)
                {
                    var hotel_code = hotel_codes[j];
                    var hotel_name = hotelPropsByCodeDictionary[hotel_code].Item1;
                    var hotel_city = hotelPropsByCodeDictionary[hotel_code].Item2;
                    var regimes = hotels[hotel_code];
                    var rooms = new List<Room>();
                    for (int k = 0; k < regimes.Count; k++)
                    {
                        var room_code = regimes[k].room;
                        var room_price = regimes[k].price;
                        var room_name = roomNameByCodeDictionary[room_code];

                        Room room = new Room(room_name, room_code, meal_plan_code, room_price);
                        rooms.Add(room);
                    }

                    Hotel hotelAlreadyAdded = res.hotels.FirstOrDefault(x => x.code.Equals(hotel_code));

                    if (hotelAlreadyAdded == null)
                    {
                        res.hotels.Add(new Hotel(hotel_code, hotel_name, hotel_city, rooms));
                    } else {
                        hotelAlreadyAdded.rooms.AddRange(rooms);
                    }
                }
            }
            return res;
        }
    }
}
