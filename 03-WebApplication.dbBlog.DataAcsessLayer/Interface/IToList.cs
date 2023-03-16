using System.Collections.Generic;

namespace _03_WebApplication.dbBlog.DataAcsessLayer.Interface
{
    public interface IToList<T>
    {
        List<T> GetAll();
    }
}
