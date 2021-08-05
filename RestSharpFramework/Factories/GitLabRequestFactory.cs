using RestSharp;
using System;

namespace RestSharpFramework.Factories
{
    public class GitLabRequestFactory
    {
        private static string PRIVATE_TOKEN = Environment.GetEnvironmentVariable("GitLabAPIToken", EnvironmentVariableTarget.User);

        public static RestRequest GetNamespaceRequest()
        {
            RestRequest RestRequest = new RestRequest("namespaces");
            RestRequest.Method = Method.GET;
            RestRequest.AddHeader("Private-Token", PRIVATE_TOKEN);
            return RestRequest;
        }

    }
}
