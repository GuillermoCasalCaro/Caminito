namespace Caminito.Models
{
    public class CaminitoRoom
    {
        public CaminitoRoom(string name, string room_type, string meals_plan, int price) { 
            this.name = name;
            this.room_type = room_type;
            this.meals_plan = meals_plan;
            this.price = price;
        }

        public string name { get; set; }

        public string room_type { get; set; }

        public string meals_plan { get; set; }

        public int price { get; set; }
    }
}