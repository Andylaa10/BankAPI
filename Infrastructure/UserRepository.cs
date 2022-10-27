using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly RepositoryDbContext _context;

    public UserRepository(RepositoryDbContext context)
    {
        _context = context;
    }

    public User GetUserByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email) ?? throw new KeyNotFoundException("There was no user with email");
    }

    public User CreateNewUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;

    }
}