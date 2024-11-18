using laboratoriaProg.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace laboratoriaProg.Models;

public class AppDbContext : DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
    public DbSet<OrganizationEntity> Organizations { get; set; }


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
        modelBuilder.Entity<OrganizationEntity>()
            .OwnsOne(organization => organization.Address)
            .HasData(
                new {OrganizationEntityId = 101, City="Kraków", Street="św.Filipa 17"},
                new {OrganizationEntityId = 102, City="Warszawa", Street="Dworcowa 9"}
                );

        modelBuilder.Entity<OrganizationEntity>()
            .ToTable("organizations")
            .HasData(
                 new OrganizationEntity()
                 {
                     Id=101,
                     Name="WSEI",
                     NIP="21213356453",
                     REGION= "21213356453"
                 },
                 new OrganizationEntity()
                 {
                     Id= 102,
                     Name="PKP",
                     NIP="21453356453",
                     REGION= "21453356453"
                 }
            );
        
        modelBuilder.Entity<ContactEntity>()
            .HasOne<OrganizationEntity>(c=>c.Organization)
            .WithMany(o=>o.Contacts)
            .HasForeignKey(c=>c.OrganizationId);
        
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
                    OrganizationId = 101
                    
                },
                new ContactEntity()
                {
                    Id = 2,
                    FirstName = "Kamil",
                    LastName = "Nowacki",
                    BirthDate = new DateOnly(2000,12,11),
                    PhoneNumber = "531422234",
                    Email = "kn@gmail.com",
                    Created = DateTime.Now,
                    OrganizationId = 102
                }
            );
    }
}