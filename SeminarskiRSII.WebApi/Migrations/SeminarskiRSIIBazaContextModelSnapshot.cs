﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeminarskiRSII.WebApi.Database;

namespace SeminarskiRSII.WebApi.Migrations
{
    [DbContext(typeof(SeminarskiRSIIBazaContext))]
    partial class SeminarskiRSIIBazaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.Cjenovnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojDana")
                        .HasColumnType("int");

                    b.Property<float>("Cijena")
                        .HasColumnName("cijena")
                        .HasColumnType("real");

                    b.Property<int>("SobaId")
                        .HasColumnName("sobaID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SobaId");

                    b.ToTable("cjenovnik");
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.Drzava", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnName("naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("drzava");
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.Gost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GradId")
                        .HasColumnName("gradID")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasColumnName("ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnickoIme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LozinkaHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LozinkaSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnName("prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnName("telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GradId");

                    b.ToTable("gost");
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.GostiNotifikacije", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GostId")
                        .HasColumnName("gostID")
                        .HasColumnType("int");

                    b.Property<int>("NotifikacijaId")
                        .HasColumnType("int");

                    b.Property<int?>("NotifikacijeId")
                        .HasColumnName("notifikacijeId")
                        .HasColumnType("int");

                    b.Property<bool>("Pregledana")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("GostId");

                    b.HasIndex("NotifikacijeId");

                    b.ToTable("gostiNotifikacije");
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.Grad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrzavaId")
                        .HasColumnName("drzavaID")
                        .HasColumnType("int");

                    b.Property<string>("NazivGrada")
                        .HasColumnName("nazivGrada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostanskiBroj")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DrzavaId");

                    b.ToTable("grad");
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.Notifikacije", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumSlanja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naslov")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NovostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NovostId");

                    b.ToTable("notifikacije");
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.Novosti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumObjave")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naslov")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OsobljeId")
                        .HasColumnName("osobljeID")
                        .HasColumnType("int");

                    b.Property<string>("Sadrzaj")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OsobljeId");

                    b.ToTable("novosti");
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.Osoblje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnName("ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnickoIme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LozinkaHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LozinkaSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnName("prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Slika")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Telefon")
                        .HasColumnName("telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("osoblje");
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.OsobljeUloge", b =>
                {
                    b.Property<int>("OsobljeUlogeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OsobljeUlogeID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumIzmjene")
                        .HasColumnType("datetime2");

                    b.Property<int>("OsobljeId")
                        .HasColumnName("osobljeID")
                        .HasColumnType("int");

                    b.Property<int>("VrstaOsobljaId")
                        .HasColumnName("vrstaOsobljaID")
                        .HasColumnType("int");

                    b.HasKey("OsobljeUlogeId");

                    b.HasIndex("OsobljeId");

                    b.HasIndex("VrstaOsobljaId");

                    b.ToTable("osobljeUloge");
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.Recenzija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GostId")
                        .HasColumnName("gostID")
                        .HasColumnType("int");

                    b.Property<string>("Komentar")
                        .HasColumnName("komentar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ocjena")
                        .HasColumnName("ocjena")
                        .HasColumnType("int");

                    b.Property<int>("SobaId")
                        .HasColumnName("sobaID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GostId");

                    b.HasIndex("SobaId");

                    b.ToTable("recenzija");
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.Rezervacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRezervacije")
                        .HasColumnName("datumRezervacije")
                        .HasColumnType("datetime2");

                    b.Property<int>("GostId")
                        .HasColumnName("gostID")
                        .HasColumnType("int");

                    b.Property<bool?>("Otkazana")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Qrcode")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("SobaId")
                        .HasColumnName("sobaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ZavrsetakRezervacije")
                        .HasColumnName("zavrsetakRezervacije")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GostId");

                    b.HasIndex("SobaId");

                    b.ToTable("rezervacija");
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.Soba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojSobe")
                        .HasColumnType("int");

                    b.Property<int>("BrojSprata")
                        .HasColumnType("int");

                    b.Property<string>("OpisSobe")
                        .HasColumnName("opisSobe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PicturePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Slika")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("SobaStatusId")
                        .HasColumnName("sobaStatusID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SobaStatusId");

                    b.ToTable("soba");
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.SobaOsoblje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OsobljeId")
                        .HasColumnName("osobljeID")
                        .HasColumnType("int");

                    b.Property<int>("SobaId")
                        .HasColumnName("sobaID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OsobljeId");

                    b.HasIndex("SobaId");

                    b.ToTable("sobaOsoblje");
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.SobaStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Opis")
                        .HasColumnName("opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnName("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("sobaStatus");
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.VrstaOsoblja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Pozicija")
                        .HasColumnName("pozicija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zaduzenja")
                        .HasColumnName("zaduzenja")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("vrstaOsoblja");
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.Cjenovnik", b =>
                {
                    b.HasOne("SeminarskiRSII.WebApi.Database.Soba", "Soba")
                        .WithMany("Cjenovnik")
                        .HasForeignKey("SobaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.Gost", b =>
                {
                    b.HasOne("SeminarskiRSII.WebApi.Database.Grad", "Grad")
                        .WithMany("Gost")
                        .HasForeignKey("GradId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.GostiNotifikacije", b =>
                {
                    b.HasOne("SeminarskiRSII.WebApi.Database.Gost", "Gost")
                        .WithMany("GostiNotifikacije")
                        .HasForeignKey("GostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeminarskiRSII.WebApi.Database.Notifikacije", "Notifikacije")
                        .WithMany("GostiNotifikacije")
                        .HasForeignKey("NotifikacijeId");
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.Grad", b =>
                {
                    b.HasOne("SeminarskiRSII.WebApi.Database.Drzava", "Drzava")
                        .WithMany("Grad")
                        .HasForeignKey("DrzavaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.Notifikacije", b =>
                {
                    b.HasOne("SeminarskiRSII.WebApi.Database.Novosti", "Novost")
                        .WithMany("Notifikacije")
                        .HasForeignKey("NovostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.Novosti", b =>
                {
                    b.HasOne("SeminarskiRSII.WebApi.Database.Osoblje", "Osoblje")
                        .WithMany("Novosti")
                        .HasForeignKey("OsobljeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.OsobljeUloge", b =>
                {
                    b.HasOne("SeminarskiRSII.WebApi.Database.Osoblje", "Osoblje")
                        .WithMany("OsobljeUloge")
                        .HasForeignKey("OsobljeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeminarskiRSII.WebApi.Database.VrstaOsoblja", "VrstaOsoblja")
                        .WithMany("OsobljeUloge")
                        .HasForeignKey("VrstaOsobljaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.Recenzija", b =>
                {
                    b.HasOne("SeminarskiRSII.WebApi.Database.Gost", "Gost")
                        .WithMany("Recenzija")
                        .HasForeignKey("GostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeminarskiRSII.WebApi.Database.Soba", "Soba")
                        .WithMany("Recenzija")
                        .HasForeignKey("SobaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.Rezervacija", b =>
                {
                    b.HasOne("SeminarskiRSII.WebApi.Database.Gost", "Gost")
                        .WithMany("Rezervacija")
                        .HasForeignKey("GostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeminarskiRSII.WebApi.Database.Soba", "Soba")
                        .WithMany("Rezervacija")
                        .HasForeignKey("SobaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.Soba", b =>
                {
                    b.HasOne("SeminarskiRSII.WebApi.Database.SobaStatus", "SobaStatus")
                        .WithMany("Soba")
                        .HasForeignKey("SobaStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeminarskiRSII.WebApi.Database.SobaOsoblje", b =>
                {
                    b.HasOne("SeminarskiRSII.WebApi.Database.Osoblje", "Osoblje")
                        .WithMany("SobaOsoblje")
                        .HasForeignKey("OsobljeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeminarskiRSII.WebApi.Database.Soba", "Soba")
                        .WithMany("SobaOsoblje")
                        .HasForeignKey("SobaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}