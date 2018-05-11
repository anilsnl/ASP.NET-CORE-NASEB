namespace NASEB.Entities.ComplexType
{
    public class RentHistoryView
    {
        public string MemberName { get; set; }
        public int MemberID { get; set; }
        public int RentID { get; set; }
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string CreatedInfo { get; set; }
        public string LastUpdatedInfo { get; set; }
        public string Durum { get; set; }
        public double DelayFine { get; set; }
        public int RegistereedYear { get; set; }
    }
}
