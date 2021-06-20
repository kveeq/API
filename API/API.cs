using Newtonsoft.Json;
using RestSharp;

namespace TelegramBot
{
    public class API
    {
        public static string GetInfo(string ip)
        {
            string apiurl = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/iplocate/address?ip=";
            string apikey = "108a907830518b8f4ab0ab6ccbdb76911258faab";

            RestClient client = new RestClient(apiurl + ip);
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", $"Token {apikey}");
            IRestResponse response = client.Execute(request);

            string stream = response.Content;

            dynamic d = JsonConvert.DeserializeObject(stream);
            return d.location.value.ToString();
        }
    }
}
