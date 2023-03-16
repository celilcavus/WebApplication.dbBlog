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
    public class AboutRepository : IRepository<about>
    {
        public int Add(about item)
        {
            try
            {
                dbContext.conn.Open();
                string query = $@"Insert into {TableName.about} 
                (
                title,
                description,
                imageUrl,
                githup,
                linkedin,
                twitter,
                facebook,
                youtube,
                instagram
                )
                
                values 
                (
                '{item.title}',
                '{item.description}',
                '{item.imageUrl}',
                '{item.githup}',
                '{item.linkedin}',
                '{item.twitter}',
                '{item.facebook}',
                '{item.youtube}',
                '{item.instagram}'
                )
                ";

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

        public List<about> GetAll()
        {
            List<about> aboutlist = new List<about>();
          
            try
            {
                dbContext.conn.Open();
                string query = $"SELECT * FROM {TableName.about}";

                SqlCommand command = new SqlCommand(query, dbContext.conn);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    about about = new about();
                    about.Id = int.Parse(read["Id"].ToString());
                    about.description = read["description"].ToString();
                    about.imageUrl = read["imageUrl"].ToString();
                    about.githup = read["githup"].ToString();
                    about.linkedin = read["linkedin"].ToString();
                    about.twitter = read["twitter"].ToString();
                    about.facebook = read["facebook"].ToString();
                    about.youtube = read["youtube"].ToString();
                    about.instagram = read["instagram"].ToString();
                    aboutlist.Add(about);
                }
                return aboutlist.ToList();
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

        public List<about> getById(int id)
        {
            List<about> aboutlist = new List<about>();
           

            try
            {
                dbContext.conn.Open();
                string query = $"SELECT * FROM {TableName.about} WHERE Id = {id}";

                SqlCommand command = new SqlCommand(query, dbContext.conn);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    about about = new about();
                    about.Id = int.Parse(read["Id"].ToString());
                    about.description = read["description"].ToString();
                    about.imageUrl = read["imageUrl"].ToString();
                    about.githup = read["githup"].ToString();
                    about.linkedin = read["linkedin"].ToString();
                    about.twitter = read["twitter"].ToString();
                    about.facebook = read["facebook"].ToString();
                    about.youtube = read["youtube"].ToString();
                    about.instagram = read["instagram"].ToString();
                    aboutlist.Add(about);
                }
                return aboutlist.ToList();
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

        public int Remove(about item)
        {
            try
            {
                dbContext.conn.Open();
                string query = $@"DELETE FROM {TableName.about} WHERE Id = {item.Id}";

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

        public int Update(about item)
        {
            try
            {
                dbContext.conn.Open();
                string query = $@"UPDATE {TableName.about} SET
               
                title = '{item.title}',
                description = '{item.description}',
                imageUrl = '{item.imageUrl}',
                githup = '{item.githup}',
                linkedin = '{item.linkedin}',
                twitter = '{item.twitter}',
                facebook = '{item.facebook}',
                youtube = '{item.youtube}',
                instagram = '{item.instagram}'
                
                WHERE Id = {item.Id}                
              
                ";

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
