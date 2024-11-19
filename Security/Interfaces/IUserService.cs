using Entities;

namespace Security.Interfaces;

public interface IUserService
{
    public Task<List<User>> GetUsers();
    public Task<string> CreateUser(User nw);
    public Task<string> DeleteUser(String id);
    public Task<string> UpdateUser(User updt);
    public Task<User?> GetUserById(String id);
}