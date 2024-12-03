using HallOfFameTestTask.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HallOfFameTestTask.Infrastructure;

public class Context : DbContext
{
    public DbSet<Person> Persons { get; set; }

    public DbSet<Skill> Skills { get; set; }

    public Context()
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().OwnsMany(p => p.Skills);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source=HallOfFame.db");
    }
}
