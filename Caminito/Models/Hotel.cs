namespace Caminito
{
    public class Hotel
    {
        public Hotel (string code, string name, string city, List<Room> rooms)
        {
            this.code = code;
            this.name = name;
            this.city = city;
            this.rooms = rooms;
        }

        public string code { get; set; }

        public string name { get; set; }

        public string city { get; set; }

        public List<Room> rooms { get; set; }
    }
}