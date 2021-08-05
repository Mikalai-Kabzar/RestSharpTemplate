using RestSharp;
using RestSharpFramework.Factories;

namespace Tests
{

    public class BaseTestClassGitLab : BaseTestClass
    {
        protected BaseTestClassGitLab()
        {
            Client = ClientFactory.GitLabClient();
        }

        protected RestRequest GetNamespaceRequest = GitLabRequestFactory.GetNamespaceRequest();
    }
}
