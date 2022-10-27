using Domain;

namespace Application.Interfaces;

public interface IUserRepository
{
    User GetUserByEmail(string email);

    User CreateNewUser(User user);
}