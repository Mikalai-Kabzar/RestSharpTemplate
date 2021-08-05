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
    internal class GetListOfBreedsTests : BaseTestClassTheDogAPI
    {
        private readonly string expectedContentType = "application/json; charset=utf-8";
        private readonly string expectedAccessControlExpose = "Pagination-Count, Pagination-Page, Pagination-Limit";
        private readonly string expecteBreedFor = "Small rodent hunting, lapdog";
        private readonly string firstBreedName = "Affenpinscher";
        private readonly string сontentTypeHeader = "Content-Type";
        private readonly string accessControlHeader = "access-control-expose-headers";
        private readonly string breedNameField = "name";
        private readonly string breedForField = "bred_for";
        private readonly int breedsNumber = 172;

        [Test]
        public void GetListOfBreedsTest()
        {
            RestResponse restResponse = Execute(GetListOfBreadsRequest);
            HttpStatusCode actualStatusCode = restResponse.StatusCode;
            string actualContentType = GetHeader(restResponse, сontentTypeHeader);
            string actualContent = restResponse.Content.ToString();
            List<Breed> breedList = Deserialize<List<Breed>>(actualContent);
            Breed actualBreed = breedList.First();

            using (new AssertionScope())
            {
                actualStatusCode.Should().Be(HttpStatusCode.OK);
                actualContentType.Should().Be(expectedContentType);
                breedList.Count.Should().BeLessOrEqualTo(breedsNumber);
                breedList.Count.Should().BeGreaterOrEqualTo(breedsNumber);
                actualBreed.name.Should().Be(firstBreedName);
            }
        }

        [Test]
        public void GetListOfBreedsTestFailed()
        {
            RestResponse restResponse = Execute(GetListOfBreadsRequest);
            HttpStatusCode actualStatusCode = restResponse.StatusCode;
            string actualContentType = GetHeader(restResponse, сontentTypeHeader);
            string actualContent = restResponse.Content.ToString();
            List<Dictionary<string, object>> breedList = Deserialize<List<Dictionary<string, object>>>(actualContent);
            Dictionary<string, object> actualBreed = breedList.First();

            using (new AssertionScope())
            {
                actualStatusCode.Should().Be(HttpStatusCode.BadRequest);
                actualContentType.Should().Be(expectedContentType);
                breedList.Count.Should().BeLessOrEqualTo(breedsNumber + 1);
                breedList.Count.Should().BeGreaterOrEqualTo(breedsNumber - 1);
                actualBreed[breedNameField].ToString().Should().Be(firstBreedName);
            }
        }

        [Test]
        public void GetListOfBreedsBreadForTest()
        {
            RestResponse restResponse = Execute(GetListOfBreadsRequest);
            HttpStatusCode actualStatusCode = restResponse.StatusCode;
            string actualAccessControl = GetHeader(restResponse, accessControlHeader);
            string actualContent = restResponse.Content.ToString();

            List<Dictionary<string, object>> breedList = Deserialize<List<Dictionary<string, object>>>(actualContent);
            Dictionary<string, object> actualBreed = breedList.First();
            Breed actualBreedObject = Deserialize<List<Breed>>(actualContent).First();

            using (new AssertionScope())
            {
                actualStatusCode.Should().Be(HttpStatusCode.OK);
                actualAccessControl.Should().Be(expectedAccessControlExpose);
                breedList.Count.Should().Be(breedsNumber);
                actualBreed[breedForField].ToString().Should().Be(expecteBreedFor);
                actualBreedObject.bred_for.Should().Be(expecteBreedFor);
            }
        }
    }
}
