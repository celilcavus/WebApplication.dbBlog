using _01_WebApplication.dbBlog.Entity.Views;
using System.Collections.Generic;

namespace _03_WebApplication.dbBlog.DataAcsessLayer.Interface
{
    public interface IViewList<T>
    {
        List<T> GetView();
    }
}
