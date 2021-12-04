using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QualificationTask.Models
{
    public partial class IntivePatronageContext : DbContext
    {
        public IntivePatronageContext()
        {
        }

        public IntivePatronageContext(DbContextOptions<IntivePatronageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=IntivePatronage;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.City).IsFixedLength(true);

                entity.Property(e => e.Country).IsFixedLength(true);

                entity.Property(e => e.HouseNumber).IsFixedLength(true);

                entity.Property(e => e.LocalNumber).IsFixedLength(true);

                entity.Property(e => e.PostCode).IsFixedLength(true);

                entity.Property(e => e.Street).IsFixedLength(true);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateOfBirth).HasPrecision(0);

                entity.Property(e => e.FirstName).IsFixedLength(true);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Address");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
