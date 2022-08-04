namespace MyFirstApi.Models
{

    public class Root
    {
        public List<Content> Contents { get; set; }

      
    }
   
    public class Content
    {
        public string Id { get; set; }
        public string[] Category { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public float IMDbRating { get; set; }
        public string PlaybackURL { get; set; }
        public string Poster { get; set; }
        public string Stars { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
    }


}
