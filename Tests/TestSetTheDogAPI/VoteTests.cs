using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using RestSharp;
using RestSharpFramework.Factories;
using RestSharpFramework.Models;
using System.Collections.Generic;
using System.Net;

namespace Tests.TestSetTheDogAPI
{
    internal class VoteTests : BaseTestClassTheDogAPI
    {
        private readonly string successMessage = "SUCCESS";
        private readonly string invalidAccountMessage = "INVALID_ACCOUNT";
        private readonly string messageField = "message";

        [Test]
        public void PostVoteTest()
        {
            RestResponse restVoteResponse = Execute(PostVoteRequest(VoteFactory.DefaultVote()));
            VotePostResponse voteResponse = Deserialize<VotePostResponse>(restVoteResponse.Content);

            using (new AssertionScope())
            {
                restVoteResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                voteResponse.Message.Should().Be(successMessage);
            }
        }

        [Test]
        public void GetVoteTest()
        {
            var testVote = VoteFactory.AnotherVote();
            RestResponse restVoteResponse = Execute(PostVoteRequest(testVote));
            VotePostResponse votePostResponse = Deserialize<VotePostResponse>(restVoteResponse.Content);

            RestResponse restVoteGetResponse = Execute(GetVoteRequest(votePostResponse.Id));
            VoteGetResponse voteGetResponse = Deserialize<VoteGetResponse>(restVoteGetResponse.Content);

            using (new AssertionScope())
            {
                restVoteResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                voteGetResponse.Id.Should().Be(votePostResponse.Id);
                voteGetResponse.Image_id.Should().Be(testVote.Image_id);
                voteGetResponse.Sub_id.Should().Be(testVote.Sub_id);
                voteGetResponse.Value.Should().Be(testVote.Value);
            }
        }

        [Test]
        public void DeleteVoteTest()
        {
            var testVote = VoteFactory.AnotherVote();
            RestResponse restVoteResponse = Execute(PostVoteRequest(testVote));
            VotePostResponse votePostResponse = Deserialize<VotePostResponse>(restVoteResponse.Content);

            RestResponse restVoteDeleteResponse = Execute(DeleteVoteRequest(votePostResponse.Id));
            Dictionary<string, string> deleteResponse = Deserialize<Dictionary<string, string>>(restVoteDeleteResponse.Content);
            
            using (new AssertionScope())
            {
                restVoteDeleteResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                deleteResponse[messageField].Should().Be(successMessage);
            }
        }

        [Test]
        public void DeleteVote2TimesTest()
        {
            var testVote = VoteFactory.AnotherVote();
            RestResponse restVoteResponse = Execute(PostVoteRequest(testVote));
            VotePostResponse votePostResponse = Deserialize<VotePostResponse>(restVoteResponse.Content);

            Execute(DeleteVoteRequest(votePostResponse.Id));
            RestResponse restVoteDeleteResponse = Execute(DeleteVoteRequest(votePostResponse.Id));
            Dictionary<string, object> deleteResponse = Deserialize<Dictionary<string, object>>(restVoteDeleteResponse.Content);

            using (new AssertionScope())
            {
                restVoteDeleteResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
                deleteResponse[messageField].ToString().Should().Be(invalidAccountMessage);
            }
        }
    }
}
