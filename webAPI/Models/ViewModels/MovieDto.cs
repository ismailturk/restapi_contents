namespace webAPI.Models.ViewModels
{
    public class MovieDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public List<string> Categories { get; set; }
    }
}
