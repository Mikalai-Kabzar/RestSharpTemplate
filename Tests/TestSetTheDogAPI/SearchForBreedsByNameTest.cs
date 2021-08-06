using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using RestSharp;
using RestSharpFramework.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Tests.TestSetTheDogAPI
{
    internal class SearchForBreedsByNameTest : BaseTestClassTheDogAPI
    {
        private readonly string notExistingBreedName = "SomeNotExistingName";

        [Test]
        public void Get12thBreedNameAndDataTest()
        {
            var numberOfBreedInList = 12;
            RestResponse restResponseListOfBreeds = Execute(GetListOfBreedsRequest);
            List<Breed> breedList = Deserialize<List<Breed>>(restResponseListOfBreeds.Content);
            var breedFromTheList = breedList[numberOfBreedInList - 1];
            var name2ndBreedFromListRequest = breedFromTheList.Name;

            RestResponse restResponseSearchQuery = Execute(GetBreedsByNameRequest(name2ndBreedFromListRequest));
            Breed breedFromSearchRequest = Deserialize<List<Breed>>(restResponseSearchQuery.Content).First();

            using (new AssertionScope())
            {
                breedFromTheList.Image = null;// as breed from the search query doesn't have 'image' part
                restResponseSearchQuery.StatusCode.Should().Be(HttpStatusCode.OK);
                breedFromSearchRequest.Should().BeEquivalentTo(breedFromTheList);
            }
        }

        [Test]
        public void GetNotExistingBreedNameAndDataTest()
        {

            RestResponse restResponseSearchQuery = Execute(GetBreedsByNameRequest(notExistingBreedName));
            List<Breed> breedListFromSearchRequest = Deserialize<List<Breed>>(restResponseSearchQuery.Content);

            using (new AssertionScope())
            {
                restResponseSearchQuery.StatusCode.Should().Be(HttpStatusCode.OK);
                breedListFromSearchRequest.Should().BeEmpty();
            }
        }

    }
}
