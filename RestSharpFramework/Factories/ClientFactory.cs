using RestSharp;

namespace RestSharpFramework.Factories
{
    public class ClientFactory
	{
        private const string GITLAB_URL = "https://gitlab.com/api/v4/";

        public static RestClient GitLabClient() => new RestClient(GITLAB_URL)
        {

        };
    }

}
