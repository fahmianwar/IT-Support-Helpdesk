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

            modelBuilder.Entity<Staff>()
            .HasOne(s => s.User)
            .WithOne(u => u.Staff)
            .HasForeignKey<Staff>(s => s.Id );

            modelBuilder.Entity<Client>()
            .HasOne(c => c.User)
            .WithOne(u => u.Client)
            .HasForeignKey<Client>(c => c.Id);

            modelBuilder.Entity<User>()
            .HasMany(u => u.Convertation)
            .WithOne(cv => cv.User);

            modelBuilder.Entity<Convertation>()
            .HasMany(cv => cv.Attachment)
            .WithOne(a => a.Convertation);

            modelBuilder.Entity<Case>()
            .HasMany(cs => cs.Convertation)
            .WithOne(cv => cv.Case);

            modelBuilder.Entity<Priority>()
            .HasMany(p => p.Case)
            .WithOne(cs => cs.Priority);

            modelBuilder.Entity<Category>()
            .HasMany(ct => ct.Case)
            .WithOne(cs => cs.Category);

            modelBuilder.Entity<History>()
            .HasOne(h => h.Case)
            .WithMany(cs => cs.History);

            modelBuilder.Entity<StatusCode>()
            .HasMany(sc => sc.History)
            .WithOne(h => h.StatusCode);





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
