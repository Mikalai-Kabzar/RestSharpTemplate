using System;

namespace RestSharpFramework.Models
{
    public class VoteGetResponse
    {
        public string country_code { get; set; }
        public DateTime created_at { get; set; }
        public int id { get; set; }
        public string image_id { get; set; }
        public string sub_id { get; set; }
        public string user_id { get; set; }
        public int value { get; set; }
    }
}
