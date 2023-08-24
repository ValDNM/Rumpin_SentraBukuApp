using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace buku_rumpin.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    buku_id = table.Column<Guid>(nullable: false),
                    judul = table.Column<string>(nullable: true),
                    penulis = table.Column<string>(nullable: true),
                    penerbit = table.Column<string>(nullable: true),
                    tempat_terbit = table.Column<string>(nullable: true),
                    tahun_terbit = table.Column<int>(nullable: false),
                    ed_cet = table.Column<string>(nullable: true),
                    bahasa = table.Column<string>(nullable: true),
                    isbn_issn = table.Column<string>(nullable: true),
                    uri_gambar = table.Column<string>(nullable: true),
                    kategori = table.Column<int>(nullable: false),
                    keterangan = table.Column<string>(nullable: true),
                    id_lama = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.buku_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
