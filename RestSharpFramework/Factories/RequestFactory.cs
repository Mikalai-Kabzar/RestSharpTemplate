using RestSharp;

namespace RestSharpFramework.Factories
{
    public class RequestFactory
	{
        private const string PRIVATE_TOKEN = "nwbUTeaSRo13QpKsdn2x";

        public static RestRequest GetNamespaceRequest()
        {
            RestRequest RestRequest = new RestRequest("namespaces")
            {
                Method = Method.GET
            };
            RestRequest.AddHeader("Private-Token", PRIVATE_TOKEN);
            return RestRequest;
        }

    }
}
