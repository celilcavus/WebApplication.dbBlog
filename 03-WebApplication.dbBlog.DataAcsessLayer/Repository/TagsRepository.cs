using _01_WebApplication.dbBlog.Entity.Entity;
using _02_WebApplication.dbBlog.Model.dbContext;
using _03_WebApplication.dbBlog.DataAcsessLayer.Enum;
using _03_WebApplication.dbBlog.DataAcsessLayer.Interface.BaseInterface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace _03_WebApplication.dbBlog.DataAcsessLayer.Repository
{
    public class TagsRepository : IRepository<tags>
    {
        public int Add(tags item)
        {
            try
            {
                dbContext.conn.Open();
                string query = $"Insert into {TableName.tags} (name, description) values ('{item.name}','{item.description}')";

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

        public List<tags> GetAll()
        {
            List<tags> tagslist = new List<tags>();
            

            try
            {
                dbContext.conn.Open();
                string query = $"SELECT * FROM {TableName.tags}";

                SqlCommand command = new SqlCommand(query, dbContext.conn);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    tags cat = new tags();
                    cat.Id = int.Parse(read["Id"].ToString());
                    cat.name = read["name"].ToString();
                    cat.description = read["description"].ToString();
                    tagslist.Add(cat);

                }
                return tagslist.ToList();
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

        public List<tags> getById(int id)
        {
            List<tags> tagslist = new List<tags>();
            

            try
            {
                dbContext.conn.Open();
                string query = $"SELECT * FROM {TableName.tags} WHERE Id = {id}";

                SqlCommand command = new SqlCommand(query, dbContext.conn);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    tags cat = new tags();
                    cat.Id = int.Parse(read["Id"].ToString());
                    cat.name = read["name"].ToString();
                    cat.description = read["description"].ToString();
                    tagslist.Add(cat);

                }
                return tagslist.ToList();
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

        public int Remove(tags item)
        {
            try
            {
                dbContext.conn.Open();
                string query = $"DELETE FROM {TableName.tags} WHERE Id = {item.Id}";

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

        public int Update(tags item)
        {
            try
            {
                dbContext.conn.Open();
                string query = $"UPDATE {TableName.tags}  SET name = '{item.name}', description = '{item.description}' WHERE Id = {item.Id}";

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
