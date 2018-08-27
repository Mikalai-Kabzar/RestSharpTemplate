
using NUnit.Framework;
using RestSharp;
using RestSharpFramework.Factories;

namespace Tests.TestSet1
{
    internal class TestClass
    {
        [Test]
        public void TestGetNamespace()
        {
            RestClient Client = ClientFactory.GitLabClient();
            RestRequest GetRequest = RequestFactory.GetNamespaceRequest();
            RestResponse RestResponse = (RestResponse)Client.Execute(GetRequest);
            string statusCode = ((int)RestResponse.StatusCode).ToString();
            Assert.AreEqual("200", statusCode);
        }

        [Test]
        public void TestGetNamespaceFailed()
        {
            RestClient Client = ClientFactory.GitLabClient();
            RestRequest GetRequest = RequestFactory.GetNamespaceRequest();
            RestResponse RestResponse = (RestResponse)Client.Execute(GetRequest);
            string statusCode = ((int)RestResponse.StatusCode).ToString();
            Assert.AreEqual("201", statusCode);
        }

        [Test]
        public void Test2()
        {
            Assert.IsTrue(true);
        }

    }
}
