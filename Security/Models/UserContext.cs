using Microsoft.EntityFrameworkCore;
using Entities;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Security.Models;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options)
    : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Usuario>()
        .ToCollection("users")
        .HasKey("UsuarioId")
        ;
    }

    public DbSet<Usuario> Users {get; set; } = null;
}