using RestSharpFramework.Models;

namespace RestSharpFramework.Factories
{
    public class VoteFactory
    {

        public static Vote DefaultVote()
        {
            return new Vote
            {
                Image_id = "asf2",
                Sub_id = "my-user-1234",
                Value = 1
            };
        }

        public static Vote AnotherVote()
        {
            return new Vote
            {
                Image_id = "asf3",
                Sub_id = "my-user-1",
                Value = 0
            };
        }
    }
}
