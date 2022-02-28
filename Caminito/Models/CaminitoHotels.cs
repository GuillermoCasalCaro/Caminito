namespace Caminito.Models
{
    public class CaminitoHotels
    {
        public CaminitoHotels(List<CaminitoHotel>? hotels)
        {
            this.Hotels = hotels;
        }

        public List<CaminitoHotel>? Hotels { get; set; }
    }
}