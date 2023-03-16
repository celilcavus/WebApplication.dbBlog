using _01_WebApplication.dbBlog.Entity.Entity;
using _01_WebApplication.dbBlog.Entity.Views;
using _02_WebApplication.dbBlog.Model.dbContext;
using _03_WebApplication.dbBlog.DataAcsessLayer.Enum;
using _03_WebApplication.dbBlog.DataAcsessLayer.Interface;
using _03_WebApplication.dbBlog.DataAcsessLayer.Interface.BaseInterface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace _03_WebApplication.dbBlog.DataAcsessLayer.Repository
{
    public class PostRepository : IRepository<posts>, IViewList<ViewPosts>
    {
        public int Add(posts item)
        {

            try
            {
                dbContext.conn.Open();
                string query = $@"Insert into {TableName.posts} 
                    (title,
                    content,
                    imageUrl, 
                    created_at, 
                    updated_at, 
                    authorId,
                    categoryId,
                    status)
                    values 
                    (
                    '{item.title}',
                    '{item.content}',
                    '{item.imageUrl}',
                    '{item.created_at.ToString("yyyy/MM/dd")}',
                    '{item.updated_at.ToString("yyyy/MM/dd")}',
                     {item.authorId},
                     {item.categoryId},
                     '{item.status}')";

                SqlCommand command = new SqlCommand(query, dbContext.conn);
                int i = command.ExecuteNonQuery();
                return i;
            }
            catch (Exception)
            {
                dbContext.conn.Close();
                return 0;
            }
            finally
            {
                dbContext.conn.Close();
            }
        }

        public List<posts> GetAll()
        {
            List<posts> posts = new List<posts>();
            try
            {
                dbContext.conn.Open();
                string query = $@"SELECT * FROM {TableName.posts}";

                SqlCommand command = new SqlCommand(query, dbContext.conn);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {

                    posts cont = new posts();
                    cont.id = int.Parse(read["id"].ToString());
                    cont.title = read["title"].ToString();
                    cont.content = read["content"].ToString();
                    cont.imageUrl = read["imageUrl"].ToString();
                    cont.created_at = DateTime.Parse(read["created_at"].ToString());
                    cont.updated_at = DateTime.Parse(read["updated_at"].ToString());
                    cont.authorId = int.Parse(read["authorId"].ToString());
                    cont.categoryId = int.Parse(read["categoryId"].ToString());
                    cont.status = read["status"].ToString();
                    posts.Add(cont);
                }
                return posts.ToList();
            }
            catch (Exception)
            {
                dbContext.conn.Close();
                return null;
            }
            finally
            {
                dbContext.conn.Close();
            }
        }

        public List<posts> getById(int id)
        {
            List<posts> posts = new List<posts>();
            try
            {
                dbContext.conn.Open();
                string query = $@"SELECT * FROM {TableName.posts} WHERE id = {id}";

                SqlCommand command = new SqlCommand(query, dbContext.conn);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {

                    posts cont = new posts();
                    cont.id = int.Parse(read["id"].ToString());
                    cont.title = read["title"].ToString();
                    cont.content = read["content"].ToString();
                    cont.imageUrl = read["imageUrl"].ToString();
                    cont.created_at = DateTime.Parse(read["created_at"].ToString());
                    cont.updated_at = DateTime.Parse(read["updated_at"].ToString());
                    cont.authorId = int.Parse(read["authorId"].ToString());
                    cont.categoryId = int.Parse(read["categoryId"].ToString());
                    cont.status = read["status"].ToString();
                    posts.Add(cont);
                }
                return posts.ToList();
            }
            catch (Exception)
            {
                dbContext.conn.Close();
                return null;
            }
            finally
            {
                dbContext.conn.Close();
            }
        }

        public List<ViewPosts> GetView()
        {
            List<ViewPosts> posts = new List<ViewPosts>();
            try
            {
                dbContext.conn.Open();
                string query = $@"SELECT * FROM {ViewName.ViewPosts}";

                SqlCommand command = new SqlCommand(query, dbContext.conn);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    ViewPosts cont = new ViewPosts();
                    cont.id = int.Parse(read["id"].ToString());
                    cont.title = read["title"].ToString();
                    cont.content = read["content"].ToString();
                    cont.imageUrl = read["imageUrl"].ToString();
                    cont.created_at = DateTime.Parse(read["created_at"].ToString());
                    cont.updated_at = DateTime.Parse(read["updated_at"].ToString());
                    cont.UserId = int.Parse(read["UserId"].ToString());
                    cont.CategoryId = int.Parse(read["CategoryId"].ToString());
                    cont.username = read["username"].ToString();
                    cont.email = read["email"].ToString();
                    cont.name = read["name"].ToString();
                    posts.Add(cont);
                }
                return posts.ToList();
            }
            catch (Exception)
            {
                dbContext.conn.Close();
                return null;
            }
            finally
            {
                dbContext.conn.Close();
            }
        }

        public int Remove(posts item)
        {
            try
            {
                dbContext.conn.Open();
                string query = $@"UPDATE {TableName.posts} SET status = 0 WHERE id = {item.id}";

                SqlCommand command = new SqlCommand(query, dbContext.conn);
                int i = command.ExecuteNonQuery();
                return i;
            }
            catch (Exception)
            {
                dbContext.conn.Close();
                return 0;
            }
            finally
            {
                dbContext.conn.Close();
            }
        }

        public int Update(posts item)
        {
            try
            {
                dbContext.conn.Open();
                string query = $@"UPDATE {TableName.posts} SET 
                    title = '{item.title}',
                    content = '{item.content}',
                    imageUrl = '{item.imageUrl}',
                    updated_at = '{item.updated_at.ToString("yyyy/MM/dd")}', 
                    authorId = {item.authorId},
                    categoryId = {item.categoryId},     
                    status = '{item.status}'
                    WHERE id = {item.id}";

                SqlCommand command = new SqlCommand(query, dbContext.conn);
                int i = command.ExecuteNonQuery();
                return i;
            }
            catch (Exception)
            {
                dbContext.conn.Close();
                return 0;
            }
            finally
            {
                dbContext.conn.Close();
            }
        }
    }
}
