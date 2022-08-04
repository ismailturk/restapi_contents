using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Models;
using System.IO;

using static System.IO.FileStream;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MyFirstApi.Services;
using Microsoft.AspNetCore.Cors;

namespace MyFirstApi.Controllers
{
   
    [Route("api/[Controller]")]

    public class ClientController:ControllerBase
    {
        public MovieServices movieServices;
        public ClientController(MovieServices movieServices)
        {
            this.movieServices = movieServices;
        }



        [HttpGet("get-content")]
        public List<Content> GetContent()
        {
            var menu = movieServices.GetContent();
            return menu;
        }
       
        [HttpGet("get-menu")]
        public IList<MainCategoryModel> GetMainCategories()
        {
            var cat = movieServices.GetMainCategories();
            return cat;
        }
        [EnableCors("allow")]
        [HttpGet("get-category")]
        public List<CategoryInfoModel> GetCategory()
        {
            var catinf = movieServices.GetCategoryInfo();
            return catinf;
        }

        [HttpPost("get-movies-by-subcategories")]
        public List<Content> GetMoviesbySubCategory(string mainCategoryName,string subCategoryName)
        {
            var movie = movieServices.GetMoviesbySubCategory(mainCategoryName,subCategoryName);
            return movie;
        }
        [HttpPost("get-movies-by-subcategories-subcategory-title-id")]
        public List<MoviePosterIdModel> GetMoviesbySubCategoryTitleId(string mainCategoryName, string subCategoryName)
        {
            var result = movieServices.GetMoviesbySubCategoryTitleId(mainCategoryName, subCategoryName);
            return result;
        }
        [HttpPost("get-content-detail")]
        public List<Content> GetDetails(string id)
        {
            var menu = movieServices.GetDetails(id);
            return menu;
        }












        //[HttpGet("get-category")]
        //public IList<string> GetCategory(string menuName)
        //{
        //    var category = movieServices.GetCategory(menuName);
        //    return category;
        //}

        //[HttpGet("get-categories-movies/{category}/{name}")]
        //public IList<string>GetMovies(string menu, string category)
        //{

        //    var result = movieServices.GetCategoriesByMenu(menu,category);
        //    return result;
        //}




    }
}
