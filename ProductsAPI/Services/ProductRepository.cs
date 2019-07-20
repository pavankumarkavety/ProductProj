using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductsAPI.Application.Models;

namespace ProductsAPI.Application.Services
{
    public class ProductRepository : IProductRepository
    {
        public void Insert(Product obj)
        {
            var fileNames = Directory.GetFiles(string.Format("{0}{1}",System.Environment.CurrentDirectory,@"\assets\products\")).OrderByDescending(f => f);

            string id = Path.GetFileNameWithoutExtension(fileNames.ToList()[0]);

            obj.Id = int.Parse(id)+1;
            // if (fileNames.Count > 0)
            //     productid = fileNames[0];
            using (StreamWriter file = File.CreateText(string.Format("{0}{1}{2}.json",System.Environment.CurrentDirectory,@"\assets\products\", obj.Id)))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, obj);
            }
        }

         private static string formatFileNumberForSort(string inVal)
        {
            int o;
            if (int.TryParse(Path.GetFileName(inVal), out o))
            {
                return string.Format("{0:0000000000}", o);
            }
            else
                return inVal;
        }

        public Product Select(int id)
        {
            //JObject o1 = JObject.Parse(File.ReadAllText(@"c:\videogames.json"));

            // read JSON directly from a file
            // using (StreamReader file = File.OpenText(@"C:\Work\Apps\ProductsProj\ProductsAPI\assets\products\1.json"))
            // using (JsonTextReader reader = new JsonTextReader(file))
            // {
            // JObject o2 = (JObject) JToken.ReadFrom(reader);
            // }
            

            
            using (StreamReader r = new StreamReader(string.Format("{0}{1}{2}.json",System.Environment.CurrentDirectory,@"\assets\products\",id)))
            {
                var json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<Product>(json);
                
            }
        }
    }
}