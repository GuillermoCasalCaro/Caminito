namespace Caminito.Atalaya
{

    public class AtalayaMealPlansDto
    {
        public List<AtalayaMealPlan> meal_plans { get; set; }

    }

    public class AtalayaMealPlan
    {
        public string code { get; set; }

        public string name { get; set; }

        public Dictionary<string, List<AtalayaPriceByRoom>> hotel { get; set; }

    }

    public class AtalayaPriceByRoom
    {
        public string room { get; set; }

        public int price { get; set; }

    }

}