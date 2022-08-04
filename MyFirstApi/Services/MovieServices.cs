using Microsoft.Extensions.Caching.Memory;
using MyFirstApi.Models;

using Newtonsoft.Json;

namespace MyFirstApi.Services
{
    public class MovieServices
    {
        private readonly string main = "main";
        private readonly string all = "all";

        public static Root _root { get; set; }

        public static Content _content { get; set; }
        public IMemoryCache _cache { get; set; }

        public MovieServices(IMemoryCache cache)
        {
            _root = DataAccess.getInstance();
            _cache = cache;
        }



        private bool CheckCategoryName(string categoryName, List<CategoryInfoModel> categoryInfoList)
        {
            foreach (var categoryInfo in categoryInfoList)
            {
                if (categoryName.Equals(categoryInfo.MainCategoryName))
                {
                    return true;

                }


            }
            return false;


        }
        private bool CheckCategoryName(string categoryName, List<CategoryInfoModel> categoryInfoList, string subCategoryName)
        {
            var mainCategory = categoryInfoList.Where(x => x.MainCategoryName == categoryName).FirstOrDefault();
            if (mainCategory != null)
            {
                foreach (var subCategory in mainCategory.SubCategoryList)
                {
                    if (subCategory.Equals(subCategoryName))
                    {
                        return true;
                    }

                }
            }

            return false;


        }
        public List<string> SplitCategory(Content contents, bool getMenu)
        {
            List<string> result = new List<string>();
            foreach (var item in contents.Category)
            {
                // returns menu items if getMenu == true, otherwise returns category items
                result.Add(item.Split('/').ElementAt(getMenu ? 0 : 1));
            }
            return result;
        }
        public List<Content> GetContent()
        {

            var cacheList = _cache.Get<List<Content>>("all");
            if (cacheList == null)
            {
                List<Content> result = _root.Contents;
                _cache.Set("all", result);
                return result;

            }





            return cacheList;



        }
        public List<MainCategoryModel> GetMainCategories()
        {
            List<MainCategoryModel> cacheList = _cache.Get<List<MainCategoryModel>>("main");
            List<string> result = new List<string>();
            List<Content> list = _root.Contents;



            if (cacheList == null)
            {
                foreach (var item in list)
                {
                    var res = SplitCategory(item, true);
                    for (int i = 0; i < res.Count; i++)
                    {
                        if (!result.Contains(res.ElementAt(i)))
                        {
                            result.Add(res.ElementAt(i));
                        }
                    }
                }



                cacheList = new List<MainCategoryModel>();
                result.ForEach(x =>
                {
                    cacheList.Add(new MainCategoryModel { Name = x });

                });



            }

            return cacheList;

        }
        public List<CategoryInfoModel> GetCategoryInfo()
        {
          
            List<CategoryInfoModel> cacheList = _cache.Get<List<CategoryInfoModel>>("main2");
            var jsonDocument = DataAccess.getInstance();

            if (cacheList == null)
            {
                cacheList = new();
                foreach (var item in jsonDocument.Contents)
                {

                    foreach (var categoryName in item.Category)
                    {

                        var splittedCategory = categoryName.Split('/');

                        var mainCategory = splittedCategory[0];
                        var subCategory = splittedCategory[1];


                        if (!CheckCategoryName(mainCategory, cacheList))
                        {
                            cacheList.Add(new CategoryInfoModel() { MainCategoryName = mainCategory, SubCategoryList = new List<string>() });
                        }
                        if (!CheckCategoryName(mainCategory, cacheList, subCategory))
                        {

                            cacheList.Where(x => x.MainCategoryName == mainCategory).FirstOrDefault().SubCategoryList.Add(subCategory);
                            //  mainCategoriesList.Where(y => y.Name == mainCategory).FirstOrDefault().Category.Add();
                        }


                    }
                }
                _cache.Set("main2", cacheList);
                return cacheList;

            }

            

            return cacheList;
        }
        public List<Content> GetMoviesbySubCategory(string mainCategoryName, string subCategoryName)
        {
            List<Content> cacheList = _cache.Get<List<Content>>("contentssub");
          //  List<Content> moviesList = new List<Content>();
            var jsonDocument = DataAccess.getInstance();
            var categoryName = mainCategoryName + "/" + subCategoryName;

            if (cacheList == null)
            {
                cacheList = new List<Content>();
                foreach (var content in jsonDocument.Contents)
                {
                    foreach (var category in content.Category)
                    {
                        
                        if (category.Equals(categoryName) && !cacheList.Any(x => x.Id == content.Id))
                        {
                            cacheList.Add(content);

                        }
                    }

                }
                _cache.Set("contentssub", cacheList);
                return cacheList;
            }

            return cacheList;
        }
        public List<MoviePosterIdModel> GetMoviesbySubCategoryTitleId(string mainCategoryName, string subCategoryName)
        {
            List<MoviePosterIdModel> movieContentsPosterId = new();
            List<MoviePosterIdModel> cacheList = _cache.Get<List<MoviePosterIdModel>>("posteridcache");
            // List<MoviePosterIdModel> movieContents2 = new List<MoviePosterIdModel>() { new MoviePosterIdModel { Id = content.Id, Poster = content.Poster, Title = content.Title } };


            var jsonDocument = DataAccess.getInstance();
            var categoryName = mainCategoryName + "/" + subCategoryName;

            if (cacheList==null)
            {
                cacheList = new();
                foreach (var content in jsonDocument.Contents)
                {
                    foreach (var category in content.Category)
                    {
                        if (category.Equals(categoryName) && !cacheList.Any(x => x.Id == content.Id))
                        {
                            cacheList.Add(new MoviePosterIdModel { Id = content.Id, Poster = content.Poster, Title = content.Title });

                        }
                    }

                }
                _cache.Set("posteridcache", cacheList);
                return cacheList;
            }

            
           

            return cacheList;
        }
        public List<Content> GetDetails(string id)
        {
            List<Content> contentDetailList = new();

            var jsonDocument = DataAccess.getInstance();

            foreach (var content in jsonDocument.Contents)
            {
               
                
                   if(content.Id==id)
                    {
                        contentDetailList.Add(content);
                    }
                        
                   


                

            }


            return contentDetailList;
        }







    }
}






















//public List<CategoryInfoModel> GetCategoryInfoDENEME()
//{
//    List<CategoryInfoModel> categoryInfoList = new();
//    List<CategoryInfoModel> cacheList = _cache.Get<List<CategoryInfoModel>>("main2");
//    var jsonDocument = DataAccess.getInstance();

//    if (cacheList==null)
//    {
//        foreach (var item in jsonDocument.Contents)
//        {

//            foreach (var categoryName in item.Category)
//            {

//                var splittedCategory = categoryName.Split('/');

//                var mainCategory = splittedCategory[0];
//                var subCategory = splittedCategory[1];


//                if (!CheckCategoryName(mainCategory, categoryInfoList))
//                {
//                    categoryInfoList.Add(new CategoryInfoModel() { MainCategoryName = mainCategory, SubCategoryList = new List<string>() });
//                }
//                if (!CheckCategoryName(mainCategory, categoryInfoList, subCategory))
//                {

//                    categoryInfoList.Where(x => x.MainCategoryName == mainCategory).FirstOrDefault().SubCategoryList.Add(subCategory);
//                    //  mainCategoriesList.Where(y => y.Name == mainCategory).FirstOrDefault().Category.Add();
//                }


//            }
//        }

//    }

//    cacheList = categoryInfoList;

//    return cacheList;
//}