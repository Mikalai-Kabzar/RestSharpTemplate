using System.Text.Json.Serialization;

namespace RestSharpFramework.Models.GitLab
{
    public class NamespaceGitlab
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Kind { get; set; }
        public string FullPath { get; set; }
        public object ParentId { get; set; }
        public string AvatarUrl { get; set; }
        public string WebUrl { get; set; }
        public int BillableMembersCount { get; set; }
        public int SeatsInUse { get; set; }
        public int MaxSeatsUsed { get; set; }
        public string Plan { get; set; }
        public object TrialEndsOn { get; set; }
        public bool Trial { get; set; }
    }
}
