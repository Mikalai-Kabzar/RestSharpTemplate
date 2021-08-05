using RestSharp;
using RestSharpFramework.Factories;
using RestSharpFramework.Models;

namespace Tests
{
    public class BaseTestClassTheDogAPI : BaseTestClass
    {
        protected BaseTestClassTheDogAPI()
        {
            Client = ClientFactory.TheDogApiClient();
        }

        protected RestRequest GetListOfBreadsRequest => TheDogAPIRequestFactory.GetListOfBreedsRequest();
        protected RestRequest GetBreadsByNameRequest(string searchQuery) => TheDogAPIRequestFactory.GetBreedsByNameRequest(searchQuery);
        protected RestRequest PostVoteRequest(Vote vote) => TheDogAPIRequestFactory.PostVoteRequest(vote);
        protected RestRequest GetVoteRequest(int voteID) => TheDogAPIRequestFactory.GetVoteRequest(voteID);
        protected RestRequest DeleteVoteRequest(int voteID) => TheDogAPIRequestFactory.DeleteVoteRequest(voteID);
    }
}
