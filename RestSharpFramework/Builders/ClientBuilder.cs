using RestSharp;

namespace RestSharpFramework.Builders
{
    public class ClientBuilder
    {
        private const string GITLAB_URL = "https://gitlab.com/api/v4/";

        public static RestClient GitLabClient() => new RestClient(GITLAB_URL)
        {

        };
    }

}
