using RestSharp;

namespace RestSharpFramework.Builders
{
    public class RequestBuilder
    {
        private const string PRIVATE_TOKEN = "UpdateToYourOwn_nwbUTeaSRo13QpKsdn2x123";

        public static RestRequest GetNamespaceRequest()
        {
            RestRequest RestRequest = new RestRequest("namespaces");
            RestRequest.Method = Method.GET;
            RestRequest.AddHeader("Private-Token", PRIVATE_TOKEN);
            return RestRequest;
        }

    }
}
