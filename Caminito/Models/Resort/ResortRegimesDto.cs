namespace Caminito.Models.Resort
{
    public class ResortRegimesDto
    {
        public List<ResortRegime>? Regimenes { get; set; }
    }

    public class ResortRegime
    {
        public string? Code { get; set; }

        public string? Name { get; set; }

        public string? Hotel { get; set; }

        public string? Room_type { get; set; }

        public int Price { get; set; }
    }

}