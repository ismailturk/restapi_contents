using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Models.ViewModels;
using webAPI.Services;

namespace webAPI.Controllers
{

    [Route("api/[controller]")]
    public class FirstController : ControllerBase
    {
        public FirstController()
        {
        }

        public List<Category> GetCategoryList()
        {
            List<Category> categoryList = new List<Category>();

            Category cat1 = new Category
            {
                Id = 3005,
                Name = "Vizyondakiler",
                ParentCategoryId = 0,
            };

            categoryList.Add(cat1);

            Category cat2 = new Category
            {
                Id = 3008,
                Name = "Drama",
                ParentCategoryId = 3005
            };

            categoryList.Add(cat2);

            Category cat3 = new Category
            {
                Id = 5000,
                Name = "Seç İzle",
                ParentCategoryId = 0,
            };

            categoryList.Add(cat3);


            Category cat5 = new Category { Id = 5005, Name = "Aksiyon", ParentCategoryId = 5000 };
            categoryList.Add(cat5);

            return categoryList;
        }

        [HttpGet]
        public ApiResponse GetMovieList()
        {
            List<MovieModel> content = new List<MovieModel>();
            MovieModel model1 = new MovieModel();
            model1.Title = "Countdown";
            model1.Description = "When a nurse downloads an app that claims to predict the moment a person will die, it tells her she only has three days to live. With the clock ticking and a figure haunting her, she must find a way to save her life before time runs out.";
            model1.Stars = "asdasd";
            model1.Director = "asdasd";
            model1.Writer = "asdas";
            model1.ImdbRating = 5.6;
            model1.Categories = new string[] { @"\Secizle\Vizyondakiler", @"\Secizle\OneCikanlar" };
            content.Add(model1);
            return new ApiResponse { Content = content};
        }

        //public List<string> GetParentCats(int parentCategoryId)
        //{
        //    var cat = GetCategoryList().FirstOrDefault(x => x.Id == parentCategoryId);
           
        //    if (cat.ParentCategoryId != 0)
        //    {
        //        GetParentCats
        //    }
        //}

        //public MovieDto GetMoivesForFrontEnd(int id)
        //{
        //    var movie = GetMovieList().FirstOrDefault(x => x.MovieId == id);
        //    List<string> catList = new List<string>();
        //    foreach (int catId in movie.Categories)
        //    {
        //        var category = GetCategoryList().Where(x => x.Id == catId);
        //    }

        //    //GetCategoryList().Where(x=> x.Id == movie.Categories.)
        //    MovieDto dto = new MovieDto();
        //    //dto.Title =
        //}

        //[HttpGet]
        //public MovieModel[] GetPopular()
        //{

        //    if (movieRepos.GetPopular().)

        //}
    }
}
