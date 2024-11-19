using DnsClient.Protocol;
using Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using Security.Interfaces;
using Security.Models;

namespace Security.Services;

public class UserService : IUserService
{
    private readonly UserContext _context;

    public UserService(UserContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserById(String id)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<List<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<string> CreateUser(User nw) 
    {  
        try {

            var user =  _context.Users.FirstOrDefault(u => u.id == nw.id);
            Console.WriteLine(user);
            if (user != null) return "Usuario ya existente";
            _context.Add(nw);
            await _context.SaveChangesAsync();
            return "OK";
        } catch (Exception e) {
            Console.WriteLine(e);
            return "Sucedió algo en el servidor";
        }
    }

    public async Task<string> UpdateUser(User updt) 
    {
        try {
            _context.Entry(updt).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return "OK";
        }
        catch (Exception e) {
            Console.WriteLine(e);
            return "Sucedió algo en el servidor";
        }


    }

    public async Task<string> DeleteUser(String id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return "Este usuario no existe";

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return "OK";
    }

    private bool UserExist(String id)
    {
        return _context.Users.Any(e => e.id == id);
    }
}