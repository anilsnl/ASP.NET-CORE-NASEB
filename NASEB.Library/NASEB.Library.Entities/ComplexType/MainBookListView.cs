namespace NASEB.Library.Entities.ComplexType
{
    public class MainBookListView
    {
        public int BookID { get; set; }
        public int BookTypeID { get; set; }
        public int PublisherID { get; set; }

        public string BookName { get; set; }
        public string PublisherName { get; set; }
        public string BookTypeNanme { get; set; }
        public string Authors { get; set; }
        public string Location { get; set; }
        public string ISBN { get; set; }
        public string Creaded_UpdatedDate { get; set; }
        public int TotalCount { get; set; }
        public int AwailableQuantity { get; set; }
    }
}
