using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Shop.Context.Model
{
    public partial class ShopContext : DbContext
    {
        public ShopContext()
        {
        }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Basket> Baskets { get; set; } = null!;
        public virtual DbSet<Characteristic> Characteristics { get; set; } = null!;
        public virtual DbSet<History> Histories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductBasket> ProductBaskets { get; set; } = null!;
        public virtual DbSet<TypeProduct> TypeProducts { get; set; } = null!;
        public virtual DbSet<UserProfile> UserProfiles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost,1433;initial catalog=Final;user id=sa;password=yourStrong(!)Password");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Cyrillic_General_CI_AS");

            modelBuilder.Entity<Basket>(entity =>
            {
                entity.ToTable("Basket");

                entity.HasIndex(e => e.UserId, "UQ__Basket__1788CC4DFFEEF5FA")
                    .IsUnique();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Basket)
                    .HasForeignKey<Basket>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Basket__UserId__30F848ED");
            });

            modelBuilder.Entity<Characteristic>(entity =>
            {
                entity.ToTable("Characteristic");

                entity.Property(e => e.ProcessorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ScreenDiagonal).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("History");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Basket)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.BasketId)
                    .HasConstraintName("FK__History__BasketI__31EC6D26");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Decription)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoUrl)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("PhotoURL");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Characteristic)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CharacteristicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__Charact__32E0915F");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__TypeId__33D4B598");
            });

            modelBuilder.Entity<ProductBasket>(entity =>
            {
                entity.ToTable("ProductBasket");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Basket)
                    .WithMany(p => p.ProductBaskets)
                    .HasForeignKey(d => d.BasketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductBa__Baske__35BCFE0A");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductBaskets)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductBa__Produ__34C8D9D1");
            });

            modelBuilder.Entity<TypeProduct>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__TypeProd__516F03B5E4802F68");

                entity.ToTable("TypeProduct");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserProf__1788CC4C62D09F98");

                entity.ToTable("UserProfile");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
