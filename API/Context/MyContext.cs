using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Convertation> Convertations { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StatusCode> StatusCodes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Role>()
            .HasMany(r => r.User)
            .WithOne(u => u.Role);

            modelBuilder.Entity<Attachment>()
            .HasOne(a => a.Convertation)
            .WithMany(c => c.Attachment);

            /*
            modelBuilder.Entity<AccountRole>()
                .HasKey(ar => new { ar.NIK, ar.RoleId });

            modelBuilder.Entity<AccountRole>()
            .HasOne(a => a.Account)
            .WithMany(ar => ar.AccountRole)
            .HasForeignKey(a => a.NIK);

            modelBuilder.Entity<AccountRole>()
            .HasOne(ar => ar.Role)
            .WithMany(r => r.AccountRole)
            .HasForeignKey(ar => ar.RoleId);

           

            modelBuilder.Entity<University>()
           .HasMany(u => u.Education)
           .WithOne(e => e.University);
            */

        }
    }
}
