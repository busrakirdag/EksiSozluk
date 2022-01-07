using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EksiSozluk.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Konular",
                columns: table => new
                {
                    KonuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KonuAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konular", x => x.KonuID);
                });

            migrationBuilder.CreateTable(
                name: "Kullanıcılar",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullanıcıAdı = table.Column<string>(name: "Kullanıcı Adı", type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanıcılar", x => x.KullaniciID);
                });

            migrationBuilder.CreateTable(
                name: "Başlıklar",
                columns: table => new
                {
                    BaslikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Başlık = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Başlıklar", x => x.BaslikID);
                    table.ForeignKey(
                        name: "FK_Başlıklar_Konular_KonID",
                        column: x => x.KonID,
                        principalTable: "Konular",
                        principalColumn: "KonuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entry",
                columns: table => new
                {
                    EntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    İçerik = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaslkID = table.Column<int>(type: "int", nullable: false),
                    KullancID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entry", x => x.EntryID);
                    table.ForeignKey(
                        name: "FK_Entry_Başlıklar_BaslkID",
                        column: x => x.BaslkID,
                        principalTable: "Başlıklar",
                        principalColumn: "BaslikID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entry_Kullanıcılar_KullancID",
                        column: x => x.KullancID,
                        principalTable: "Kullanıcılar",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Başlıklar_KonID",
                table: "Başlıklar",
                column: "KonID");

            migrationBuilder.CreateIndex(
                name: "IX_Entry_BaslkID",
                table: "Entry",
                column: "BaslkID");

            migrationBuilder.CreateIndex(
                name: "IX_Entry_KullancID",
                table: "Entry",
                column: "KullancID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entry");

            migrationBuilder.DropTable(
                name: "Başlıklar");

            migrationBuilder.DropTable(
                name: "Kullanıcılar");

            migrationBuilder.DropTable(
                name: "Konular");
        }
    }
}
