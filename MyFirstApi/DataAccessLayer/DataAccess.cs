using MyFirstApi.Models;
using Newtonsoft.Json;

namespace MyFirstApi.Services
{
    public class DataAccess
    {
        public static Root instance;
        

        public static Root Instance
        {
            get { return instance; }
        }




        public static Root getInstance()
        {
            string path = @"C:\Users\ismai\OneDrive\Masaüstü\contents.json";
            string json = System.IO.File.ReadAllText(path);
            instance = JsonConvert.DeserializeObject<Root>(json);

            return instance ;
        }
        public static Root getApi()
        {
            Root response = getInstance();

            return response;
        }




    }
}
