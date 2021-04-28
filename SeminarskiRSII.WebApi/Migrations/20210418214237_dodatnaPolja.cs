using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeminarskiRSII.WebApi.Migrations
{
    public partial class dodatnaPolja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "drzava",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drzava", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "osoblje",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(nullable: true),
                    prezime = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    LozinkaHash = table.Column<string>(nullable: true),
                    LozinkaSalt = table.Column<string>(nullable: true),
                    telefon = table.Column<string>(nullable: true),
                    Slika = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_osoblje", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "sobaStatus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(nullable: true),
                    opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sobaStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "vrstaOsoblja",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pozicija = table.Column<string>(nullable: true),
                    zaduzenja = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vrstaOsoblja", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "grad",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazivGrada = table.Column<string>(nullable: true),
                    PostanskiBroj = table.Column<int>(nullable: false),
                    drzavaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grad", x => x.ID);
                    table.ForeignKey(
                        name: "FK_grad_drzava_drzavaID",
                        column: x => x.drzavaID,
                        principalTable: "drzava",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "novosti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(nullable: true),
                    Sadrzaj = table.Column<string>(nullable: true),
                    DatumObjave = table.Column<DateTime>(nullable: false),
                    osobljeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_novosti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_novosti_osoblje_osobljeID",
                        column: x => x.osobljeID,
                        principalTable: "osoblje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "soba",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojSprata = table.Column<int>(nullable: false),
                    BrojSobe = table.Column<int>(nullable: false),
                    opisSobe = table.Column<string>(nullable: true),
                    Slika = table.Column<byte[]>(nullable: true),
                    PictureName = table.Column<string>(nullable: true),
                    PicturePath = table.Column<string>(nullable: true),
                    sobaStatusID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_soba", x => x.ID);
                    table.ForeignKey(
                        name: "FK_soba_sobaStatus_sobaStatusID",
                        column: x => x.sobaStatusID,
                        principalTable: "sobaStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "osobljeUloge",
                columns: table => new
                {
                    OsobljeUlogeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    osobljeID = table.Column<int>(nullable: false),
                    vrstaOsobljaID = table.Column<int>(nullable: false),
                    DatumIzmjene = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_osobljeUloge", x => x.OsobljeUlogeID);
                    table.ForeignKey(
                        name: "FK_osobljeUloge_osoblje_osobljeID",
                        column: x => x.osobljeID,
                        principalTable: "osoblje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_osobljeUloge_vrstaOsoblja_vrstaOsobljaID",
                        column: x => x.vrstaOsobljaID,
                        principalTable: "vrstaOsoblja",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gost",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(nullable: true),
                    prezime = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    LozinkaHash = table.Column<string>(nullable: true),
                    LozinkaSalt = table.Column<string>(nullable: true),
                    telefon = table.Column<string>(nullable: true),
                    gradID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gost", x => x.ID);
                    table.ForeignKey(
                        name: "FK_gost_grad_gradID",
                        column: x => x.gradID,
                        principalTable: "grad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notifikacije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(nullable: true),
                    DatumSlanja = table.Column<DateTime>(nullable: false),
                    NovostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifikacije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notifikacije_novosti_NovostId",
                        column: x => x.NovostId,
                        principalTable: "novosti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cjenovnik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sobaID = table.Column<int>(nullable: false),
                    BrojDana = table.Column<int>(nullable: false),
                    cijena = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cjenovnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_cjenovnik_soba_sobaID",
                        column: x => x.sobaID,
                        principalTable: "soba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sobaOsoblje",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sobaID = table.Column<int>(nullable: false),
                    osobljeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sobaOsoblje", x => x.ID);
                    table.ForeignKey(
                        name: "FK_sobaOsoblje_osoblje_osobljeID",
                        column: x => x.osobljeID,
                        principalTable: "osoblje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sobaOsoblje_soba_sobaID",
                        column: x => x.sobaID,
                        principalTable: "soba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recenzija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gostID = table.Column<int>(nullable: false),
                    sobaID = table.Column<int>(nullable: false),
                    ocjena = table.Column<int>(nullable: false),
                    komentar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recenzija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_recenzija_gost_gostID",
                        column: x => x.gostID,
                        principalTable: "gost",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_recenzija_soba_sobaID",
                        column: x => x.sobaID,
                        principalTable: "soba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rezervacija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gostID = table.Column<int>(nullable: false),
                    sobaID = table.Column<int>(nullable: false),
                    datumRezervacije = table.Column<DateTime>(nullable: false),
                    zavrsetakRezervacije = table.Column<DateTime>(nullable: false),
                    Qrcode = table.Column<byte[]>(nullable: true),
                    Otkazana = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rezervacija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_rezervacija_gost_gostID",
                        column: x => x.gostID,
                        principalTable: "gost",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rezervacija_soba_sobaID",
                        column: x => x.sobaID,
                        principalTable: "soba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gostiNotifikacije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    notifikacijeId = table.Column<int>(nullable: true),
                    NotifikacijaId = table.Column<int>(nullable: false),
                    gostID = table.Column<int>(nullable: false),
                    Pregledana = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gostiNotifikacije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gostiNotifikacije_gost_gostID",
                        column: x => x.gostID,
                        principalTable: "gost",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gostiNotifikacije_notifikacije_notifikacijeId",
                        column: x => x.notifikacijeId,
                        principalTable: "notifikacije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cjenovnik_sobaID",
                table: "cjenovnik",
                column: "sobaID");

            migrationBuilder.CreateIndex(
                name: "IX_gost_gradID",
                table: "gost",
                column: "gradID");

            migrationBuilder.CreateIndex(
                name: "IX_gostiNotifikacije_gostID",
                table: "gostiNotifikacije",
                column: "gostID");

            migrationBuilder.CreateIndex(
                name: "IX_gostiNotifikacije_notifikacijeId",
                table: "gostiNotifikacije",
                column: "notifikacijeId");

            migrationBuilder.CreateIndex(
                name: "IX_grad_drzavaID",
                table: "grad",
                column: "drzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_notifikacije_NovostId",
                table: "notifikacije",
                column: "NovostId");

            migrationBuilder.CreateIndex(
                name: "IX_novosti_osobljeID",
                table: "novosti",
                column: "osobljeID");

            migrationBuilder.CreateIndex(
                name: "IX_osobljeUloge_osobljeID",
                table: "osobljeUloge",
                column: "osobljeID");

            migrationBuilder.CreateIndex(
                name: "IX_osobljeUloge_vrstaOsobljaID",
                table: "osobljeUloge",
                column: "vrstaOsobljaID");

            migrationBuilder.CreateIndex(
                name: "IX_recenzija_gostID",
                table: "recenzija",
                column: "gostID");

            migrationBuilder.CreateIndex(
                name: "IX_recenzija_sobaID",
                table: "recenzija",
                column: "sobaID");

            migrationBuilder.CreateIndex(
                name: "IX_rezervacija_gostID",
                table: "rezervacija",
                column: "gostID");

            migrationBuilder.CreateIndex(
                name: "IX_rezervacija_sobaID",
                table: "rezervacija",
                column: "sobaID");

            migrationBuilder.CreateIndex(
                name: "IX_soba_sobaStatusID",
                table: "soba",
                column: "sobaStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_sobaOsoblje_osobljeID",
                table: "sobaOsoblje",
                column: "osobljeID");

            migrationBuilder.CreateIndex(
                name: "IX_sobaOsoblje_sobaID",
                table: "sobaOsoblje",
                column: "sobaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cjenovnik");

            migrationBuilder.DropTable(
                name: "gostiNotifikacije");

            migrationBuilder.DropTable(
                name: "osobljeUloge");

            migrationBuilder.DropTable(
                name: "recenzija");

            migrationBuilder.DropTable(
                name: "rezervacija");

            migrationBuilder.DropTable(
                name: "sobaOsoblje");

            migrationBuilder.DropTable(
                name: "notifikacije");

            migrationBuilder.DropTable(
                name: "vrstaOsoblja");

            migrationBuilder.DropTable(
                name: "gost");

            migrationBuilder.DropTable(
                name: "soba");

            migrationBuilder.DropTable(
                name: "novosti");

            migrationBuilder.DropTable(
                name: "grad");

            migrationBuilder.DropTable(
                name: "sobaStatus");

            migrationBuilder.DropTable(
                name: "osoblje");

            migrationBuilder.DropTable(
                name: "drzava");
        }
    }
}
