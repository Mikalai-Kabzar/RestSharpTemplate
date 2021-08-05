using RestSharpFramework.Models;

namespace RestSharpFramework.Factories
{
    public class VoteFactory
    {

        public static Vote DefaultVote()
        {
            return new Vote
            {
                image_id = "asf2",
                sub_id = "my-user-1234",
                value = 1
            };
        }

        public static Vote AnotherVote()
        {
            return new Vote
            {
                image_id = "asf3",
                sub_id = "my-user-1",
                value = 0
            };
        }
    }
}
