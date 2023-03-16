using System;

namespace _01_WebApplication.dbBlog.Entity.Entity
{
    public class posts
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string imageUrl { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;
        public int authorId { get; set; }
        public int categoryId { get; set; }
        public string status { get; set; }
    }
}
