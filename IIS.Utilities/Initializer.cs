using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Web;

namespace IIS.Utilities
{
    public static class Initializer
    {
        public static void Initialize()
        {
            Parameters.ApiKey = JsonConvert.DeserializeObject<ApiKeys>(GetJson("ApiKey_Personal.json"));
            Parameters.ApiUri = JsonConvert.DeserializeObject<ApiUris>(GetJson("ApiUri_Local.json"));
        }

        private static string GetJson(string jsonFile)
        {
            string json;
            string path = Path.Combine(HttpContext.Current.Server.MapPath("./"), "App_Data", jsonFile);
            using (var reader = new StreamReader(path, Encoding.GetEncoding("utf-8")))
            {
                json = reader.ReadToEnd();
            }

            return json;
        }
    }
}