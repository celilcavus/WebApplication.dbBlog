using System.Collections.Generic;

namespace _03_WebApplication.dbBlog.DataAcsessLayer.Interface
{
    public interface IGetById<T>
    {
        List<T> getById(int id);
    }
}
