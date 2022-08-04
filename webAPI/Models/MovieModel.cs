namespace webAPI.Models
{
    public class MovieModel
    {
        //public int MovieId { get; set; }
        public string[] Categories { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Stars { get; set; }
        public string Genre { get; set; }
        public double ImdbRating { get; set; }
        public string Photo { get; set; }
        public string PlaybackUrl { get; set; }
    }

    public class ApiResponse
    {
        public List<MovieModel> Content { get; set; }
    }
  
}
