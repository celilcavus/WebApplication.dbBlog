using System;

namespace _01_WebApplication.dbBlog.Entity.Views
{
    public class ViewPosts
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string imageUrl { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public int UserId { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public int CategoryId { get; set; }
        public string name { get; set; }
    }
}
