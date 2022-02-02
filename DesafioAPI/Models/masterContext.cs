using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DesafioAPI
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cooperado> Cooperado { get; set; }
        public virtual DbSet<Cooperativa> Cooperativa { get; set; }
        public virtual DbSet<ContatosFavoritos> ContatosFavoritos { get; set; }
        public virtual DbSet<TipoChavePix> TipoChavePix { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=NOTEBRUTO\\SQLEXPRESS; Initial Catalog=master;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cooperado>(entity =>
            {
                entity.HasKey(e => e.ICodCooperado);

                entity.Property(e => e.ICodCooperado).HasColumnName("iCodCooperado");

                entity.Property(e => e.ICodCooperativa).HasColumnName("iCodCooperativa");

                entity.Property(e => e.IContaCorrente).HasColumnName("iContaCorrente");

                entity.Property(e => e.SNomeCooperado)
                    .HasColumnName("sNomeCooperado")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ICodCooperativaNavigation)
                    .WithMany(p => p.InverseICodCooperativaNavigation)
                    .HasForeignKey(d => d.ICodCooperativa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CooperadoCooperativa");
            });

            modelBuilder.Entity<Cooperativa>(entity =>
            {
                entity.HasKey(e => e.ICodCooperativa);

                entity.Property(e => e.ICodCooperativa).HasColumnName("iCodCooperativa");

                entity.Property(e => e.SDescricao)
                    .HasColumnName("sDescricao")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContatosFavoritos>(entity =>
            {
                entity.HasKey(e => e.ICodFavorito);

                entity.Property(e => e.ICodFavorito).HasColumnName("iCodFavorito");

                entity.Property(e => e.ICodCooperado).HasColumnName("iCodCooperado");

                entity.Property(e => e.ICodPix).HasColumnName("iCodPix");

                entity.Property(e => e.SChavePix)
                    .HasColumnName("sChavePix")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SNomeContatoFavorito).HasColumnName("sNomeContatoFavorito");

                entity.HasOne(d => d.ICodCooperadoNavigation)
                    .WithMany(p => p.InverseICodCooperadoNavigation)
                    .HasForeignKey(d => d.ICodCooperado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContatosFavoritosCooperado");
            });

            modelBuilder.Entity<TipoChavePix>(entity =>
            {
                entity.HasKey(e => e.ICodPix);

                entity.Property(e => e.ICodPix)
                    .HasColumnName("iCodPix")
                    .ValueGeneratedNever();

                entity.Property(e => e.SDescricao)
                    .HasColumnName("sDescricao")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
