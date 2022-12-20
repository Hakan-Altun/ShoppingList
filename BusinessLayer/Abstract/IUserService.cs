using Entities;

namespace BusinessLayer.Abstract
{
    public interface IUserService : IGenericService<User>
    {
        User GetUser(string userEmail, string userPassword);
        User GetByName(string userEmail);
    }
}
