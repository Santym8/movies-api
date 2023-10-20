using Movies.api.Auth;
using Movies.api.DbContexts;
using Movies.api.Dto;
using Movies.api.Exceptions.User;
using Movies.api.Models;

namespace Movies.api.Services;
public class UserService : IUserService
{
    private readonly MoviesContext _context;
    private readonly IJwtUtils _jwtUtils;

    public UserService(MoviesContext context, IJwtUtils jwtUtils)
    {
        _context = context;
        _jwtUtils = jwtUtils;
    }

    public string Authenticate(string username, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == username);
        if (user is null || user.Username != username)
        {
            throw new BadCredentials();
        }

        if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            throw new BadCredentials();
        }

        return _jwtUtils.CreateToken(user);
    }

    public void Create(string username, string password)
    {
        var existingUser = _context.Users.FirstOrDefault(u => u.Username == username);
        if (existingUser != null)
        {
            throw new UserAlreadyExist();
        }

        var newUser = new User
        {
            Username = username,
            Password = BCrypt.Net.BCrypt.HashPassword(password)
        };

        _context.Users.Add(newUser);
        _context.SaveChanges();
    }

    public List<UserResponse> GetAll()
    {
        var users = _context.Users.ToList();
        return users.Select(u => new UserResponse(u.Id, u.Username)).ToList();
    }

    public UserResponse GetUserById(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user is null)
        {
            throw new UserNotFound();
        }
        return new UserResponse(user.Id, user.Username);
    }
}