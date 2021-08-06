using System;

namespace RestSharpFramework.Models
{
    public class VoteGetResponse
    {
        public string Country_code { get; set; }
        public DateTime Created_at { get; set; }
        public int Id { get; set; }
        public string Image_id { get; set; }
        public string Sub_id { get; set; }
        public string User_id { get; set; }
        public int Value { get; set; }
    }
}
