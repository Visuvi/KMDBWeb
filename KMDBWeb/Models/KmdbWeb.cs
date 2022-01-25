namespace KMDBWeb.Models
{
    public class KmdbWeb
    {
        public int Id { get; set; }
        public string thumbNail { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int UserRating { get; set; }

        public KmdbWeb()
        {
            
        }
    }
}
