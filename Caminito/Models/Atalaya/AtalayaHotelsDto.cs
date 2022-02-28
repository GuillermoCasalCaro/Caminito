namespace Caminito.Models.Atalaya
{
    public class AtalayaHotelsDto
    {
        public List<AtalayaHotel>? Hotels { get; set; }

    }

    public class AtalayaHotel
    {
        public string? Code { get; set; }

        public string? Name { get; set; }

        public string? City { get; set; }

    }
}