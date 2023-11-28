using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Bufet000.Models;

namespace Bufet000.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Bufet000.Models.Zamowienia>? Zamowienia { get; set; }
        public DbSet<Bufet000.Models.Kanapki>? Kanapki { get; set; }
        public DbSet<Bufet000.Models.Kategoria>? Kategoria { get; set; }
        public DbSet<Bufet000.Models.Uzytkownik>? Uzytkownik { get; set; }
        public DbSet<Bufet000.Models.Status>? Status { get; set; }
    }
}