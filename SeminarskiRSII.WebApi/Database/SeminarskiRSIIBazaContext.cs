using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SeminarskiRSII.WebApi.Database
{
    public partial class SeminarskiRSIIBazaContext : DbContext
    {
        public SeminarskiRSIIBazaContext()
        {
        }

        public SeminarskiRSIIBazaContext(DbContextOptions<SeminarskiRSIIBazaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cjenovnik> Cjenovnik { get; set; }
        public virtual DbSet<Drzava> Drzava { get; set; }
        public virtual DbSet<Gost> Gost { get; set; }
        public virtual DbSet<GostiNotifikacije> GostiNotifikacije { get; set; }
        public virtual DbSet<Grad> Grad { get; set; }
        public virtual DbSet<Notifikacije> Notifikacije { get; set; }
        public virtual DbSet<Novosti> Novosti { get; set; }
        public virtual DbSet<Osoblje> Osoblje { get; set; }
        public virtual DbSet<OsobljeUloge> OsobljeUloge { get; set; }
        public virtual DbSet<Recenzija> Recenzija { get; set; }
        public virtual DbSet<Rezervacija> Rezervacija { get; set; }
        public virtual DbSet<Soba> Soba { get; set; }
        public virtual DbSet<SobaOsoblje> SobaOsoblje { get; set; }
        public virtual DbSet<SobaStatus> SobaStatus { get; set; }
        public virtual DbSet<VrstaOsoblja> VrstaOsoblja { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=SeminarskiRSIIBaza;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cjenovnik>(entity =>
            {
                entity.ToTable("cjenovnik");

                entity.HasIndex(e => e.SobaId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cijena).HasColumnName("cijena");

                entity.Property(e => e.SobaId).HasColumnName("sobaID");

                entity.HasOne(d => d.Soba)
                    .WithMany(p => p.Cjenovnik)
                    .HasForeignKey(d => d.SobaId);
            });

            modelBuilder.Entity<Drzava>(entity =>
            {
                entity.ToTable("drzava");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv).HasColumnName("naziv");
            });

            modelBuilder.Entity<Gost>(entity =>
            {
                entity.ToTable("gost");

                entity.HasIndex(e => e.GradId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.GradId).HasColumnName("gradID");

                entity.Property(e => e.Ime).HasColumnName("ime");

                entity.Property(e => e.Prezime).HasColumnName("prezime");

                entity.Property(e => e.Telefon).HasColumnName("telefon");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Gost)
                    .HasForeignKey(d => d.GradId);
            });

            modelBuilder.Entity<GostiNotifikacije>(entity =>
            {
                entity.ToTable("gostiNotifikacije");

                entity.HasIndex(e => e.GostId);

                entity.HasIndex(e => e.NotifikacijeId);

                entity.Property(e => e.GostId).HasColumnName("gostID");

                entity.Property(e => e.NotifikacijeId).HasColumnName("notifikacijeId");

                entity.HasOne(d => d.Gost)
                    .WithMany(p => p.GostiNotifikacije)
                    .HasForeignKey(d => d.GostId);

                entity.HasOne(d => d.Notifikacije)
                    .WithMany(p => p.GostiNotifikacije)
                    .HasForeignKey(d => d.NotifikacijeId);
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.ToTable("grad");

                entity.HasIndex(e => e.DrzavaId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DrzavaId).HasColumnName("drzavaID");

                entity.Property(e => e.NazivGrada).HasColumnName("nazivGrada");

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Grad)
                    .HasForeignKey(d => d.DrzavaId);
            });

            modelBuilder.Entity<Notifikacije>(entity =>
            {
                entity.ToTable("notifikacije");

                entity.HasIndex(e => e.NovostId);

                entity.HasOne(d => d.Novost)
                    .WithMany(p => p.Notifikacije)
                    .HasForeignKey(d => d.NovostId);
            });

            modelBuilder.Entity<Novosti>(entity =>
            {
                entity.ToTable("novosti");

                entity.HasIndex(e => e.OsobljeId);

                entity.Property(e => e.OsobljeId).HasColumnName("osobljeID");

                entity.HasOne(d => d.Osoblje)
                    .WithMany(p => p.Novosti)
                    .HasForeignKey(d => d.OsobljeId);
            });

            modelBuilder.Entity<Osoblje>(entity =>
            {
                entity.ToTable("osoblje");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Ime).HasColumnName("ime");

                entity.Property(e => e.Prezime).HasColumnName("prezime");

                entity.Property(e => e.Telefon).HasColumnName("telefon");
            });

            modelBuilder.Entity<OsobljeUloge>(entity =>
            {
                entity.ToTable("osobljeUloge");

                entity.HasIndex(e => e.OsobljeId);

                entity.HasIndex(e => e.VrstaOsobljaId);

                entity.Property(e => e.OsobljeUlogeId).HasColumnName("OsobljeUlogeID");

                entity.Property(e => e.OsobljeId).HasColumnName("osobljeID");

                entity.Property(e => e.VrstaOsobljaId).HasColumnName("vrstaOsobljaID");

                entity.HasOne(d => d.Osoblje)
                    .WithMany(p => p.OsobljeUloge)
                    .HasForeignKey(d => d.OsobljeId);

                entity.HasOne(d => d.VrstaOsoblja)
                    .WithMany(p => p.OsobljeUloge)
                    .HasForeignKey(d => d.VrstaOsobljaId);
            });

            modelBuilder.Entity<Recenzija>(entity =>
            {
                entity.ToTable("recenzija");

                entity.HasIndex(e => e.GostId);

                entity.HasIndex(e => e.SobaId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GostId).HasColumnName("gostID");

                entity.Property(e => e.Komentar).HasColumnName("komentar");

                entity.Property(e => e.Ocjena).HasColumnName("ocjena");

                entity.Property(e => e.SobaId).HasColumnName("sobaID");

                entity.HasOne(d => d.Gost)
                    .WithMany(p => p.Recenzija)
                    .HasForeignKey(d => d.GostId);

                entity.HasOne(d => d.Soba)
                    .WithMany(p => p.Recenzija)
                    .HasForeignKey(d => d.SobaId);
            });

            modelBuilder.Entity<Rezervacija>(entity =>
            {
                entity.ToTable("rezervacija");

                entity.HasIndex(e => e.GostId);

                entity.HasIndex(e => e.SobaId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DatumRezervacije).HasColumnName("datumRezervacije");

                entity.Property(e => e.GostId).HasColumnName("gostID");

                entity.Property(e => e.SobaId).HasColumnName("sobaID");

                entity.Property(e => e.ZavrsetakRezervacije).HasColumnName("zavrsetakRezervacije");

                entity.HasOne(d => d.Gost)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.GostId);

                entity.HasOne(d => d.Soba)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.SobaId);
            });

            modelBuilder.Entity<Soba>(entity =>
            {
                entity.ToTable("soba");

                entity.HasIndex(e => e.SobaStatusId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OpisSobe).HasColumnName("opisSobe");

                entity.Property(e => e.SobaStatusId).HasColumnName("sobaStatusID");

                entity.HasOne(d => d.SobaStatus)
                    .WithMany(p => p.Soba)
                    .HasForeignKey(d => d.SobaStatusId);
            });

            modelBuilder.Entity<SobaOsoblje>(entity =>
            {
                entity.ToTable("sobaOsoblje");

                entity.HasIndex(e => e.OsobljeId);

                entity.HasIndex(e => e.SobaId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OsobljeId).HasColumnName("osobljeID");

                entity.Property(e => e.SobaId).HasColumnName("sobaID");

                entity.HasOne(d => d.Osoblje)
                    .WithMany(p => p.SobaOsoblje)
                    .HasForeignKey(d => d.OsobljeId);

                entity.HasOne(d => d.Soba)
                    .WithMany(p => p.SobaOsoblje)
                    .HasForeignKey(d => d.SobaId);
            });

            modelBuilder.Entity<SobaStatus>(entity =>
            {
                entity.ToTable("sobaStatus");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Opis).HasColumnName("opis");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<VrstaOsoblja>(entity =>
            {
                entity.ToTable("vrstaOsoblja");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Pozicija).HasColumnName("pozicija");

                entity.Property(e => e.Zaduzenja).HasColumnName("zaduzenja");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
