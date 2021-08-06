using RestSharp;
using RestSharpFramework.Models;
using System;
using System.Text.Json;

namespace RestSharpFramework.Factories
{
    public class TheDogAPIRequestFactory
    {
        private static string PRIVATE_TOKEN = Environment.GetEnvironmentVariable("TheDogApiKey", EnvironmentVariableTarget.User);

        protected static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

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
            RestRequest.AddHeader("x-api-key", PRIVATE_TOKEN);
            RestRequest.AddJsonBody(JsonSerializer.Serialize(vote, JsonOptions));
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
