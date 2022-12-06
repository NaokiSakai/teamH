namespace TeamHApp.Models
{
    public class LostModel
    {
        public int LostId  {get; set; }
        public string LostName { get; set; }
        public string LostType { get; set; }
        public string LostImage { get; set; }
        public string LostDate { get; set; }
        public string LostInfomation { get; set; }

        public List<LostReservationModel> lost_reservation = new List<LostReservationModel>();


    }
}
