namespace Caminito.Models.Atalaya
{
    public class AtalayaRoomsDto
    {
        public List<AtalayaRoom>? Rooms_type { get; set; }

    }

    public class AtalayaRoom
    {
        public List<string>? Hotels { get; set; }

        public string? Code { get; set; }

        public string? Name { get; set; }
    }
}