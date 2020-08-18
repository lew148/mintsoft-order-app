using System.Net;
using mintsoft_order_app.Models;
using Newtonsoft.Json;

namespace mintsoft_order_app
{
    public static class ApiHelper
    {
        public static string SendOrderToMintSoftApi(OrderModel model)
        {
            using var wc = new WebClient();
            wc.Headers.Add("Content-Type",ApiConstants.ContentType);
            return wc.UploadString(GetFullUrl(ApiConstants.OrderUrl),
                WebRequestMethods.Http.Put,
                JsonConvert.SerializeObject(model));
        }

        public static string GetCountriesFromMintSoftApi()
        {
            using var wc = new WebClient();
            return wc.DownloadString(GetFullUrl(ApiConstants.AllCountriesUrl));
        }

        private static string GetFullUrl(string baseUrl) => baseUrl + ApiConstants.AuthQueryParams + System.IO.File.ReadAllText("api-key.txt");
    }
}