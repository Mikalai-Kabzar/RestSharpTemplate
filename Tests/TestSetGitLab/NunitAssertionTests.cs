using NUnit.Framework;
using RestSharp;
using RestSharpFramework.Models.GitLab;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Tests.TestSetGitLab
{
    internal class NunitAssertionTests : BaseTestClassGitLab
    {
        private readonly string expectedContentType = "application/json";
        private readonly string namespaceName = "Mikalai kabzar";
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

            Assert.AreEqual(HttpStatusCode.OK, actualStatusCode);
            Assert.AreEqual(expectedContentType, actualContentType);
            Assert.AreEqual(namespacesNumber, namespaceList.Count);
            Assert.AreEqual(namespaceName, actualNamespace.name);
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

            Assert.AreEqual(HttpStatusCode.BadRequest, actualStatusCode);
            Assert.AreEqual(expectedContentType, actualContentType);
            Assert.AreEqual(namespacesNumber - 2, namespaceList.Count);
            Assert.AreEqual(namespaceName, actualNamespace[namespaceNameField].ToString());
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

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, actualStatusCode);
                Assert.AreEqual(expectedContentType, actualContentType);
                Assert.AreEqual(namespacesNumber + 10, namespaceList.Count);
                Assert.AreEqual(namespaceName, actualNamespace[namespaceNameField].ToString());
            });
        }
    }
}
