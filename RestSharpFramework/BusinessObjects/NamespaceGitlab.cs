namespace RestSharpFramework.BusinessObjects
{
    public class NamespaceGitlab
    {
        public int id { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string kind { get; set; }
        public string full_path { get; set; }
        public object parent_id { get; set; }
        public string avatar_url { get; set; }
        public string web_url { get; set; }
        public int billable_members_count { get; set; }
        public int seats_in_use { get; set; }
        public int max_seats_used { get; set; }
        public string plan { get; set; }
        public object trial_ends_on { get; set; }
        public bool trial { get; set; }
    }
}
