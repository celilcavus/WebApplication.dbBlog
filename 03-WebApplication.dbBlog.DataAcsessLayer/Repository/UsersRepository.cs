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
    public class UsersRepository : IRepository<users>
    {
        //Id, username, password, email, bio, profile_picture_url
        public int Add(users item)
        {
            try
            {
                dbContext.conn.Open();
                string query = $@"Insert into {TableName.users} ( username, password, email, bio, profile_picture_url) values ('{item.username}','{item.password}','{item.email}','{item.bio}','{item.profile_picture_url}')";

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

        public List<users> GetAll()
        {
            List<users> userlist = new List<users>();

            try
            {
                dbContext.conn.Open();
                string query = $"SELECT * FROM {TableName.users}";

                SqlCommand command = new SqlCommand(query, dbContext.conn);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    users user = new users();
                    user.Id = int.Parse(read["Id"].ToString());
                    user.username = read["username"].ToString();
                    user.password = read["password"].ToString();
                    user.email = read["email"].ToString();
                    user.bio = read["bio"].ToString();
                    user.profile_picture_url = read["profile_picture_url"].ToString();
                    userlist.Add(user);
                }
                return userlist.ToList();
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

        public List<users> getById(int id)
        {
            List<users> userlist = new List<users>();

            try
            {
                dbContext.conn.Open();
                string query = $"SELECT * FROM {TableName.users} WHERE Id = {id}";

                SqlCommand command = new SqlCommand(query, dbContext.conn);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    users user = new users();
                    user.Id = int.Parse(read["Id"].ToString());
                    user.username = read["username"].ToString();
                    user.password = read["password"].ToString();
                    user.email = read["email"].ToString();
                    user.bio = read["bio"].ToString();
                    user.profile_picture_url = read["profile_picture_url"].ToString();
                    userlist.Add(user);
                }
                return userlist.ToList();
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

        public int Remove(users item)
        {
            try
            {
                dbContext.conn.Open();
                string query = $@"DELETE FROM {TableName.users} WHERE Id = {item.Id}";

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

        public int Update(users item)
        {
            try
            {
                dbContext.conn.Open();
                string query = $@"UPDATE {TableName.users} SET
                username  = '{item.username}',
                password = '{item.password}',
                email = '{item.email}', 
                bio = '{item.bio}',
                profile_picture_url ? '{item.profile_picture_url}'
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
