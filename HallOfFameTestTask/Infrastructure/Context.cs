using HallOfFameTestTask.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HallOfFameTestTask.Infrastructure;

/// <summary>
/// Контекст базы данных
/// </summary>
public class Context : DbContext
{
    /// <summary>
    /// Таблица, содержащая людей
    /// </summary>
    public DbSet<Person> Persons { get; set; }

    /// <summary>
    /// Таблица, содержащая навыки
    /// </summary>
    public DbSet<Skill> Skills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().OwnsMany(p => p.Skills);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source=HallOfFame.db");
    }
}
