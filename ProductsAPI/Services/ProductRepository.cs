using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductsAPI.Models;

namespace ProductsAPI.Services
{
    public class ProductRepository : IProductRepository
    {
        
        public void Insert(Product obj)
        {
            var fileNames = Directory.GetFiles(string.Format("{0}{1}",GetApplicationRoot(),@"\assets\products\")).OrderByDescending(f => f);

            string id = Path.GetFileNameWithoutExtension(fileNames.ToList()[0]);

            obj.Id = int.Parse(id)+1;
            // if (fileNames.Count > 0)
            //     productid = fileNames[0];
            using (StreamWriter file = File.CreateText(string.Format("{0}{1}{2}.json",GetApplicationRoot(),@"\assets\products\", obj.Id)))
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
            using (StreamReader r = new StreamReader(string.Format("{0}{1}{2}.json", GetApplicationRoot(),@"\assets\products\",id)))
            {
                var json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<Product>(json);
                
            }
        }

        public string GetApplicationRoot()
        {
            var exePath =   Path.GetDirectoryName(System.Reflection
                            .Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher=new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            if(appRoot.Contains("ProductsTest"))
                appRoot = appRoot.Replace("ProductsTest","ProductsAPI");
            return appRoot;
        }
    }
}