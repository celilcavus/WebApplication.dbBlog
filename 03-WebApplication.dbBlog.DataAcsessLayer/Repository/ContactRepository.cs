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
    public class ContactRepository : IRepository<contact>
    {
        public int Add(contact item)
        {
            try
            {
                dbContext.conn.Open();
                string query = $@"Insert into {TableName.contact} 
                (
                name,
                lastname,
                phoneNumber,
                emailAdres,
                description
                ) 
                values
                (
                '{item.name}',
                '{item.lastname}',
                '{item.phoneNumber}',
                '{item.emailAdres}',
                '{item.description}'
                )";

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

        public List<contact> GetAll()
        {
            List<contact> contactlist = new List<contact>();
            try
            {
                dbContext.conn.Open();
                string query = $@"SELECT * FROM {TableName.contact}";

                SqlCommand command = new SqlCommand(query, dbContext.conn);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    contact cont = new contact();
                    cont.Id = int.Parse(read["Id"].ToString());
                    cont.name = read["name"].ToString();
                    cont.lastname = read["lastname"].ToString();
                    cont.phoneNumber = read["phoneNumber"].ToString();
                    cont.emailAdres = read["emailAdres"].ToString();
                    cont.description = read["description"].ToString();
                    contactlist.Add(cont);
                }
                return contactlist.ToList();
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

        public List<contact> getById(int id)
        {
            List<contact> contactlist = new List<contact>();
            try
            {
                dbContext.conn.Open();
                string query = $@"SELECT * FROM {TableName.contact} WHERE ID = {id}";

                SqlCommand command = new SqlCommand(query, dbContext.conn);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    contact cont = new contact();
                    cont.Id = int.Parse(read["Id"].ToString());
                    cont.name = read["name"].ToString();
                    cont.lastname = read["lastname"].ToString();
                    cont.phoneNumber = read["phoneNumber"].ToString();
                    cont.emailAdres = read["emailAdres"].ToString();
                    cont.description = read["description"].ToString();
                    contactlist.Add(cont);
                }
                return contactlist.ToList();
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

        public int Remove(contact item)
        {
            try
            {
                dbContext.conn.Open();
                string query = $@"DELETE FROM {TableName.contact} WHERE Id = {item.Id}";
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

        public int Update(contact item)
        {
            try
            {
                dbContext.conn.Open();
                string query = $@"UPDATE {TableName.contact}  SET
                
                name = '{item.name}',
                lastname = '{item.lastname}',
                phoneNumber = '{item.phoneNumber}',
                emailAdres = '{item.emailAdres}',
                description = '{item.description}'
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
