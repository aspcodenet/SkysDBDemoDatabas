using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SkysDBDemoDatabas.Models
{
    public partial class AuktionContext : DbContext
    {
        public AuktionContext()
        {
        }

        public AuktionContext(DbContextOptions<AuktionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Annon> Annons { get; set; }
        public virtual DbSet<Bild> Bilds { get; set; }
        public virtual DbSet<Bud> Buds { get; set; }
        public virtual DbSet<Inloggning> Inloggnings { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Auktion;Trusted_Connection=True;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Annon>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Beskrivning)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasColumnName("beskrivning");

                entity.Property(e => e.Slutdatumutc)
                    .HasColumnType("datetime")
                    .HasColumnName("slutdatumutc");

                entity.Property(e => e.Startdatumutc)
                    .HasColumnType("datetime")
                    .HasColumnName("startdatumutc");

                entity.Property(e => e.Startpris).HasColumnName("startpris");

                entity.Property(e => e.Titel)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("titel");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Annons)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Annonser_Users");
            });

            modelBuilder.Entity<Bild>(entity =>
            {
                entity.ToTable("Bild");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AnnonsId).HasColumnName("annons_id");

                entity.Property(e => e.Beskrivning)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasColumnName("beskrivning");

                entity.Property(e => e.Isstartbild).HasColumnName("isstartbild");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("url");

                entity.HasOne(d => d.Annons)
                    .WithMany(p => p.Bilds)
                    .HasForeignKey(d => d.AnnonsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bilder_Annonser");
            });

            modelBuilder.Entity<Bud>(entity =>
            {
                entity.ToTable("Bud");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AnnonsId).HasColumnName("annons_id");

                entity.Property(e => e.Belopp).HasColumnName("belopp");

                entity.Property(e => e.Datumutc)
                    .HasColumnType("datetime")
                    .HasColumnName("datumutc");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Annons)
                    .WithMany(p => p.Buds)
                    .HasForeignKey(d => d.AnnonsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bud_Annonser");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Buds)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bud_Users");
            });

            modelBuilder.Entity<Inloggning>(entity =>
            {
                entity.ToTable("Inloggning");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datumutc)
                    .HasColumnType("datetime")
                    .HasColumnName("datumutc");

                entity.Property(e => e.Ipadress)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("ipadress");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Inloggnings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inloggning_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adress)
                    .HasMaxLength(50)
                    .HasColumnName("adress");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Anvnamn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("anvnamn");

                entity.Property(e => e.Namn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("namn");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Postnummer).HasColumnName("postnummer");

                entity.Property(e => e.Stad)
                    .HasMaxLength(50)
                    .HasColumnName("stad");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
