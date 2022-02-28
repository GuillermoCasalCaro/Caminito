namespace Caminito.Models.Atalaya
{

    public class AtalayaRegimesDto
    {
        public List<AtalayaRegime>? Meal_plans { get; set; }
    }

    public class AtalayaRegime
    {
        public string? Code { get; set; }

        public string? Name { get; set; }

        public Dictionary<string, List<AtalayaPriceByRoom>>? Hotel { get; set; }
    }

    public class AtalayaPriceByRoom
    {
        public string? Room { get; set; }

        public int Price { get; set; }
    }
}