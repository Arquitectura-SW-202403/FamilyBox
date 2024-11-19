using Entities;

namespace Security.Interfaces;

public interface IUserService
{
    public Task<List<Usuario>> GetUsers();
    public Task<string> CreateUser(Usuario nw);
    public Task<string> DeleteUser(string id);
    public Task<string> UpdateUser(Usuario updt);
    public Task<Usuario?> GetUserById(string id);
}