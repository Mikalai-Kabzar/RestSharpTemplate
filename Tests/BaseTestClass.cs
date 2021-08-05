using RestSharp;
using System.Linq;
using System.Text.Json;

namespace Tests
{
    public class BaseTestClass
    {
        protected RestClient Client;
        protected RestResponse Execute(RestRequest request)
        {
            return (RestResponse)Client.Execute(request);
        }
        protected string GetHeader(RestResponse response, string headerName)
        {
            return response.Headers.FirstOrDefault(t => t.Name == headerName).Value.ToString();
        }
        protected T Deserialize<T>(string actualContent)
        {
            return JsonSerializer.Deserialize<T>(actualContent);
        }
    }
}
