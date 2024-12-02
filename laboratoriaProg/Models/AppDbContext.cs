using laboratoriaProg.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace laboratoriaProg.Models;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ContactEntity> Contacts { get; set; }
    public DbSet<OrganizationEntity> Organizations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        string USER_ROLE_ID = Guid.NewGuid().ToString();
        string ADMIN_ROLE_ID = Guid.NewGuid().ToString();

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = USER_ROLE_ID,
                Name = "user",
                NormalizedName = "USER"
            },
            new IdentityRole
            {
                Id = ADMIN_ROLE_ID,
                Name = "admin",
                NormalizedName = "ADMIN"
            }
        );

        var user = new IdentityUser
        {
            Id = Guid.NewGuid().ToString(),
            Email = "user@domain.com",
            NormalizedEmail = "USER@DOMAIN.COM",
            UserName = "user",
            NormalizedUserName = "USER",
            EmailConfirmed = true
        };

        var admin = new IdentityUser
        {
            Id = Guid.NewGuid().ToString(),
            Email = "admin@domain.com",
            NormalizedEmail = "ADMIN@DOMAIN.COM",
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            EmailConfirmed = true
        };

        PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
        user.PasswordHash = hasher.HashPassword(user, "User123!");
        admin.PasswordHash = hasher.HashPassword(admin, "Admin123!");

        modelBuilder.Entity<IdentityUser>().HasData(user, admin);

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = admin.Id
            },
            new IdentityUserRole<string>
            {
                RoleId = USER_ROLE_ID,
                UserId = user.Id
            }
        );

        modelBuilder.Entity<OrganizationEntity>().HasData(
            new OrganizationEntity
            {
                Id = 101,
                Name = "WSEI",
                NIP = "283792834",
                REGON = "2837294234",
                REGION = "Małoposka"
            },
            new OrganizationEntity
            {
                Id = 102,
                Name = "PKP",
                NIP = "283792834",
                REGON = "2837294234",
                REGION = "Wielkopolska"
            }
        );

        modelBuilder.Entity<ContactEntity>().HasData(
            new ContactEntity
            {
                Id = 1,
                FirstName = "Adam",
                LastName = "Kowal",
                Email = "adam@wsei.edu.pl",
                PhoneNumber = "123456789",
                BirthDate = new DateOnly(2000, 10, 10),
                Created = DateTime.Now,
                OrganizationId = 101
            },
            new ContactEntity
            {
                Id = 2,
                FirstName = "Ewa",
                LastName = "Kowal",
                Email = "ewa@wsei.edu.pl",
                PhoneNumber = "123456789",
                BirthDate = new DateOnly(2000, 10, 10),
                Created = DateTime.Now,
                OrganizationId = 102
            }
        );

        modelBuilder.Entity<OrganizationEntity>().OwnsOne(o => o.Address).HasData(
            new { OrganizationEntityId = 101, City = "Kraków", Street = "św. Filipa 17" },
            new { OrganizationEntityId = 102, City = "Warszawa", Street = "Dworcowa 9" }
        );
    }
}
