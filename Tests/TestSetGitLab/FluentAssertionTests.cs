using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using RestSharp;
using RestSharpFramework.Models.GitLab;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Tests.TestSetGitLab
{
    internal class FluentAssertionTests : BaseTestClassGitLab
    {
        private readonly string expectedContentType = "application/json";
        private readonly string namespaceName = "Mikalai kabzar";// type your own namespace information here 
        private readonly string wrongNamespaceName = "wrongNamespaceName";
        private readonly string сontentTypeHeaderName = "Content-Type";
        private readonly string namespaceNameField = "name";

        private readonly int namespacesNumber = 1;

        [Test]
        public void TestGetNamespace()
        {
            RestResponse restResponse = Execute(GetNamespaceRequest);
            HttpStatusCode actualStatusCode = restResponse.StatusCode;
            string actualContentType = GetHeader(restResponse, сontentTypeHeaderName);
            string actualContent = restResponse.Content.ToString();
            List<NamespaceGitlab> namespaceList = Deserialize<List<NamespaceGitlab>>(actualContent);
            NamespaceGitlab actualNamespace = namespaceList.First();
            actualStatusCode.Should().Be(HttpStatusCode.OK);
            actualContentType.Should().Be(expectedContentType);
            namespaceList.Count.Should().BeLessOrEqualTo(namespacesNumber);
            namespaceList.Count.Should().BeGreaterOrEqualTo(namespacesNumber);
            actualNamespace.Name.Should().Be(namespaceName);
        }

        [Test]
        public void TestGetNamespaceFailed()
        {
            RestResponse restResponse = Execute(GetNamespaceRequest);
            HttpStatusCode actualStatusCode = restResponse.StatusCode;
            string actualContentType = GetHeader(restResponse, сontentTypeHeaderName);
            string actualContent = restResponse.Content.ToString();
            List<Dictionary<string, object>> namespaceList = Deserialize<List<Dictionary<string, object>>>(actualContent);
            Dictionary<string, object> actualNamespace = namespaceList.First();

            actualStatusCode.Should().Be(HttpStatusCode.BadRequest);
            actualContentType.Should().Be(expectedContentType);
            namespaceList.Count.Should().BeLessOrEqualTo(namespacesNumber + 1);
            namespaceList.Count.Should().BeGreaterOrEqualTo(namespacesNumber - 1);
            actualNamespace[namespaceNameField].ToString().Should().Be(namespaceName);
        }

        [Test]
        public void TestGetNamespaceFailedWithSotfAssertions()
        {
            RestResponse restResponse = Execute(GetNamespaceRequest);
            HttpStatusCode actualStatusCode = restResponse.StatusCode;
            string actualContentType = GetHeader(restResponse, сontentTypeHeaderName);
            string actualContent = restResponse.Content.ToString();
            List<Dictionary<string, object>> namespaceList = Deserialize<List<Dictionary<string, object>>>(actualContent);
            Dictionary<string, object> actualNamespace = namespaceList.First();

            using (new AssertionScope())
            {
                actualStatusCode.Should().Be(HttpStatusCode.GatewayTimeout);
                actualContentType.Should().Be(expectedContentType);
                namespaceList.Count.Should().Be(namespacesNumber);
                actualNamespace[namespaceNameField].ToString().Should().Be(wrongNamespaceName);
            };
        }
    }
}
