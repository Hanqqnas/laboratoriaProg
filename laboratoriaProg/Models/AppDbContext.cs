using Microsoft.EntityFrameworkCore;

namespace laboratoriaProg.Models;

public class AppDbContext : DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }


    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "contacts.db");
    }

    private string DbPath { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"DataSource={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>()
            .HasData(
                new ContactEntity()
                {
                    Id = 1,
                    FirstName = "Kamil",
                    LastName = "Kowalski",
                    BirthDate = new DateOnly(2000,10,10),
                    PhoneNumber = "531432234",
                    Email = "kk@wp.pl",
                    Created = DateTime.Now,
                    
                },
                new ContactEntity()
                {
                    Id = 2,
                    FirstName = "Kamil",
                    LastName = "Nowacki",
                    BirthDate = new DateOnly(2000,12,11),
                    PhoneNumber = "531422234",
                    Email = "kn@gmail.com",
                    Created = DateTime.Now
                }
            );
    }
}