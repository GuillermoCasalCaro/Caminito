namespace Caminito.Models
{
    public class CaminitoHotel
    {
        public CaminitoHotel (string code, string name, string city, List<CaminitoRoom> rooms)
        {
            this.Code = code;
            this.Name = name;
            this.City = city;
            this.Rooms = rooms;
        }

        public string Code { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public List<CaminitoRoom> Rooms { get; set; }
    }
}