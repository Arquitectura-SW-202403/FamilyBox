using Microsoft.EntityFrameworkCore;
using Entities;

namespace Security.Models;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options)
    : base(options)
    {

    }

    public DbSet<User> Users {get; set; } = null;
}