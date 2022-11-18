namespace TeamHApp.Models
{
    public class LostModel
    {
        public int id  {get; set; }
        public string name { get; set; }
        public string classify { get; set; }
        public string image_path { get; set; }
        public string found_date { get; set; }
        public string infomation { get; set; }
        public List<string> lost_subscriber = new List<string>();


    }
}
