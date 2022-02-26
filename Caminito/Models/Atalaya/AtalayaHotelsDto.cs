namespace Caminito.Atalaya
{
    public class AtalayaHotelsDto
    {
        public List<AtalayaHotel> hotels { get; set; }

    }

    public class AtalayaHotel
    {
        public string code { get; set; }

        public string name { get; set; }

        public string city { get; set; }

    }
}