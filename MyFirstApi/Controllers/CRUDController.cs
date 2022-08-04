//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using MyFirstApi.Models;
//using MyFirstApi.Services;

//namespace MyFirstApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CRUDController : ControllerBase
//    {
//        MovieServices movieServices;
//        CrudRepository crudRepository = new();
//        public static Root access { get; set; }
//        public CRUDController()
//        {
            
//                access = DataAccess.getInstance();

            
//        }


//        [HttpGet()]
//        public Root GetMovie()
//        {
//            var result = crudRepository.GetMovie();
//            return result;

//        }


//        [HttpGet("{id}")]
//        public Root GetMovie(string id)
//        {
//            var result = crudRepository.GetMovie(id);
//              return result ;

//        }

//        //[HttpPost("post")]
//        //public List<Root> AddMovie(Root model)
//        //{
//        //    return crudRepository.AddMovie(model);
            

//        //}



//    }
//}
