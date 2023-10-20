using Movies.api.Dto;

namespace Movies.api.Services;
public interface IUserService
{
    void Create(string username, string password);
    List<UserResponse> GetAll();
    string Authenticate(string username, string password);
    UserResponse GetUserById(int id);

}