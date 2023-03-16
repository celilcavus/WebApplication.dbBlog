namespace _03_WebApplication.dbBlog.DataAcsessLayer.Interface.BaseInterface
{
    public interface IRepository<T>:IAdd<T>,IRemove<T>,IUpdate<T>,IToList<T>,IGetById<T> where T : class
    {

    }
}
