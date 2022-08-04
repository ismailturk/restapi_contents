//using MyFirstApi.Services;
//namespace MyFirstApi.Models
//{
//    public class CrudRepository : ICrudRepository
//    {
//        public static Root access { get; set; }
//        public CrudRepository()
//        {
//            access = DataAccess.getApi();
            
//        }


       



//        //public ApiResponse Update(ApiResponse model)
//        //{
//        //    if (model == null)
//        //    {
//        //        throw new ArgumentNullException("item");
//        //    }
//        //    int index = access.Contents.FirstOrDefault(p =>);
//        //    if (index == -1)
//        //    {
//        //        return new ApiResponse { };
//        //    }
//        //    access.Contents.RemoveAt(index);
//        //    access.Contents.Add(model);
//        //    return true;
//        //}



//        //public MovieModel RemoveMovie(string id)
//        //{
//        //    List<MovieModel> model = new();
//        //    var model = access.Contents;
//        //    var deletedUser=access.Contents.FirstOrDefault(u => u.Id == id);
//        //    deneme.Remove(deletedUser);

//        //    return(model);
//        //}

      
//         public ApiResponse GetMovie()
//                {
            
//                    return access;
//                }
//        public MovieModel GetMovie(string id)
//        {
//            return access.Contents.FirstOrDefault(n => n.Id == id);
//        }
      


//        public List<MovieModel> AddMovie(MovieModel model)
//        {
//            // List<MovieModel> list = access.Contents.ToList();
//            List<MovieModel> list = access.Contents;
//            list.Add(model);
//            return list;


//        }

//        public ApiResponse Update(ApiResponse model)
//        {
//            throw new NotImplementedException();
//        }

//        public MovieModel Remove(string id)
//        {
//            List<MovieModel> list = access.Contents;
             
//               var deletedUser=access.Contents.FirstOrDefault(u => u.Id == id);
//            return list.Remove(deletedUser);
//        }



//        //public MovieModel Remove(string id)
//        //{

//        //}


//    }
//    }

