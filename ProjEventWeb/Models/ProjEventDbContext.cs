using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjEventWeb.Models;


namespace ProjEventWeb.Models
{
    public partial class ProjEventDbContext : DbContext
    {
        public ProjEventDbContext()
        {
        }

        public ProjEventDbContext(DbContextOptions<ProjEventDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlite("Data Source=local.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                        .ToTable("Events");
            modelBuilder.Entity<UserProfile>()
                        .ToTable("Users");
            modelBuilder.Entity<Cupom>()
                        .ToTable("Cupons");
            modelBuilder.Entity<UserEvent>()
                        .ToTable("UserEvent");

            OnModelCreatingPartial(modelBuilder);
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<UserProfile> Users { get; set; }
        public DbSet<UserEvent> UserEvent { get; set; }
        public DbSet<Cupom> Cupons { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
