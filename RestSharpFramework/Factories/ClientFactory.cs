using RestSharp;

namespace RestSharpFramework.Factories
{
    public class ClientFactory
	{
        private const string GITLAB_URL = "https://gitlab.com/api/v4/";
        private const string THEDOGAPI_URL = "https://api.thedogapi.com/v1/";
        public static RestClient GitLabClient() => new RestClient(GITLAB_URL)
        {
        };
        public static RestClient TheDogApiClient() => new RestClient(THEDOGAPI_URL)
        {
        };
        

    }

}
