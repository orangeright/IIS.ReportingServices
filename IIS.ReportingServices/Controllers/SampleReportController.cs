using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using IIS.Utilities;

namespace IIS.ReportingServices.Controllers
{
    public class SampleReportController : Controller
    {
        // GET: SampleReport
        public async Task<ActionResult> Index()
        {
            //ViewBag.Result = await GetByIDforAPI();
            ViewBag.Result = await GetByAllforAPI();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Print()
        {
            string result = await GetByIDforAPI();
            Debug.WriteLine("No3");
            Debug.WriteLine(result);

            return View();

        }

        private async Task<string> GetByIDforAPI()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var json = new JavaScriptSerializer().Serialize(Parameters.ApiKey);

                using (var client = new HttpClient())
                {
                    var content = new StringContent(json, Encoding.UTF8, "application/x-www-form-urlencoded");

                    var response = await client.PostAsync(Parameters.ApiUri.Select.Replace("{id}", "2"), content);

                    Debug.WriteLine("No1");
                    Debug.WriteLine(response);
                    var result = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("No2");
                    Debug.WriteLine(result);
                    return result;
                }
            }
        }


        private async Task<string> GetByAllforAPI()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Dictionary<string, string> jsonDic = new Dictionary<string, string>();
                jsonDic["Apikey"] = Parameters.ApiKey.ApiKey;
                jsonDic["Offset"] = "0";

                var json = new JavaScriptSerializer().Serialize(jsonDic);

                using (var client = new HttpClient())
                {
                    var content = new StringContent(json, Encoding.UTF8, "application/x-www-form-urlencoded");

                    var response = await client.PostAsync(Parameters.ApiUri.Select.Replace("{id}", "4"), content);

                    Debug.WriteLine("No1");
                    Debug.WriteLine(response);
                    var result = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("No2");
                    Debug.WriteLine(result);
                    return result;
                }
            }
        }
    }

}
