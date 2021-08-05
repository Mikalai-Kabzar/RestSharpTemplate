using RestSharp;
using RestSharpFramework.Models;
using System;

namespace RestSharpFramework.Factories
{
    public class TheDogAPIRequestFactory
    {
        private static string PRIVATE_TOKEN = Environment.GetEnvironmentVariable("TheDogApiKey", EnvironmentVariableTarget.User);

        public static RestRequest GetListOfBreedsRequest()
        {
            RestRequest RestRequest = new RestRequest("breeds");
            RestRequest.Method = Method.GET;
            RestRequest.AddHeader("x-api-key", PRIVATE_TOKEN);
            return RestRequest;
        }

        public static RestRequest GetBreedsByNameRequest(string searchQuery)
        {
            RestRequest RestRequest = new RestRequest("breeds/search?q=" + searchQuery);
            RestRequest.Method = Method.GET;
            RestRequest.AddHeader("x-api-key", PRIVATE_TOKEN);
            return RestRequest;
        }
        public static RestRequest PostVoteRequest(Vote vote)
        {
            RestRequest RestRequest = new RestRequest("votes");
            RestRequest.Method = Method.POST;
            RestRequest.AddJsonBody(vote);
            RestRequest.AddHeader("x-api-key", PRIVATE_TOKEN);
            return RestRequest;
        }

        public static RestRequest GetVoteRequest(int voteId)
        {
            RestRequest RestRequest = new RestRequest("votes/"+voteId);
            RestRequest.Method = Method.GET;
            RestRequest.AddHeader("x-api-key", PRIVATE_TOKEN);
            return RestRequest;
        }

        public static RestRequest DeleteVoteRequest(int voteId)
        {
            RestRequest RestRequest = new RestRequest("votes/" + voteId);
            RestRequest.Method = Method.DELETE;
            RestRequest.AddHeader("x-api-key", PRIVATE_TOKEN);
            return RestRequest;
        }
    }
}
