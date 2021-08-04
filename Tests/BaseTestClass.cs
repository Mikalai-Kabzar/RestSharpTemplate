using RestSharp;
using RestSharpFramework.Factories;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Tests
{
    internal class BaseTestClass
    {
        protected RestClient Client = ClientFactory.GitLabClient();
        protected RestRequest GetNamespaceRequest = RequestFactory.GetNamespaceRequest();
        protected RestResponse Execute(RestRequest request)
        {
            return (RestResponse)Client.Execute(request);
        }
        protected string GetHeader(RestResponse response, string headerName)
        {
            return response.Headers.FirstOrDefault(t => t.Name == headerName).Value.ToString();
        }
        //protected T DeserializeList<T>(string actualContent)
        //{
        //    return JsonSerializer.Deserialize<List<T>>(actualContent);
        //}
        protected T Deserialize<T>(string actualContent)
        {
            return JsonSerializer.Deserialize<T>(actualContent);
        }
    }
}
