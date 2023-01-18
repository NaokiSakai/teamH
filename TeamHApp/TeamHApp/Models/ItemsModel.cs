using System.ComponentModel;
using System.Web;

namespace TeamHApp.Models

{
    public class itemsModel
    {
        public int items_id  {get; set; }
        public string classify { get; set; }
        public string type { get; set; }

        public string  image_path { get; set; }
        public string found_date { get; set; }
        public string information { get; set; }
        public  Boolean is_sended_notice { get; set; }

        public List<string> lost_subscriber = new List<string>();
     


    }


}
