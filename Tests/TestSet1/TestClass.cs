
using NUnit.Framework;
using RestSharp;
using RestSharpFramework.Builders;

namespace Tests.TestSet1
{
    internal class TestClass
    {
        [Test]
        public void TestGetNamespace()
        {
            RestClient Client = ClientBuilder.GitLabClient();
            RestRequest GetRequest = RequestBuilder.GetNamespaceRequest();
            RestResponse RestResponse = (RestResponse)Client.Execute(GetRequest);
            string statusCode = ((int)RestResponse.StatusCode).ToString();
            Assert.AreEqual("200", statusCode);
        }

        [Test]
        public void TestGetNamespaceFailed()
        {
            RestClient Client = ClientBuilder.GitLabClient();
            RestRequest GetRequest = RequestBuilder.GetNamespaceRequest();
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
