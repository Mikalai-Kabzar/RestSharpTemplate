namespace RestSharpFramework.Models
{
    public class Breed
    {
        public string Bred_For { get; set; }
        public string Breed_Group { get; set; }
        public Height Height { get; set; }
        public int Id { get; set; }
        public Image Image { get; set; }
        public string LifeSpan { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public string ReferenceImageId { get; set; }
        public string Temperament { get; set; }
        public Weight Weight { get; set; }
    }

    public class Height
    {
        public string Imperial { get; set; }
        public string Metric { get; set; }
    }

    public class Image
    {
        public int Height { get; set; }
        public string Id { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
    }

    public class Weight
    {
        public string Imperial { get; set; }
        public string Metric { get; set; }
    }
}
