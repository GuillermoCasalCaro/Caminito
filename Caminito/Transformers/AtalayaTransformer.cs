using Caminito.Models;
using Caminito.Models.Atalaya;

namespace Caminito.Transformers
{
    public class AtalayaTransformer
    {
        public static CaminitoHotels TransformToCaminito(AtalayaHotelsDto atalayaHotelsDto, AtalayaRoomsDto atalayaRoomsDto, AtalayaRegimesDto atalayaMealPlansDto)
        {
            var hotelPropsByCodeDictionary = atalayaHotelsDto.Hotels!.ToDictionary(k => k.Code!, v => new Tuple<string, string>(v.Name!, v.City!));
            var roomNameByCodeDictionary = atalayaRoomsDto.Rooms_type!.ToDictionary(k => k.Code!, v => v.Name);

            CaminitoHotels res = new(new List<CaminitoHotel>());

            var meal_plans = atalayaMealPlansDto.Meal_plans;
            for (int i = 0; i < meal_plans!.Count; i++)
            {
                var meal_plan = meal_plans[i];
                var meal_plan_code = meal_plan.Code!;
                var meal_plan_name = meal_plan.Name;
                var hotel_codes = new List<string>(meal_plan.Hotel!.Keys);
                var hotels = meal_plan.Hotel;
                for (int j = 0; j < hotel_codes.Count; j++)
                {
                    var hotel_code = hotel_codes[j];
                    var hotel_name = hotelPropsByCodeDictionary[hotel_code].Item1;
                    var hotel_city = hotelPropsByCodeDictionary[hotel_code].Item2;
                    var regimes = hotels[hotel_code];
                    var rooms = new List<CaminitoRoom>();
                    for (int k = 0; k < regimes.Count; k++)
                    {
                        var room_code = regimes[k].Room!;
                        var room_price = regimes[k].Price;
                        var room_name = roomNameByCodeDictionary[room_code]!;

                        CaminitoRoom room = new(room_name, room_code, meal_plan_code, room_price);
                        rooms.Add(room);
                    }

                    CaminitoHotel? hotelAlreadyAdded = res.Hotels!.FirstOrDefault(x => x.Code.Equals(hotel_code));
                    if (hotelAlreadyAdded == null)
                        res.Hotels!.Add(new CaminitoHotel(hotel_code, hotel_name, hotel_city, rooms));
                    else
                        hotelAlreadyAdded.Rooms.AddRange(rooms);
                }
            }
            return res;
        }
    }
}
