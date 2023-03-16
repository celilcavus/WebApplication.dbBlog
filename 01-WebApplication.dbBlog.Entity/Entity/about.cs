namespace _01_WebApplication.dbBlog.Entity.Entity
{
    public class about
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }
        public string githup { get; set; }
        public string linkedin { get; set; }
        public string twitter { get; set; }
        public string facebook { get; set; }
        public string youtube { get; set; }
        public string instagram { get; set; }
        public bool? active { get; set; }
    }
}
