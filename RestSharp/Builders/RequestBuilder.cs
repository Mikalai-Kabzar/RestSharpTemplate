using RestSharp;

namespace RestSharpFramework.Builders
{
    public class RequestBuilder
    {
        private const string PRIVATE_TOKEN = "nwbUTeaSRo13QpKsdn2x";

        public static RestRequest GetNamespaceRequest()
        {
            RestRequest RestRequest = new RestRequest("namespaces");
            RestRequest.Method = Method.GET;
            RestRequest.AddHeader("Private-Token", PRIVATE_TOKEN);
            return RestRequest;
        }

    }
}
