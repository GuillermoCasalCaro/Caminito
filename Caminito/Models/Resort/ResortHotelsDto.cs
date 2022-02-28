namespace Caminito.Models.Resort
{
    public class ResortHotelsDto
    {
        public List<ResortHotel>? Hotels { get; set; }
    }

    public class ResortHotel
    {
        public string? Code { get; set; }

        public string? Name { get; set; }

        public string? Location { get; set; }

        public List<ResortRoom>? Rooms { get; set; }
    }

    public class ResortRoom
    {
        public string? Code { get; set; }

        public string? Name { get; set; }
    }
}