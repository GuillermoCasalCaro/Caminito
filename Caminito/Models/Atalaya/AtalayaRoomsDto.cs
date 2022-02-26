namespace Caminito.Atalaya
{
    public class AtalayaRoomsDto
    {
        public List<AtalayaRoom> rooms_type { get; set; }

    }

    public class AtalayaRoom
    {
        public List<string> hotels { get; set; }

        public string code { get; set; }

        public string name { get; set; }

    }
}