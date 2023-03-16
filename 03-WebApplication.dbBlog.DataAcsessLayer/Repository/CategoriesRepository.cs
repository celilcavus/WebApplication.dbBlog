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
    public class CategoriesRepository : IRepository<categories>
    {
       
        public int Add(categories item)
        {
            try
            {
                dbContext.conn.Open();
                string query = $"Insert into {TableName.categories} (name, description) values ('{item.name}','{item.description}')";

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

        

        public List<categories> GetAll()
        {
            List<categories> categoriesList = new List<categories>();
           
           
            try
            {
                dbContext.conn.Open();
                string query = $"SELECT * FROM {TableName.categories}";

                SqlCommand command = new SqlCommand(query, dbContext.conn);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    categories cat = new categories();
                    cat.Id = int.Parse(read["Id"].ToString());
                    cat.name = read["name"].ToString();
                    cat.description = read["description"].ToString();
                    categoriesList.Add(cat);
                    
                }
                return categoriesList.ToList();
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

        public List<categories> getById(int id)
        {
            List<categories> categoriesList = new List<categories>();
            

            try
            {
                dbContext.conn.Open();
                string query = $"SELECT * FROM {TableName.categories} WHERE Id = {id}";

                SqlCommand command = new SqlCommand(query, dbContext.conn);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    categories cat = new categories();
                    cat.Id = int.Parse(read["Id"].ToString());
                    cat.name = read["name"].ToString();
                    cat.description = read["description"].ToString();
                    categoriesList.Add(cat);

                }
                return categoriesList.ToList();
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
      
     
        public int Remove(categories item)
        {
            try
            {
                dbContext.conn.Open();
                string query = $"DELETE FROM {TableName.categories} WHERE Id = {item.Id}";

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

        public int Update(categories item)
        {
            try
            {
                dbContext.conn.Open();
                string query = $"UPDATE {TableName.categories}  SET name = '{item.name}', description = '{item.description}' WHERE Id = {item.Id}";

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
