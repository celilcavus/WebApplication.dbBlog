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
    public class PostTagsRepository : IRepository<post_tags>,IViewList<ViewPostTags>
    {
        public int Add(post_tags item)
        {
            try
            {
                dbContext.conn.Open();
                string query = $"Insert into {TableName.post_tags} (postId, tagsId) values ({item.postId},{item.tagsId})";

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

        public List<post_tags> GetAll()
        {
            List<post_tags> post = new List<post_tags>();


            try
            {
                dbContext.conn.Open();
                string query = $"SELECT * FROM {TableName.post_tags}";

                SqlCommand command = new SqlCommand(query, dbContext.conn);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    post_tags cat = new post_tags();
                    cat.Id = int.Parse(read["Id"].ToString());
                    cat.postId = int.Parse(read["postId"].ToString());
                    cat.tagsId = int.Parse(read["tagsId"].ToString());
                    post.Add(cat);

                }
                return post.ToList();
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

        public List<post_tags> getById(int id)
        {
            List<post_tags> post = new List<post_tags>();


            try
            {
                dbContext.conn.Open();
                string query = $"SELECT * FROM {TableName.post_tags} WHERE Id = {id}";

                SqlCommand command = new SqlCommand(query, dbContext.conn);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    post_tags cat = new post_tags();
                    cat.Id = int.Parse(read["Id"].ToString());
                    cat.postId = int.Parse(read["postId"].ToString());
                    cat.tagsId = int.Parse(read["tagsId"].ToString());
                    post.Add(cat);

                }
                return post.ToList();
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

        public List<ViewPostTags> GetView()
        {
            List<ViewPostTags> post = new List<ViewPostTags>();


            try
            {
                dbContext.conn.Open();
                string query = $"SELECT * FROM {ViewName.ViewPostTags}";

                SqlCommand command = new SqlCommand(query, dbContext.conn);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    ViewPostTags cat = new ViewPostTags();
                    cat.Id = int.Parse(read["Id"].ToString());
                    cat.name = read["name"].ToString();
                    cat.title = read["title"].ToString();
                    post.Add(cat);
                }
                return post.ToList();
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

        public int Remove(post_tags item)
        {
            try
            {
                dbContext.conn.Open();
                string query = $"DELETE FROM {TableName.post_tags} WHERE Id = {item.Id}";

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

        public int Update(post_tags item)
        {
            try
            {
                dbContext.conn.Open();
                string query = $"UPDATE {TableName.post_tags} SET postId = '{item.postId}', tagsId = '{item.tagsId}' WHERE Id = {item.Id}";

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
