using login_app.Models;

namespace login_app.Data
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetByEmail(string email);
        User GetById(int id);
    }
}
